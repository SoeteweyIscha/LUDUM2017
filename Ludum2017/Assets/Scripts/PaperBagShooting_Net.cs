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

    //audio
    public AudioClip shootSound;
    public float shootSoundVol;
    private AudioSource _soundSource;

    private void Awake()
    {
        //find the place where it shoots from
        _gunBarrel = transform.FindChild("GunBarrel");
        
        

        _soundSource = GetComponent<AudioSource>();
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
            //play jump sound
            _soundSource.PlayOneShot(shootSound, shootSoundVol);
        }
	}

    [Command]
    void CmdSpawnBullet()
    {
        //instantiate the shell on correct pos
        GameObject instance = Instantiate(_bulletPrefab, _gunBarrel.position + _gunBarrel.up, _gunBarrel.rotation) as GameObject;
        //locate shell component and add force
        instance.GetComponent<Rigidbody>().AddForce(_gunBarrel.up * power);

        //instantiate the object on the server
        NetworkServer.Spawn(instance);
    }
}
