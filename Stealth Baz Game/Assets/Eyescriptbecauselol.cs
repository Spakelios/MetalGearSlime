using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyescriptbecauselol : MonoBehaviour
{
    public GameObject BigSlime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBody"))
        {
            BigSlime.GetComponent<MoveToBigSlime>().foundplayer();
        }
    }
}
