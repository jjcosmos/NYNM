﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float maxHThrust;
    [SerializeField] float thrustAcceleration;
    [SerializeField] float jumpForce;
    [SerializeField] public float moveSpeed;
    public float currentThrust;
    private Rigidbody RB;
    Quaternion leftRot;
    Quaternion rightRot;
    float yVelocity;
    int mask;

    private bool grounded;
    Quaternion loggedBaseRot;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] ParticleSystem trailParticles;
    void Start()
    {
        currentThrust = 0;
        RB = GetComponent<Rigidbody>();

        leftRot = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 45, -10));
        rightRot = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, -45, 10));
        mask = LayerMask.GetMask("Ground");
        yVelocity = 1;
        loggedBaseRot = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = isGrounded();
        float input = Input.GetAxis("Horizontal");


        if (Input.GetButtonDown("Jump") && grounded)
        {
            RB.AddForce(new Vector3(0, 1, 0) * jumpForce);
        }


        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < .1f)
        {
            if(currentThrust > 0)
            {
                currentThrust -= Time.deltaTime * maxHThrust/2;
                if(currentThrust < 0)
                {
                    currentThrust = 0;
                }
            }
            else if(currentThrust < 0)
            {
                currentThrust += Time.deltaTime * maxHThrust/2;
                if (currentThrust > 0)
                {
                    currentThrust = 0;
                }
            }
        }

        currentThrust = Mathf.Clamp((currentThrust  +  (input * thrustAcceleration * Time.deltaTime)), -maxHThrust, maxHThrust);
        //RB.velocity += new Vector3(currentThrust, 0, 0);
        //float clampedXVelocity = Mathf.Clamp(RB.velocity.x, -maxHThrust, maxHThrust);
        //RB.velocity = new Vector3(clampedXVelocity, RB.velocity.y, 0);
        //RB.velocity = new Vector3 ((transform.forward * moveSpeed).x, RB.velocity.y, (transform.forward * moveSpeed).z);
        ///*
        Vector3 normVec = new Vector3(transform.forward.x * (1+ Mathf.Abs(currentThrust/maxHThrust)), 0, transform.forward.z);
        
        if(new Vector2(RB.velocity.x, RB.velocity.z).magnitude < 30 )
        {
            
            RB.AddForce(normVec * moveSpeed * Time.deltaTime * 1000);
        }
        else
        {
            RB.AddForce(Vector3.Scale(normVec, new Vector3(1,1,0)) * moveSpeed * Time.deltaTime * 1000);
        }
        //*/
        if (transform.rotation.eulerAngles.x > 10 && transform.rotation.eulerAngles.x < 90)
        {
            //Debug.Log(transform.rotation.eulerAngles.x);
            transform.Rotate(new Vector3(-50f * Time.deltaTime, 0, 0));
        }
        Quaternion targetQuat = Quaternion.Slerp(rightRot, leftRot, (((currentThrust) / maxHThrust) + 1) / 2);
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, targetQuat.eulerAngles.y, targetQuat.eulerAngles.z  ));




        //Debug.Log(RB.velocity.x);
        if (grounded)
        {
            trailParticles.Play();
        }
        else
        {
            trailParticles.Stop();
        }

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("LoadZone") )
            Debug.Log(other.name + "hit");
    }
    private bool isGrounded()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f, mask);
        if(colliders.Length > 0)
        {
            Debug.Log("True");
            return true;
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(RB.velocity.y < .1f)
            hitParticles.Play();
    }
}
