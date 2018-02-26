using System.Collections;
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
    public float jumpSpeed = 4f;
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
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + Mathf.RoundToInt(cameraT.eulerAngles.y);

            transform.localEulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.localEulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        float targetSpeed = 5 * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);


        float forwardSpeed = Input.GetAxis("Vertical") * velocity;
        float sideSpeed = Input.GetAxis("Horizontal") * velocity;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpSpeed;
            forwardSpeed += 0.01f;
            anim.SetBool("jumping", true);
        }
        else
        {
            anim.SetBool("jumping", false);
        }
        if (cc.isGrounded == false)
        {
            forwardSpeed += 0.01f;
        }
        Vector3 speed = new Vector3(0, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;

        //if (speed != Vector3.zero)
        //{
        //    cc.Move(speed * Time.deltaTime);
        //    anim.SetBool("IsMoving", true);
        //}
        //else
        //{
        //   // anim.SetBool("IsMoving", false);
        //}


        if (forwardSpeed > 0 || sideSpeed != 0)
        {
            cc.Move(speed * Time.deltaTime);
            anim.SetBool("IsMoving", true);
            anim.SetBool("Idle", false);
            /*this.GetComponentInChildren<Animation>();*/
        }
        else
        {
            anim.SetBool("IsMoving", false);
            anim.SetBool("Idle", true);
        }
    }
    //MerryGoRound
//private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.tag == "MovingObject")
//        {
//            transform.parent = collision.transform;
//        }

//    }


//    private void OnCollisionExit(Collision collision)
//    {
//        if (collision.gameObject.tag == "MovingObject")
//        {
//            transform.parent = null;
//        }
//    }
}
