using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGunProperties : MonoBehaviour {

    [SerializeField] private GameObject bulletPrefab;
    private GameObject bullet;

    float currentDir = 1;

	void Start () {
	}

	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            bullet = Instantiate(bulletPrefab) as GameObject;
            bullet.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, 0);
            Bullets bulletStuff = bullet.GetComponent<Bullets>();
            bulletStuff.GetDirection(currentDir);
        }
	}

    public void GetDirection(float dir) {
        if (Input.GetAxis("Horizontal") != 0) { 
            currentDir = dir;
        }
    }
}
