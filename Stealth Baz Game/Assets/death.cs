using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{

    public GameObject spawnpoint;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Slime"))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = spawnpoint.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
            //  Debug.Log("at least it says something");
        }
        if (other.gameObject.CompareTag("SlimeSmall"))
        {
            player.GetComponent<PlayerMovement>().slimed += 1f;
            player.GetComponent<PlayerMovement>().speed = player.GetComponent<PlayerMovement>().speed / player.GetComponent<PlayerMovement>().slimed;
            //  Debug.Log("at least it says something");
        }
    }
}
