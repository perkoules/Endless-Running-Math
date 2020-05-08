using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Camera PlayerCamera;

    private bool bGameStarted = false;
    private Rigidbody PlayerRigidBody;
    private Animator playerAnimator;

    public Vector3 AddedVelocity = new Vector3(0, 0, 200);

    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        PlayerRigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void PlayerMovement(bool bStartRunning)
    {
        if (bStartRunning)
        {
            playerAnimator.SetBool("hasGameStarted", bStartRunning);
            PlayerRigidBody.velocity = AddedVelocity * 2;
        }
    }
}
