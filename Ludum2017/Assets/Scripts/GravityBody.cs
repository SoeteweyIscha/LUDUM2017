﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    //audio 
      
    GravityAttractor planet;

    Rigidbody _rigidbody;



    private void Awake()
    {

        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        _rigidbody = GetComponent<Rigidbody>();
        // Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
        _rigidbody.useGravity = false;
        if(this.tag != "Rock")
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        
    }

    void FixedUpdate()
    {
       // Allow this body to be influenced by planet's gravity
        planet.Attract(_rigidbody);     
    }

    
}
