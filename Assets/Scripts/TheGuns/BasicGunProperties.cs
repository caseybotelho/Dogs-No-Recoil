using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGunProperties : MonoBehaviour {

	float sens = 20.0f;

	void Start () {
	}

	void Update () {
		Vector3 target = Input.mousePosition;
		transform.right = target - transform.position;
	}
}
