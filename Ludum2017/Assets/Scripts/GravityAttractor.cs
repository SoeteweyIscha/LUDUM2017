using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour {

    public float gravity = -9.8f;
    private Vector3 _gravityUp;
    private Vector3 _localUp;
    private Vector3 _ownGravity;

    public void Attract(Rigidbody body)
    {

        _gravityUp = (body.position - transform.position).normalized;

         _localUp = body.transform.up;

        _ownGravity = _gravityUp * gravity;

        // Apply downwards gravity to body

        body.AddForce(_ownGravity);

        // Allign bodies up axis with the centre of planet

        body.rotation = Quaternion.FromToRotation(_localUp, _gravityUp) * body.rotation;

    }

    public Vector3 GetTheGravity()
    {
        return _ownGravity;
    }
}
