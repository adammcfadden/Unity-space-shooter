using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public Rigidbody rb;
    public float tumble;

	// Use this for initialization
	void Start () {
        rb.angularVelocity = Random.insideUnitSphere * tumble;	
	}
	
}
