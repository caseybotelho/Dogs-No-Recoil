using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaders : MonoBehaviour {

    [SerializeField] private GameObject dog;

    Vector3 rot;

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

        }
	}
}
