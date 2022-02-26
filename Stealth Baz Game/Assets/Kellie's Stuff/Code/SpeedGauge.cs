using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedGauge : MonoBehaviour
{
    public TextMeshProUGUI speeds;
    

    private void Start()
    {
        speeds.text = GetComponent<PlayerMovement>().velocity.ToString();
    }


}
