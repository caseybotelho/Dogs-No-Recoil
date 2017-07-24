using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private Camera camera;
    [SerializeField] private GameObject dog;

	void Start () {
        camera = GetComponent<Camera>();
	}
	
	void Update () {
        transform.position = new Vector3(dog.transform.position.x, dog.transform.position.y, -10);
	}
}
