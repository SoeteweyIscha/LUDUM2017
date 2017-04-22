using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTeleport : MonoBehaviour {


    private float SphereRadius;
    public GameObject World;
    private Rigidbody _rb;
    


    void Start () {
        SphereRadius = World.GetComponent<SphereCollider>().radius * World.transform.localScale.x;
        _rb = this.GetComponent<Rigidbody>();
    }
	
	
	void Update () {
        SphereRadius = World.GetComponent<SphereCollider>().radius * World.transform.localScale.x;

        

        if (Input.GetKeyDown("space"))
        {
            ValidLocation();
        }
      }

    void ValidLocation()
    {

        bool cont = true;
      do
        {
            Vector3 randomVec = Random.onUnitSphere;
            Ray ray = new Ray(World.transform.position, randomVec);
            Vector3 newPos = ray.GetPoint(SphereRadius + 1);
            this.transform.position = newPos;
            this.transform.Rotate(-randomVec);
            _rb.velocity = Vector3.zero;
            Debug.Log(randomVec);

            Collider[] botsing =  Physics.OverlapBox(this.transform.position, new Vector3(0.5f, 0.5f, 0.5f), this.transform.rotation);
            cont = false;
            for (int b=0; b<botsing.Length; ++b)
            {
                if (botsing[b].gameObject != this.gameObject) cont = true;
                Debug.Log("botsts met " + botsing[b].gameObject.name);
            }
            
        }
     while (cont);     

    }




}
