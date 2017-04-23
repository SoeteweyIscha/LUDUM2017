using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;


public class Char_ctrl : NetworkBehaviour {

    public float Speed = 6.0F;
    public float JumpSpeed = 8.0F;
    //public float Gravity = 20.0F;
    public Rigidbody controller;
    [SerializeField]
    private Camera _characterCamera;
    private Vector3 moveDirection = Vector3.zero;
    //private Vector3 turnLeft = new Vector3(0, -90.0f, 0);
    //private Vector3 turnRight = new Vector3(0, 90.0f, 0);
    [SerializeField]
    private GravityAttractor planet;

    //audio
    public AudioClip walkingSound;
    public float walkingSoundVol;
    private AudioSource _soundSource;

    public AudioClip jumpSound;
    public float jumpSoundVol;
    private AudioSource _soundSource2;

    private void Awake()
    {
        _soundSource = GetComponent<AudioSource>();
        _soundSource2 = GetComponent<AudioSource>();
    }

    //public override void OnStartLocalPlayer()
    public override void OnStartLocalPlayer()
    {
        if(isLocalPlayer)
        {
            _characterCamera.transform.position = this.transform.position - this.transform.right * 3 + this.transform.up * 3;
            _characterCamera.transform.LookAt(this.transform.position);
            _characterCamera.transform.parent = this.transform;
            controller = this.GetComponent<Rigidbody>();
        }
        
    }

    void Update()
    {

        if (!isLocalPlayer)
        {
            _characterCamera.GetComponent<Camera>().enabled = false;
            Destroy(this);
            return;
        }
       
        // is the controller on the ground?
        
            //Feed moveDirection with input.
            
        //float y = moveDirection.y;
        moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, 0);
        moveDirection = transform.TransformDirection(moveDirection);
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        transform.Rotate(0,x,0);
        /*
        if (Input.GetButton("turnLeft"))
            {
                this.transform.Rotate(turnLeft * Time.deltaTime);
            }
        if (Input.GetButton("turnRight"))
            {
                this.transform.Rotate(turnRight * Time.deltaTime);
            }
        */
        //Multiply it by speed.
        moveDirection *= Speed;
        //Applying gravity to the controller
        //moveDirection.y -= Gravity * Time.deltaTime;
        //Making the character move
        controller.MovePosition(controller.position + moveDirection * Time.deltaTime);

        //play walking sound
        _soundSource.loop = true;
        _soundSource.clip = walkingSound;
        _soundSource.Play();

    }

    private void OnCollisionStay(Collision collision)
    {

        if (!isLocalPlayer)
            return;
        if (Input.GetButtonDown("Jump") && this.tag == "Player")
        {
            Debug.Log("Jumped");
            //force keeps addinf up -> solve this please
            controller.AddForce(transform.up*200);
            //play jump sound
            _soundSource2.PlayOneShot(jumpSound, jumpSoundVol);
        }
    }


}

