using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintingLoudness : MonoBehaviour
{
    public GameObject Player;
    private PlayerMovement playerscript;
    public SphereCollider detectionradius;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerscript = Player.GetComponent<PlayerMovement>();
        detectionradius = this.GetComponent<SphereCollider>();
    }


    private void Update()
    {

        

        if (playerscript.issprint == true)
        {
            detectionradius.radius = 10;
            Debug.Log("yeah but it");
        }
        else
        {
            detectionradius.radius = 5;
            Debug.Log("makes a lot of lag");
        }
        

    }

}
