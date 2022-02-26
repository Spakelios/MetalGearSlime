using System;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SpeedGauge : MonoBehaviour
{
    public TextMeshProUGUI speeds;
   public SpeedGauge instance;

    private void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {

        {
            speeds.text = GetComponent<PlayerMovement>().speed.ToString();
        }
    }
}
    
