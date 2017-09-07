using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

	[SerializeField] private GameObject dogs;

    [SerializeField] private GameObject n;
    [SerializeField] private GameObject o;
    [SerializeField] private GameObject r;
    [SerializeField] private GameObject e;
    [SerializeField] private GameObject c;
    [SerializeField] private GameObject o_;
    [SerializeField] private GameObject i;
    [SerializeField] private GameObject l;

	private AudioSource noise;

	private const int arraySize = 2;
	[SerializeField] AudioClip[] noises = new AudioClip[arraySize];

	void Start () {
		StartCoroutine (Title ());

		noise = GetComponent<AudioSource>();
		noise.clip = noises [0];
	}
	
	void Update () {
		
	}

	private IEnumerator Title() {
		yield return new WaitForSeconds (1.0f);
		dogs.SetActive (true);
		noise.Play ();

		yield return new WaitForSeconds (2.0f);
		noise.clip = noises [1];
		n.SetActive (true);
		noise.Play ();

		yield return new WaitForSeconds (0.25f);
		o.SetActive (true);
		noise.Play ();

		yield return new WaitForSeconds (0.25f);
		r.SetActive (true);
		noise.Play ();

		yield return new WaitForSeconds (0.25f);
		e.SetActive (true);
		noise.Play ();

		yield return new WaitForSeconds (0.25f);
		c.SetActive (true);
		noise.Play ();

		yield return new WaitForSeconds (0.25f);
		o_.SetActive (true);
		noise.Play ();

		yield return new WaitForSeconds (0.25f);
		i.SetActive (true);
		noise.Play ();

		yield return new WaitForSeconds (0.25f);
		l.SetActive (true);
		noise.Play ();
	}

}
