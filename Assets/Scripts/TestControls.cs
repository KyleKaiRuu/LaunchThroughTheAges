using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControls : MonoBehaviour {
    
    private float speed = .5f;
    public float velocity = 25f;
	
	void Update ()
    {
       
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
        transform.position += Vector3.left * speed;
        }
       
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * velocity;
        }



    }
}
