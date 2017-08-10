using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaders : MonoBehaviour {

    [SerializeField] private GameObject dog;

    Vector3 rot;

    private bool talking = true;
    float min = -.005f;
    float max = .005f;
    float mid = 0f;

	void Start () {
        rot = transform.rotation.eulerAngles;
	}

	void Update () {
        if (dog.transform.position.x < transform.position.x) {
            rot.y = 180f;
            transform.rotation = Quaternion.Euler(rot);
        } else {
            rot.y = 0;
            transform.rotation = Quaternion.Euler(rot);
        }

        if (talking) {
            transform.Translate(0, Mathf.Lerp(min, max, mid), 0);
            mid += 0.005f;
            if (mid > .05f) {
                float temp = max;
                max = min;
                min = temp;
                mid = 0;
            }
        }
	}
}
