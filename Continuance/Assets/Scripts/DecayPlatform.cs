using UnityEngine;
using System.Collections;

public class DecayPlatform : Platform
{
	// Use this for initialization
	void Start ()
    {
        platformCollider = transform.GetComponent<BoxCollider>();
        platformRenderer = transform.GetComponent<MeshRenderer>();
        platformRenderer.material.color = Color.green;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //accelerate time button pressed
        if (Input.GetKeyDown(KeyAccelerate))
        {
            //check if in sphere
            //change platform to be not walkable on 
            platformCollider.enabled = false;
            //change visuals
            platformRenderer.material.color = Color.red;
        }
        if (Input.GetKeyUp(KeyAccelerate)) //when key is released the platform is walkable on again
        {
            platformCollider.enabled = true;
            platformRenderer.material.color = Color.green;
        }



    }
}
