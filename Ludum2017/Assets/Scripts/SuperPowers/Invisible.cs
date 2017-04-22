using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour {

    private MeshRenderer invisible;
    private TrailRenderer trail;
    public float Timeleft = 5;

    void Start () {
        invisible = GetComponent<MeshRenderer>();
        trail = GetComponent<TrailRenderer>();

        Reset();
	}
	
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.I))
        {
            Activate();
        }

        if (Timeleft > 0) Timeleft -= Time.deltaTime;
        else Reset();

	}

    void Reset()
    {
        invisible.enabled = true;
        trail.enabled = false;
    }

    void Activate()
    {
        invisible.enabled = false;
        trail.enabled = true;
        Timeleft = 5;
    }

}
