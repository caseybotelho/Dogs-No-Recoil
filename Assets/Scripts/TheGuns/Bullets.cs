using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	private GameController controller;

    public float speed = 20.0f;

    public float currentDir = 1;

    public string type = "default";

	IEnumerator Start() {
		controller = Object.FindObjectOfType<GameController>();

		yield return new WaitForSeconds (2.0f);

		Destroy (this.gameObject);
        if (type == "default") {
            controller.Destroyed();
        }
	}

	void Update () {
        transform.Translate(currentDir * speed * Time.deltaTime, 0, 0);
	}

    public void GetDirection(float dir) {
        currentDir = dir;
        Debug.Log(currentDir);
    }
		
}
