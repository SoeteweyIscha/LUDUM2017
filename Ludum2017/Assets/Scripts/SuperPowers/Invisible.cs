using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Invisible : NetworkBehaviour {

    private MeshRenderer[] invisible;
    private TrailRenderer trail;
    public float Timeleft = 5;

    void Start () {
        invisible = GetComponentsInChildren<MeshRenderer>();
            trail = GetComponent<TrailRenderer>();

        CmdResetTrail();
	}
	
	
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            CmdActivate();
        }

        if (Timeleft > 0) Timeleft -= Time.deltaTime;
        else CmdResetTrail();

	}

    [Command]
    void CmdResetTrail()
    {
        for(int i = 0; i < invisible.Length; i++)
        {
            invisible[i].enabled = true;
        }
        trail.enabled = false;
    }

    [Command]
    void CmdActivate()
    {
        for (int i = 0; i < invisible.Length; i++)
        {
            invisible[i].enabled = false;
        }
        trail.enabled = true;
        Timeleft = 5;
    }

}
