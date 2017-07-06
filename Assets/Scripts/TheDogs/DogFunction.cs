using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFunction : MonoBehaviour {


    private float speed = 6.0f;
    private float jumpHeight = 4.0f;

    private Rigidbody2D body;
    private CharacterController dog;

    private Vector3 lastPos;


	void Start () {
        body = GetComponent<Rigidbody2D>();

        if (body) {
            body.freezeRotation = true;
        }

        dog = GetComponent<CharacterController>();
	}
	
	void FixedUpdate () {
        float movX = Input.GetAxis("Horizontal") * speed;

        Vector3 movement = new Vector3(movX, 0, 0);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        transform.Translate(movement);

        lastPos = transform.position;
        Debug.Log(Input.GetAxis("Jump"));
        if (Input.GetAxis("Jump") != 0) {
            transform.Translate(0, Input.GetAxis("Jump"), 0);
        }
	}

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.transform.gameObject.layer == 8) {
            
        }
        Debug.Log(collision.transform.gameObject.layer);

        if (collision.transform.gameObject.layer == 9) {
        }
    }

}
