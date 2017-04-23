using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PaperBagShooting_Net : NetworkBehaviour {

    // power of bullets
    [SerializeField]
    private float power = 800f;
    //bulletobject
    [SerializeField]
    private GameObject _shellPrefab;
    //place of shooting bullet
    [SerializeField]
    private Transform _gunBarrel;



    private void Reset()
    {
        //find the place where it shoots from
        //_gunBarrel = transform.
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
