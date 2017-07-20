using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField] private GameObject gun;
	private BasicGunProperties gunPlay;

	public void Destroyed() {
		gunPlay = gun.GetComponent<BasicGunProperties> ();

		gunPlay.Reload ();
	}
}
