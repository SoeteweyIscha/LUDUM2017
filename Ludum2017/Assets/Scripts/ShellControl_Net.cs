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

    private ParticleSystem _explosion;
    private MeshRenderer _shellRenderer;


	// Use this for initialization
	void Start ()
    {
        _explosion = GetComponentInChildren<ParticleSystem>();        
        _shellRenderer = GetComponent<MeshRenderer>();
        //_explosion.transform.localPosition = Vector3.zero;
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
        //particle effect

        _shellRenderer.enabled = false;
        _explosion.Play();

        if (!isServer)
            return;

        if (!_canKill || other.gameObject.tag != "Player")
            return;

        PaperBagHealth health = other.gameObject.GetComponent<PaperBagHealth>();
        if (health != null)
            health.TakeDamage(1);
        
    }
}
