using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

    public bool grounded = true;

    private int colEnter = 0;
    private int colExit = 1;

    void OnTriggerEnter2D(Collider2D otherEnter) {
        if (otherEnter.gameObject.layer == LayerMask.NameToLayer("Floor")) { 
            grounded = true;
            colEnter++;
		}
    }

    void OnTriggerExit2D(Collider2D otherExit) {
        if (otherExit.gameObject.layer == LayerMask.NameToLayer("Floor")) {
            colExit++;
            if (colExit > colEnter) {
                grounded = false;
            }
		}
    }


}
