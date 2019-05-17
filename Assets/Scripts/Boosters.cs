using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosters : MonoBehaviour {
    private bool isUsed = false;
   

    private void OnTriggerEnter(Collider other)
    {
        if(!isUsed && other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * other.gameObject.GetComponent<TestControls>().velocity;
            isUsed = true;
            gameObject.SetActive(false);
        }
    }
}
