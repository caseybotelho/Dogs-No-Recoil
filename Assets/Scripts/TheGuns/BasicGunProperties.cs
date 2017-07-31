using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGunProperties : MonoBehaviour {

    // grabbing necesssary objects
    [SerializeField] private GameObject GameController;
    [SerializeField] private GameObject dog;

    // readies bullet storage
    [SerializeField] private GameObject bulletPrefab;
    private GameObject bullet;

    // sets max bullets on screen for default fire
	public int bulletTotal = 0;
	private int bulletMax = 10;

    // current direction of dog/gun
    float currentDir = 1;

    // button checks
    private bool w = false;
    private int w_ = 0;
    private bool a = false;
    private int a_ = 0;
    private bool s = false;
    private int s_ = 0;
    private bool d = false;
    private int d_ = 0;

    // ability checks. rolling causes cooldown on all tricks
    private bool rolling;
    private float rollCool = 10.0f;
    private bool canTrick = true;

	void Update () {
        // bark!
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("bark!");
        }

        // checks and stores inputs made while fire button is held
        if (Input.GetMouseButton(0)) {
            if (Input.GetKeyDown(KeyCode.W)) {
                w = true;
                w_++;
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                a = true;
                a_++;
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                s = true;
                s_++;
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                d = true;
                d_++;
            }
        }

        // initiates gun fire
		if (Input.GetMouseButtonUp(0)) {
            // checks if roll trick requirements have been met
            if (w && a && s && d && rolling == false && canTrick) {
                rolling = true;
                dog.GetComponent<DogFunction>().rolling = true;

                // sets trick cooldown to start
                canTrick = false;
                dog.GetComponent<DogFunction>().runAnim.SetBool("Rolling", true);
                StartCoroutine(Rolling());
                KeyReset();
            }
            // checks if shake trick requirements have been met
            else if (a_ >= 2 && d_ >= 2 && rolling == false && canTrick) { 
                for (int j = 0; j < 40; j++) {
                    bullet = Instantiate(bulletPrefab) as GameObject;
                    Bullets bulletStuff = bullet.GetComponent<Bullets>();
                    bulletStuff.type = "shake";
                    bullet.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, 0);
                    float bulletRot = Random.Range(0, 360);
                    bullet.transform.Rotate(0, 0, bulletRot);
                    bulletStuff.speed = Random.Range(5, 15);
                }
                KeyReset();
            }
            else if (w_ >= 2) {
                Debug.Log("walk");
            }
            // default fire mode if trick requirements not met
            else {
			    if (bulletTotal < bulletMax && rolling == false) {
			    	bullet = Instantiate (bulletPrefab) as GameObject;
                    Bullets bulletStuff = bullet.GetComponent<Bullets>();
                    bullet.transform.position = new Vector3 (this.transform.position.x + 1, this.transform.position.y, 0);
			    	bulletStuff.GetDirection (currentDir);
			    	bulletTotal++;
			    }
                KeyReset();
            }
		}

        if (!canTrick) {
            rollCool -= Time.deltaTime;
            if (rollCool <= 0) {
                rollCool = 10.0f;
                canTrick = true;
            }
        }
	}

    public void GetDirection(float dir) {
        if (Input.GetAxis("Horizontal") != 0) { 
            currentDir = dir;
        }
    }

	public void Reload() {
		bulletTotal--;
		Debug.Log (bulletTotal);
	}

    private IEnumerator Rolling() {
        for (int i = 0; i < 4; i++) { 
            for (int j = 0; j < 20; j++) {
                bullet = Instantiate(bulletPrefab) as GameObject;
                Bullets bulletStuff = bullet.GetComponent<Bullets>();
                bulletStuff.type = "shake";
                bullet.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, 0);
                bullet.transform.Rotate(0, 0, j * 18);
                bulletStuff.speed = (5);
            }
            yield return new WaitForSeconds(0.75f);
        }
        dog.GetComponent<DogFunction>().runAnim.SetBool("Rolling", false);
        rolling = false;
        dog.GetComponent<DogFunction>().rolling = false;
    }

    private void KeyReset() {
        w = false;
        w_ = 0;
        a = false;
        a_ = 0;
        s = false;
        s_ = 0;
        d = false;
        d_ = 0;
    }
}
