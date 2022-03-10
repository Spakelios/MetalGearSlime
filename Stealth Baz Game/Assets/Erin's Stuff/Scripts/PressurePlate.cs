using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject[] Door;
    public AudioSource pressed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerBody"))
        {
            pressed.Play();
            
            foreach(GameObject door in Door)
            {
                Destroy(door);
            }
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}
