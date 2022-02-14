using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintingLoudness : MonoBehaviour
{
    public GameObject Player;
    private PlayerMovement playerscript;
    public SphereCollider detectionradius;
    public float BaseDetectionRadius, SprintDetectionradius, CrouchDetectionradius;
    public float DetectedRadiusMultiplier;
    public bool sprintin = false;   

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerscript = Player.GetComponent<PlayerMovement>();
        detectionradius = this.GetComponent<SphereCollider>();
        DetectedRadiusMultiplier = 2;
    }


    private void Update()
    {



      
            DetectionShift();
        



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DetectedRadiusMultiplier = 16;
            if (sprintin == true)
            {
                detectionradius.radius = SprintDetectionradius * DetectedRadiusMultiplier;
            }
            else
            {
                detectionradius.radius = BaseDetectionRadius * DetectedRadiusMultiplier;
            }
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DetectedRadiusMultiplier = 2;
            if (sprintin == true)
            {
                detectionradius.radius = SprintDetectionradius * DetectedRadiusMultiplier;
            }
            else
            {
                detectionradius.radius = BaseDetectionRadius * DetectedRadiusMultiplier;
            }

        }


    }


    private void DetectionShift()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            detectionradius.radius = SprintDetectionradius * DetectedRadiusMultiplier;
            Debug.Log("yeah but it");
            sprintin = true;
        }

        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            detectionradius.radius = CrouchDetectionradius * DetectedRadiusMultiplier;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            detectionradius.radius = BaseDetectionRadius * DetectedRadiusMultiplier;
            Debug.Log("makes a lot of lag");
            sprintin = false;
        }
        else if ( Input.GetKeyUp(KeyCode.LeftControl))
        {
            detectionradius.radius = BaseDetectionRadius * DetectedRadiusMultiplier;
            Debug.Log("makes a lot of lag");
            
        }


    }
}
