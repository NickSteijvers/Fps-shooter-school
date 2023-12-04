using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyV2 : MonoBehaviour
{
    private enemiesMovement enemiesmovement;
    private Transform player;
    public float attackRange = 10f;

    public Material defaultMaterial;
    public Material attackMaterial;
    private Renderer rend;

    private bool foundPlayer;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemiesmovement = GetComponent<enemiesMovement>();
        rend = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            rend.sharedMaterial = attackMaterial;
            enemiesmovement.badGuy.SetDestination(player.position);
            foundPlayer = true;
        }
        else if (foundPlayer)
        {
            rend.sharedMaterial = defaultMaterial;
            enemiesmovement.newLocation();
            foundPlayer = false;
        }
    }
}
