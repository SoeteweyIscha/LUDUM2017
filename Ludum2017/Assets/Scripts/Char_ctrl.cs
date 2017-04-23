using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;


public class Char_ctrl : NetworkBehaviour {

    public float Speed = 6.0F;
    public float JumpSpeed = 8.0F;
    public float Gravity = 20.0F;
    public Rigidbody controller;
    [SerializeField]
    private Transform _characterCamera;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 turnLeft = new Vector3(0, -90.0f, 0);
    private Vector3 turnRight = new Vector3(0, 90.0f, 0);

    //public override void OnStartLocalPlayer()
    private void Start()
    {
       controller  = this.GetComponent<Rigidbody>();
        if(isLocalPlayer)
        {
            _characterCamera.transform.position = this.transform.position - this.transform.right * 3 + this.transform.up * 3;
            _characterCamera.transform.LookAt(this.transform.position);
            _characterCamera.transform.parent = this.transform;
        }
        
    }

    void Update()
    {

        if (!isLocalPlayer)
        {
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



    }


}

