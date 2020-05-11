using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    [SerializeField] private Camera playerCamera;
    [SerializeField] private QuestionController questionController;
    [SerializeField] private TextMeshProUGUI txtDistance, txtStartMessage;

    private bool bGameStarted = false;
    private Vector3 AddedVelocity = new Vector3(0,  0, 200);
    private float distanceFromStart = 0f;
    private int randomForMin = 1, correctAnswer = 0;

    private Animator playerAnimator;
    private Rigidbody playerRigdbody;

    void Start()
    {
        playerRigdbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && bGameStarted == false)
        {
            bGameStarted = true; 
            playerAnimator.SetBool("hasGameStarted", bGameStarted);
            questionController.DifficultyButtons(0);
            correctAnswer = questionController.ProblemChooser(randomForMin);
            txtStartMessage.enabled = false;
        }
        if (bGameStarted)
        {
            DifficultyController();
            JumpController();
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
    private void JumpController()
    {
        if (correctAnswer != 0)
        { 
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (correctAnswer == 1)
                {
                    playerAnimator.SetTrigger("Jump");
                    playerRigdbody.AddForce(Vector3.up * 250f, ForceMode.Impulse);
                    correctAnswer = questionController.ProblemChooser(randomForMin);
                }
                else
                {
                    bGameStarted = false;
                    playerAnimator.SetBool("WrongAnswer", true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (correctAnswer == 2)
                {
                    playerAnimator.SetTrigger("Jump");
                    playerRigdbody.AddForce(Vector3.up * 250f, ForceMode.Impulse);
                    correctAnswer = questionController.ProblemChooser(randomForMin);
                }
                else
                {
                    bGameStarted = false;
                    playerAnimator.SetBool("WrongAnswer", true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (correctAnswer == 3)
                {
                    playerAnimator.SetTrigger("Jump");
                    playerRigdbody.AddForce(Vector3.up * 250f, ForceMode.Impulse);
                    correctAnswer = questionController.ProblemChooser(randomForMin);
                }
                else
                {
                    bGameStarted = false;
                    playerAnimator.SetBool("WrongAnswer", true);
                }
            }
        }
        else
        {
            correctAnswer = questionController.ProblemChooser(randomForMin);
        }
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
