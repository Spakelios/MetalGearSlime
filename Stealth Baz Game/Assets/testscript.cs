using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    public GameObject stuckto;
    public Vector3 eyeplace;
   
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = stuckto.gameObject.transform.position;
    }


}
