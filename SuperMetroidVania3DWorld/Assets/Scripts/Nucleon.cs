using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucleon : MonoBehaviour {

    public float attractionForce;

    Rigidbody body;

    void Awake ()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        body.AddForce(transform.localPosition * -attractionForce);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
