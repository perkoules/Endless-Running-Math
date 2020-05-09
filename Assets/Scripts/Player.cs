using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Camera PlayerCamera;

    private bool bGameStarted = false;

    public Vector3 AddedVelocity = new Vector3(0,  0, 200);

    Animator playerAnimator;
    Rigidbody playerRigdbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigdbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            bGameStarted = true;
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            
        }
    }
    void FixedUpdate()
    {
        if (bGameStarted)
        {
            playerAnimator.SetBool("hasGameStarted", bGameStarted);
            playerRigdbody.AddForce(AddedVelocity, ForceMode.Acceleration);
        }
    }
}
