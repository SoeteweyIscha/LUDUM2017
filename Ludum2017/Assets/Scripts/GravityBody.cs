﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{



    GravityAttractor planet;

    Rigidbody _rigidbody;



    void Awake()
    {

        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        _rigidbody = GetComponent<Rigidbody>();
        // Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
        _rigidbody.useGravity = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }



    void FixedUpdate()
    {

        // Allow this body to be influenced by planet's gravity

        planet.Attract(_rigidbody);

        


    }

    private void OnCollisionStay(Collision collision)
    {
    
        if (Input.GetButtonDown("Jump"))
        {

            _rigidbody.AddForce(-planet.GetTheGravity() * 20);
        }
    }
}
