﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerController : MonoBehaviour
{

    CharacterController cc;

    public Camera thisCam;
    //private Transform camTran;
    public float velocity = 10f;
    public float mouseSpeed = 5f;
    public float verticalRotation = 0;
    public float verticalLimiter = 25f;
    float verticalVelocity = 0f;
    public float jumpSpeed = 7f;
    public Animator anim;
    Transform cameraT;
    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;
    float speed = 5;
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;


    public static int currentlives;
    int lives;

    // Use this for initialization
    void Start()
    {

        anim.GetComponent<Animator>();

        if (thisCam != null)
        {
            cameraT = thisCam.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged MainCamera");
        }

        cc = GetComponent<CharacterController>();
        currentlives = 9;
    }

    // Update is called once per frame
    void Update()
    {
        lives = currentlives;
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (input != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        float targetSpeed = 5 * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

       // transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
        //transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation,ref velocity,1f);
        //float rotateX = Input.GetAxis("Horizontal") + cameraT.eulerAngles.y;
        //Input.GetAxis ("HorizontalRight") * mouseSpeed;
        // transform.Rotate(0f, rotateX, 0f);

        //verticalRotation -= Input.GetAxis("Mouse Y") * Mathf.Rad2Deg + cameraT.eulerAngles.y;
        //Input.GetAxis ("VerticalRight") * mouseSpeed;
        //verticalRotation = Mathf.Clamp(verticalRotation, -verticalLimiter, verticalLimiter - 10);
        //camTran.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        //if(verticalRotation < 0 && camTran.localPosition.y > 0.3f)
        //{
        //    camTran.localPosition = new Vector3(camTran.localPosition.x, camTran.localPosition.y - 0.08f, camTran.localPosition.z + 0.01f);
        //}
        //else if (verticalRotation > 0 && camTran.localPosition.y < 1.5f)
        //{
        //    camTran.localPosition = new Vector3(camTran.localPosition.x, camTran.localPosition.y + 0.08f, camTran.localPosition.z - 0.01f);
        //}

        float forwardSpeed = Input.GetAxis("Vertical") * velocity;
        float sideSpeed = Input.GetAxis("Horizontal") * velocity;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpSpeed;
        }

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;

        cc.Move(speed * Time.deltaTime);

        //if (forwardSpeed > 0 || sideSpeed > 0)
        //{
        //    anim.SetBool("IsMoving", true);
        //    /*this.GetComponentInChildren<Animation>();*/
        //}
        //else
        //{
        //    anim.SetBool("IsMoving", false);
        //}
    }
    
    
}
