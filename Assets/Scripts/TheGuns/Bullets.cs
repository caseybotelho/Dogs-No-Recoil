using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	private GameController controller;

    private float speed = 20.0f;

    public float currentDir = 1;

	IEnumerator Start() {
		controller = Object.FindObjectOfType<GameController>();

		yield return new WaitForSeconds (2.0f);

		Destroy (this.gameObject);
		controller.Destroyed ();
	}

	void Update () {
        transform.Translate(currentDir * speed * Time.deltaTime, 0, 0);
	}

    public void GetDirection(float dir) {
        currentDir = dir;
        Debug.Log(currentDir);
    }
		
}
