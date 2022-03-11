using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float slimed = 1;
    public float slimetime = 600;
    public Light plight;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded = false;
    public bool issprint = false;
    public bool iscrouch = false;

    public SphereCollider SprintCollider;


    // Update is called once per frame
    void Update()
    {
        Debug.Log(slimed);
        if (slimed > 1)
        {
            slimetime -= 1;
            if (slimetime < 1)
            {
                slimed -= 1f;
                slimetime = 600;
                speed = speed / slimed;
            }
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            print("space key was pressed");
            issprint = true;
            speed = 18 / slimed;
            SprintCollider.radius = 18;
            plight.innerSpotAngle = 120;
            plight.spotAngle = 170;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            print("space key was  noT N ONFASONFO ASDNFO lOLpressed");
            issprint = false;
            speed = 12 / slimed;
            SprintCollider.radius = 6;
            plight.innerSpotAngle = 85;
            plight.spotAngle = 97;

        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            iscrouch = true;
            speed = 6 / slimed;

            SprintCollider.radius = 0.2f;
            plight.innerSpotAngle = 10;
            plight.spotAngle = 10;

        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            iscrouch = true;
            speed = 12 / slimed;
            SprintCollider.radius = 6f;

            plight.spotAngle = 97;
            plight.innerSpotAngle = 85;

        }

    }
}
