using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    //dit script word op alles gezet, er moet nog in een main script de gravity uitgeschakeld worden [ Physics.gravity = new Vector3 (0,0,0); ]

    public GameObject planet;
    private Rigidbody _rb;
    public float acceleration;


	
	void Start () {
        _rb = this.GetComponent<Rigidbody>();

	}
	
	
	void Update () {
        _rb.AddForce((planet.transform.position - this.transform.position).normalized * acceleration);
    }
}
