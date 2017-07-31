using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private Camera mainCamera;
    [SerializeField] private GameObject dog;

	void Start () {
        mainCamera = GetComponent<Camera>();
	}
	
	void Update () {
        float vert = Mathf.Clamp(dog.transform.position.y, -1.030516f, 40.0f);
        transform.position = new Vector3(dog.transform.position.x, vert, -10);
	}
}
