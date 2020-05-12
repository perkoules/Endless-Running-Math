using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    public Camera playerCamera;
    public FloorSpawner spawnerScript;
    public bool bGameStarted = false;

    private Vector3 AddedVelocity = new Vector3(0,  0, 200);
    private float distanceFromStart = 0f;
    private int randomForMin = 1, correctAnswer = 0;  
    private Animator playerAnimator;
    private Rigidbody playerRigdbody;
    private QuestionController questionController;
    private TextMeshProUGUI txtDistance;
    private TextMeshProUGUI txtStartMessage;

    void Start()
    {
        questionController = FindObjectOfType<QuestionController>();
        txtDistance = GameObject.FindGameObjectWithTag("Distance").GetComponent<TextMeshProUGUI>();
        txtStartMessage = GameObject.FindGameObjectWithTag("StartMsg").GetComponent<TextMeshProUGUI>();
        playerRigdbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (bGameStarted)
        {
            DifficultyController();
            JumpController();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
    public void Initialization()
    {
        bGameStarted = true;
        playerAnimator.SetBool("hasGameStarted", bGameStarted);
        txtStartMessage.enabled = false;
        questionController.DifficultyButtons(0);
        correctAnswer = questionController.ProblemChooser(randomForMin);
    }

    private void JumpController()
    {
        if (correctAnswer != 0)
        { 
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (correctAnswer == 1)
                {
                    CorrectAnswerGiven();
                }
                else
                {
                    WrongAnswerGiven();
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (correctAnswer == 2)
                {
                    CorrectAnswerGiven();
                }
                else
                {
                    WrongAnswerGiven();
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (correctAnswer == 3)
                {
                    CorrectAnswerGiven();
                }
                else
                {
                    WrongAnswerGiven();
                }
            }
        }
        else
        {
            correctAnswer = questionController.ProblemChooser(randomForMin);
        }
    }


    private void CorrectAnswerGiven()
    {
        playerAnimator.SetTrigger("Jump");
        playerRigdbody.AddForce(Vector3.up * 250f, ForceMode.Impulse);
        correctAnswer = questionController.ProblemChooser(randomForMin);
    }
    private void WrongAnswerGiven()
    {
        bGameStarted = false;
        spawnerScript.SpawnStopper();
        playerAnimator.SetBool("WrongAnswer", true);
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
}
