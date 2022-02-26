using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SlimeValue : MonoBehaviour

{
    public int slime = 1;
    
    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("Slime"))
        {
            HitBySlime.instance.ChangeScore(slime);
        }
    }
}