using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {
    public GameObject Player;
    private Vector3 distance;
    private Vector3 test;
	void Start ()
    {
        test = transform.position;
        distance = transform.position - Player.transform.position;

	}
	
	// Update is called once per frame
	void Update ()
    {
        test.y = Player.transform.position.y + distance.y;
        test.x = Player.transform.position.x + distance.x;
        transform.position = test;
	}
}
