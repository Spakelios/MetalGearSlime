using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject[] Door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerBody"))
        {
            foreach(GameObject door in Door)
            {
                Destroy(door);
            }
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}
