using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Invisible : NetworkBehaviour {

    private MeshRenderer[] invisible;
    private TrailRenderer trail;
    //public float Timeleft = 5;

    public override void OnStartClient ()
    {
        invisible = GetComponentsInChildren<MeshRenderer>();
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
        //CmdResetTrail();
	}
	
	
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Request Invisible");
            CmdActivate();
        }

       // if (Timeleft > 0) Timeleft -= Time.deltaTime;
        //else CmdResetTrail();

	}

    [Command]
    private void CmdActivate()
    {
        RpcActivate();
        StartCoroutine(Reactivate());
    }

    private IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(5);
        RpcResetTrail();
    }

    [Command]
    private void CmdResetTrail()
    {
        RpcResetTrail();
    }

    [ClientRpc]
    void RpcResetTrail()
    {
        for(int i = 0; i < invisible.Length; i++)
        {
            invisible[i].enabled = true;
        }
        trail.enabled = false;
    }

    [ClientRpc]
    void RpcActivate()
    {
        Debug.Log("Going Invisible");
        for (int i = 0; i < invisible.Length; i++)
        {
            invisible[i].enabled = false;
        }
        trail.enabled = true;
        //Timeleft = 5;
    }

}
