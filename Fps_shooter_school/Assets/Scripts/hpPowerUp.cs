using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hpPowerUp : MonoBehaviour
{
    private playerMovement playerMovementScript;
    public TMP_Text healthPoints;

   
    void Start()
    {
        playerMovementScript = GetComponent<playerMovement>();
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hpPowerUp"))
        {
            playerMovementScript.health += 3;
            healthPoints.text = " X " + playerMovementScript.health;
            Destroy(collision.gameObject);
        }
    }
}




