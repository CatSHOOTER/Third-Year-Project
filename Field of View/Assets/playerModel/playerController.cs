using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerController : MonoBehaviour
{

    CharacterController cc;

    public Camera thisCam;
    private Transform camTran;
    public Transform GrandChild;
    public float velocity = 10f;
    public float mouseSpeed = 5f;
    public float verticalRotation = 0;
    public float verticalLimiter = 25f;
    float verticalVelocity = 0f;
    public float jumpSpeed = 7f;
    public Animator anim;

    // Use this for initialization
    void Start()
    {

        anim.GetComponent<Animator>();

        if (thisCam != null)
        {
            camTran = thisCam.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged MainCamera");
        }

        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float rotateX = Input.GetAxis("Mouse X") * mouseSpeed;
        //Input.GetAxis ("HorizontalRight") * mouseSpeed;
        transform.Rotate(0f, rotateX, 0f);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSpeed;
        //Input.GetAxis ("VerticalRight") * mouseSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLimiter, verticalLimiter);
        camTran.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

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

        if (forwardSpeed > 0 || sideSpeed > 0)
        {
            anim.SetBool("IsMoving", true);
            /*this.GetComponentInChildren<Animation>();*/
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    GrandChild = this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1);
    //    GrandChild.GetComponent.rigidbody;
    //    //GrandChild = this.gameObject.transform.GetChild(2);
    //    if (collision.gameObject.tag == "VStoper")
    //    {
    //        Physics.IgnoreCollision(GrandChild.collider, collider);
    //    }

    //}
    
}
