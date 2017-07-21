using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

    public bool grounded = true;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Floor")) { 
            grounded = true;
		}
		Debug.Log ("Test");
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Floor")) { 
            grounded = false;
		}
		Debug.Log ("Test");
    }
}
