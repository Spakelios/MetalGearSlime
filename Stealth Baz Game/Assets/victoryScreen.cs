using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoryScreen : MonoBehaviour
{
    public GameObject victory;
    public GameObject ui;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("victory"))
        {
            victory.SetActive(true);
            ui.SetActive(false);
        }
    }

}