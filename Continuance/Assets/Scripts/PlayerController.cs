using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    // Use this for initialization

    public float xSpeed;
    public float ySpeed;
    public bool isGrounded;
    public GameObject timeSphere;
    public float sphereGrowth;
    Rigidbody rb;

    public KeyCode KeyJump;
    public KeyCode KeyAccelerate;
    public KeyCode KeyReverse;

    float JumpVelocity;
    float JumpDampening = 0.05f;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
     
	// Update is called once per frame
	void Update ()
    {
        Movement();
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyAccelerate) || Input.GetKey(KeyReverse))
        {
            if (timeSphere.transform.localScale.x < 5.0f)
            {
                timeSphere.transform.localScale += new Vector3(sphereGrowth, sphereGrowth, sphereGrowth);
            }
        }
        else if (timeSphere.transform.localScale.x > 2.0f)
        {
                timeSphere.transform.localScale -= new Vector3(sphereGrowth, sphereGrowth, sphereGrowth);
        }

        if (JumpVelocity != 0)
        {
            pos.y += JumpVelocity;
            JumpVelocity -= JumpDampening;
            if (JumpVelocity <= 0)
            {
                rb.useGravity = true;
                JumpVelocity = 0;
            }
        }

        transform.position = pos;
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
        transform.Translate(x, 0, 0);
        
        if (Input.GetKeyDown(KeyJump) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        JumpVelocity = 0.4f;
        isGrounded = false;
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("collided");
        if (col.gameObject.tag.Contains("floor"))
        {
            Debug.Log("with the floor");
            isGrounded = true;
        } 
    }

}
