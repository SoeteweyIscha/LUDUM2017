using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour {

    private MeshRenderer[] invisible;
    private TrailRenderer trail;
    public float Timeleft = 5;

    void Start () {
        invisible = GetComponentsInChildren<MeshRenderer>();
            trail = GetComponent<TrailRenderer>();

        ResetTrail();
	}
	
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.I))
        {
            Activate();
        }

        if (Timeleft > 0) Timeleft -= Time.deltaTime;
        else ResetTrail();

	}

    void ResetTrail()
    {
        for(int i = 0; i < invisible.Length; i++)
        {
            invisible[i].enabled = true;
        }
        trail.enabled = false;
    }

    void Activate()
    {
        for (int i = 0; i < invisible.Length; i++)
        {
            invisible[i].enabled = false;
        }
        trail.enabled = true;
        Timeleft = 5;
    }

}
