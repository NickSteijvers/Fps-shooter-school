using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


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

    private Transform enemy;
    private bool hitByEnemy;

    public int health = 10;

    public TMP_Text healthPoints;

    public bool gameLost;

    // Start is called before the first frame update
    void Start()
    {
        gameLost = false;
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkingSpeed;//on start speed is walkspeed
        baseLineGravity = gravity;
        enemy = GameObject.FindGameObjectWithTag("NPC").transform;
 
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

        if (hitByEnemy == true)
        {
            health = health - 1;
            Debug.Log(health);
            healthPoints.text = " X " + health;
            hitByEnemy = false;
        }

        if (health == 0)
        {
            gameLost = true;
            SceneManager.LoadScene(sceneName: "gameOver");
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (gameLost == false)
        {
            if (collision.gameObject.CompareTag("NPC"))
            {
                hitByEnemy = true;
            }
        }
            if (collision.gameObject.CompareTag("hpPowerUp"))
            {
                health += 3;
                healthPoints.text = " X " + health;
                Destroy(collision.gameObject);
        }
    }
}
