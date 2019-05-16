using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControls : MonoBehaviour {
    [ReadOnlyField]
    public float speed = 1.0f;
    public float velocity = 5.0f;
	
	void Update ()
    {
       
        Vector3 pos = transform.position;
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    pos.y += speed * Time.deltaTime;
        //}
        if (Input.GetKey(KeyCode.LeftArrow))
        {
        transform.position += Vector3.left * speed;
        }
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    pos.y -= speed * Time.deltaTime;
        //}
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //transform.position += Vector3.up * velocity * Time.deltaTime;
            GetComponent<Rigidbody>().velocity = Vector3.up * velocity;
        }
            //transform.position = pos;



    }
}
