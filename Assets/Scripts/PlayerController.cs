using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Vector2 moveVelocity;
    Rigidbody2D body;

    public float speed = 10f;


	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

		
	}

    private void FixedUpdate()
    {
        body.MovePosition(body.position + moveVelocity * Time.fixedDeltaTime);
    }


}
