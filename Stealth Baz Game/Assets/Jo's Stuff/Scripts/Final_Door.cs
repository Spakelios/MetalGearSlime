using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Door : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public AudioSource openSeasame;


    private void Update()
    {
        if (light1.activeInHierarchy && light2.activeInHierarchy && light3.activeInHierarchy)
        {
            openSeasame.Play();
            Destroy(this.gameObject);
        }
    }
}
