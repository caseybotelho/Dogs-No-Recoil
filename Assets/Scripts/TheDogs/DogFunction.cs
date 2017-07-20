using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFunction : MonoBehaviour {

    private float speed = 6.0f;
    private float jumpHeight = 8.0f;

    float currentDir = 1;

    private Rigidbody2D body;
    private CharacterController dog;

    private GameObject gun;
    private BasicGunProperties gunStuff;

    float lastDir = 1;
    

	void Start () {
        body = GetComponent<Rigidbody2D>();

        if (body) {
            body.freezeRotation = true;
        }

        dog = GetComponent<CharacterController>();
        gun = this.transform.Find("Gun").gameObject;
        gunStuff = gun.GetComponent<BasicGunProperties>();
    }
	
	void FixedUpdate () {
        float movX = Input.GetAxis("Horizontal") * speed;

        Vector3 movement = new Vector3(movX, 0, 0);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        transform.Translate(movement);
        
        if (movX != 0) {
            currentDir = Mathf.Sign(movX);
            if (lastDir != currentDir) { 
                transform.Rotate(0, 180f, 0);
                lastDir = currentDir;
                gunStuff.GetDirection(currentDir);
            }
        }

        if (Input.GetAxis("Jump") != 0) {
			float jump = jumpHeight * Time.deltaTime;
			jump = Mathf.Clamp (jump, 0, jumpHeight);
			transform.Translate (0, jump, 0);
        }

    }

}
