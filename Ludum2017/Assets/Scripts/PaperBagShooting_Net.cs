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
    private GameObject _bulletPrefab;
    //place of shooting bullet
    [SerializeField]
    private Transform _gunBarrel;



    private void Awake()
    {
        //find the place where it shoots from
        _gunBarrel = transform.FindChild("GunBarrel");
    }

	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("BulletFired");
            CmdSpawnBullet();
        }
	}

    [Command]
    void CmdSpawnBullet()
    {
        //instantiate the shell on correct pos
        GameObject instance = Instantiate(_bulletPrefab, _gunBarrel.position, _gunBarrel.rotation) as GameObject;
        //locate shell component and add force
        instance.GetComponent<Rigidbody>().AddForce(-_gunBarrel.up * power);

        //instantiate the object on the server
        NetworkServer.Spawn(instance);
    }
}
