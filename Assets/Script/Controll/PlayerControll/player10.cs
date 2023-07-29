using UnityEngine;
using System.Collections;

public class player10 : MonoBehaviour
{
    //https://forum.gamer.com.tw/Co.php?bsn=60602&sn=2484
    //要再改

    public bool jumpingCheck = false;

    public bool fallingCheck = false;


    public float FallingSpeed;
    public float jumpforce;

    //public Animator MotionAnimator;
    public bool groundCheck = false;
    public bool jumptofallcheck = false;
    public Rigidbody rigidbody;






    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        jumpUp();
        JumpToFall();
        FallingFunction();

    }


    void OnCollisionEnter(Collision selfbody)
    {
        if (selfbody.gameObject.tag == "ground")
        {
            groundCheck = true;
            jumpingCheck = false;
            Debug.Log("ground!");
            //MotionAnimator.SetBool("OnGround", groundCheck);

        }
    }

    void OnCollisionExit(Collision selfbodyexit)
    {
        if (selfbodyexit.gameObject.tag == "ground")
            groundCheck = false;
        Debug.Log("offground!");
        //MotionAnimator.SetBool("OnGround", groundCheck);
    }


    void jumpUp()
    {
        if (Input.GetButtonDown("Jump") && groundCheck == true /*&& crouching == false*/)
        {
            jumpingCheck = true;
            //MotionAnimator.SetBool("jumping", jumpingCheck);
            rigidbody.AddForce(Vector3.up * jumpforce);

        }
    }

    void JumpToFall()
    {
        FallingSpeed = rigidbody.velocity.y;
        Debug.Log (rigidbody.velocity.y);
        if (FallingSpeed <= 1 && groundCheck == false)
        {
            jumptofallcheck = true;
            Debug.Log("jumptofall!!");
            //MotionAnimator.SetBool("jumptofall", jumptofallcheck);
            jumpingCheck = false;
            //MotionAnimator.SetBool("jumping", jumpingCheck);

        }
    }

    void FallingFunction()
    {
        if (FallingSpeed < 0 && groundCheck == false && jumptofallcheck == true)
        {
            fallingCheck = true;
            //MotionAnimator.SetBool("falling", fallingCheck);
            //MotionAnimator.SetBool("OnGround", groundCheck);

        }

    }
}
