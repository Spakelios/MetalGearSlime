using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HitBySlime : MonoBehaviour
{
    public static HitBySlime instance;
    public TextMeshProUGUI hit;

    public int damage = 0;

    private void Start()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        
        hit.text = damage.ToString();
    }

    public void ChangeScore(int slime)
    {
        
        damage += slime;
        hit.text =  damage.ToString();
    }
}
