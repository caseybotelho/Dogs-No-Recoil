﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private Camera mainCamera;
    [SerializeField] private GameObject dog;

	void Start () {
        mainCamera = GetComponent<Camera>();
	}
	
	void Update () {
        float vert = Mathf.Clamp(dog.transform.position.y, 1.17f, 40.0f);
        float hor = Mathf.Clamp(dog.transform.position.x, -20.15f, 2.25f);
        transform.position = new Vector3(hor, vert, -10);
	}
}
