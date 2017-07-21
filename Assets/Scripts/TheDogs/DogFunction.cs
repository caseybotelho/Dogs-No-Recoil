using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFunction : MonoBehaviour {

    private float speed = 6.0f;
    private float jumpForce = 2.0f;

    float currentDir = 1;
    float lastDir = 1;

    [SerializeField] private GameObject jumpTrigger;
	CheckGround checkGround;
    private bool grounded = true;

    private Rigidbody2D body;
    private CharacterController dog;

    private GameObject gun;
    private BasicGunProperties gunStuff;
    

	void Start () {
        body = GetComponent<Rigidbody2D>();

        if (body) {
            body.freezeRotation = true;
        }

        dog = GetComponent<CharacterController>();
        gun = this.transform.Find("Gun").gameObject;
        gunStuff = gun.GetComponent<BasicGunProperties>();

		checkGround = jumpTrigger.GetComponent<CheckGround>();
    }
	
	void FixedUpdate () {

		grounded = checkGround.grounded;

        float movX = Input.GetAxis("Horizontal") * speed;

        Vector3 movement = new Vector3(movX, 0, 0);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
		if (grounded) {
			transform.Translate (movement);
		}
        
        if (movX != 0 && grounded) {
            currentDir = Mathf.Sign(movX);
            if (lastDir != currentDir) { 
                transform.Rotate(0, 180f, 0);
                lastDir = currentDir;
                gunStuff.GetDirection(currentDir);
            }
        }

        if (Input.GetAxis("Jump") != 0 && grounded) {
			body.AddForce(new Vector2(1.5f * currentDir, jumpForce), ForceMode2D.Impulse);
        }

    }

}
