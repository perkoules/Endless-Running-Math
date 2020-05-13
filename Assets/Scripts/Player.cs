using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    public Camera playerCamera;
    public FloorSpawner spawnerScript;
    public bool bGameStarted = false;
    public string whichButtonPressed;

    private int correctAnswer = 0, pointsObtained;  
    private float distanceFromStart = 0f;
    private Vector3 AddedVelocity = new Vector3(0,  0, 200);
    private Animator playerAnimator;
    private Rigidbody playerRigdbody;
    private QuestionController questionController;
    private TextMeshProUGUI txtDistance, txtPoints, txtStartMessage;
    private Button btnStart;
    private PlayerPrefsScript scoreHolderScript;

    void Start()
    {
        pointsObtained = 0;
        questionController = FindObjectOfType<QuestionController>();
        scoreHolderScript = FindObjectOfType<PlayerPrefsScript>();
        txtDistance = GameObject.FindGameObjectWithTag("Distance").GetComponent<TextMeshProUGUI>();
        txtStartMessage = GameObject.FindGameObjectWithTag("StartMsg").GetComponent<TextMeshProUGUI>();
        txtPoints = GameObject.FindGameObjectWithTag("Points").GetComponent<TextMeshProUGUI>();
        btnStart = GameObject.FindGameObjectWithTag("StartButton").GetComponent<Button>();
        playerRigdbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }
    public void Initialization()
    {
        bGameStarted = true;
        playerAnimator.SetBool("hasGameStarted", bGameStarted);
        txtStartMessage.gameObject.SetActive(false);
        btnStart.gameObject.SetActive(false);
        questionController.ListenForGUIButtons();
        questionController.DifficultyButtons(0);
        correctAnswer = questionController.ProblemChooser();
    }
    void Update()
    {
        if (bGameStarted)
        {
            DifficultyController();
            JumpController(-1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bGameStarted = false;
            SceneManager.LoadScene("LoseScreen");
        }
    }
    void FixedUpdate()
    {
        if (bGameStarted)
        {
            distanceFromStart = gameObject.transform.position.z;
            txtDistance.text = distanceFromStart.ToString("F2") + "m";
            playerRigdbody.AddForce(AddedVelocity, ForceMode.Acceleration);
        }
    }
    public void JumpController(int btn)
    {
        if (correctAnswer != 0)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.J) || btn == 0)
            {
                if (correctAnswer == 1)
                {
                    CorrectAnswerGiven();
                }
                else
                {
                    StartCoroutine(LosingActions());
                }
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K) || btn == 1)
            {
                if (correctAnswer == 2)
                {
                    CorrectAnswerGiven();
                }
                else
                {
                    StartCoroutine(LosingActions());
                }
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.L) || btn == 2)
            {
                if (correctAnswer == 3)
                {
                    CorrectAnswerGiven();
                }
                else
                {
                    StartCoroutine(LosingActions());
                }
            }
        }
        else if (correctAnswer == 0)
        {
            correctAnswer = questionController.ProblemChooser();
        }
    }


    private void CorrectAnswerGiven()
    {
        switch (questionController.randomChooser)
        {
            case 0://Addition
                pointsObtained += 100;
                break;
            case 1://Subtraction
                pointsObtained += 150;
                break;
            case 2://Multiplication
                pointsObtained += 250;
                break;
            case 3://Division
                pointsObtained += 350;
                break;
            default:
                break;
        }
        txtPoints.text = pointsObtained.ToString();
        playerAnimator.SetTrigger("Jump");
        playerRigdbody.AddForce(Vector3.up * 250f, ForceMode.Impulse);
        correctAnswer = questionController.ProblemChooser();
    }
    IEnumerator LosingActions()
    {
        bGameStarted = false;
        spawnerScript.SpawnStopper();
        playerCamera.transform.SetParent(null);
        playerAnimator.SetTrigger("WrongAnswer");
        playerRigdbody.isKinematic = true;
        scoreHolderScript.ScoreHolder(pointsObtained + distanceFromStart);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("LoseScreen");
    }


    void DifficultyController()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            questionController.DifficultyButtons(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            questionController.DifficultyButtons(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            questionController.DifficultyButtons(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            questionController.DifficultyButtons(3);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Obstacle(Clone)")
        {
            StartCoroutine(LosingActions());
        }
    }
}
