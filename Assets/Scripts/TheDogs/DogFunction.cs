using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFunction : MonoBehaviour {

    private const float defaultSpeed = 6.0f;
    private float speed;
    private float jumpForceY = 8.0f;
    private float jumpForceX = 5.5f;

    float currentDir = 1;
    float lastDir = 1;

    [SerializeField] private GameObject jumpTrigger;
	CheckGround checkGround;
    private bool grounded = true;
    private bool currentState;

    private Rigidbody2D body;

    private GameObject gun;
    private BasicGunProperties gunStuff;

    public bool rolling;

    [SerializeField] private GameObject breed;
    public Animator runAnim;

	void Start () {
        body = GetComponent<Rigidbody2D>();

        if (body) {
            body.freezeRotation = true;
        }

        gun = this.transform.Find("Gun").gameObject;
        gunStuff = gun.GetComponent<BasicGunProperties>();

		checkGround = jumpTrigger.GetComponent<CheckGround>();

        currentState = grounded;

        speed = defaultSpeed;

        runAnim = breed.GetComponent<Animator>();
    }
	
	void FixedUpdate () {

		if (Input.GetAxis("Horizontal") != 0 && grounded) {
			runAnim.SetBool ("Running", true);
		}

		if (Input.GetAxis("Horizontal") == 0 || !grounded) {
			runAnim.SetBool ("Running", false);
		}

        grounded = checkGround.grounded;

        float movX = Input.GetAxis("Horizontal") * speed;

        Vector3 movement = new Vector3(movX, 0, 0);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

		if (grounded && !rolling) {
			transform.Translate (movement);
		}
			
        
        if (movX != 0 && grounded && speed != 0 && !rolling) {
            currentDir = Mathf.Sign(movX);
            if (lastDir != currentDir) { 
                transform.Rotate(0, 180f, 0);
                lastDir = currentDir;
                gunStuff.GetDirection(currentDir);
            }
        }

        if (Input.GetAxis("Jump") != 0 && grounded && speed != 0) {
            speed = 0;
            Jump();
        }

        if (currentState != grounded) {
            runAnim.SetBool("Jumping", true);
            if (grounded) {
                Land();
            } else {
                currentState = grounded;
            }
        }

    }

    private void Jump() {

        body.AddForce(new Vector2(jumpForceX * currentDir, jumpForceY), ForceMode2D.Impulse);
    }

    private void Land() {

        speed = defaultSpeed;

        currentState = grounded;
        runAnim.SetBool("Jumping", false);
    }
}
