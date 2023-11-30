using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float currentSpeed;
    public float walkingSpeed = 10f;
    public float runningSpeed = 15f;

    public float gravity = -0.5f;
    private float baseLineGravity;
    public float jumpSpeed = 0.8f;


    private float moveX;
    private float moveZ;
    private Vector3 move;

    public CharacterController characterController;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkingSpeed;//on start speed is walkspeed
        baseLineGravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {

        moveX = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        move = transform.right * moveX +
            transform.up * gravity +
            transform.forward * moveZ;
        characterController.Move(move);

        if(Input.GetKey(KeyCode.LeftShift))//checking if shift is pressed so that we can run
        {
            currentSpeed = runningSpeed;
        }
        else
        {
            currentSpeed = walkingSpeed;
        }


       if (characterController.isGrounded && Input.GetButtonDown("Jump"))
       {
            gravity = baseLineGravity;
            gravity *= -jumpSpeed;
       }

       if (gravity > baseLineGravity)
        {
            gravity -= 2 * Time.deltaTime;
        }

        
    }
}
