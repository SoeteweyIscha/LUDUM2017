using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TreeStay : MonoBehaviour {

    Rigidbody _rb;
    Vector3 initPos;

	
	void Start () {
        _rb = this.GetComponent<Rigidbody>();
        initPos = transform.position.normalized;
	}
	
	
	void FixedUpdate () {
        Vector3 Vel = _rb.velocity;
        Vel = transform.InverseTransformVector(Vel);

        Vel.x = 0;
        Vel.z = 0;

        Vel = transform.TransformVector(Vel);

        _rb.velocity = Vel;

        transform.position = initPos * (transform.position.magnitude);

    }
}
