using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    private float speed = 20.0f;

    public float currentDir = 1;

    void Start () {
        LifeSpan();
	}
	
	void Update () {
        transform.Translate(currentDir * speed * Time.deltaTime, 0, 0);
	}

    public void GetDirection(float dir) {
        currentDir = dir;
        Debug.Log(currentDir);
    }

    private IEnumerator LifeSpan() {

        speed = 2.0f;

        yield return new WaitForSeconds(2.0f);

        Destroy(this.gameObject);
    }
}
