using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
   
    private Rigidbody rigid;
    
  

    [SerializeField] private float _movementForce = 50f;
    [SerializeField] private double _maximumVelocity = 50f;

    private void Awake() => rigid = GetComponent<Rigidbody>();
    
    private void FixedUpdate()
    {
        if (rigid.velocity.magnitude >= _maximumVelocity)
            return;

        if (Input.GetKey(KeyCode.W))
            rigid.AddForce(_movementForce * transform.forward); // move forward with w

        if (Input.GetKey(KeyCode.S))
            rigid.AddForce(_movementForce * -transform.forward); // -foward force goes back with s

        if (Input.GetKey(KeyCode.D))
            rigid.AddForce(_movementForce * transform.right); // move right with d

        if (Input.GetKey(KeyCode.A))
            rigid.AddForce(_movementForce * -transform.right); //- right force goes left with a
    }
}
