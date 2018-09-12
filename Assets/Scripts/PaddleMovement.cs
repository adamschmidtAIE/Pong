using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

    public float playerNumber;
    public float moveSpeed;

    float moveInput;

    Rigidbody2D rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveInput = Input.GetAxis("Vertical" + playerNumber.ToString());
	}

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.up * moveInput * moveSpeed);
    }
}
