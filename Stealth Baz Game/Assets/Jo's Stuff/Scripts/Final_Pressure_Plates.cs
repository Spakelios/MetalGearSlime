using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Pressure_Plates : MonoBehaviour
{
    public GameObject[] Light;
    public AudioSource pressed;

    void Start()
    {
        foreach (GameObject light in Light)
        {
            light.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerBody"))
        {
            pressed.Play();
            foreach(GameObject light in Light)
            {
                light.SetActive(true);
            }
            
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}
