using UnityEngine;
using System.Collections;

public class FixPlatform : Platform
{
    // Use this for initialization
    void Start ()
    {
        platformCollider = transform.GetComponent<BoxCollider>();
        platformRenderer = transform.GetComponent<MeshRenderer>();
        platformRenderer.material.color = Color.red;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //reverse time button pressed
        if (Input.GetKeyDown(KeyReverse))
        {
            //check if in sphere
            //change platform to be not walkable on 
            platformCollider.enabled = true;
            //change visuals
            platformRenderer.material.color = Color.green;
        }
        if (Input.GetKeyUp(KeyReverse)) //when key is released the platform is walkable on again
        {
            platformCollider.enabled = false;
            platformRenderer.material.color = Color.red;
        }
    }
}
