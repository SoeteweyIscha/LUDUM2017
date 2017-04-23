using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class ShellControl_Net : NetworkBehaviour
{
    [SerializeField]
    private float _shellLifetime = 2f;
    [SerializeField]
    private bool _canKill = false;

    private bool _isLive = true;
    private float _age;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Shells are update by the server
    [ServerCallback]
	void Update ()
    {
        // if the shell has been alive too long...
        _age += Time.deltaTime;
        if (_age > _shellLifetime)
        {
            //Destroy them on the network
            NetworkServer.Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        //If the shell isn't alive, leave
        if (!_isLive)
            return;

        _isLive = false;

        if (!isServer)
            return;

        if (!_canKill || other.gameObject.tag != "Player")
            return;

        //PaperBagHealth health = other.gameObject.getComponent<PaperBagHealth>();
        //if (health != null)
            //health.TakeDamage(1);
    }
}
