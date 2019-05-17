using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControls : MonoBehaviour {

    public float speed = .5f;
    public float velocity = 25f;
    public bool started = false;
    public bool launched = false;
    public Animator launcher;
    public string launch;
    [ReadOnlyField]
    public float timer;
	
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
        if (started && !launched)
        {
            timer += Time.deltaTime;
        }
        if (!started && Input.GetKeyDown(KeyCode.Space))
        {            
            started = true;
            launcher.Play(launch);
        }
        if (timer >= 1.85)
        {
            timer = 0;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().velocity = Vector3.up * velocity;
            launched = true;
        }
    }
}
