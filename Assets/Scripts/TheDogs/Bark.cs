using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour {

    private SpriteRenderer mouth;

    private const int arraySize = 5;
    [SerializeField] AudioClip[] barks = new AudioClip[arraySize];
    private AudioSource woofer;
    private int whichBark;

	void Start () {
        mouth = GetComponent<SpriteRenderer>();

        woofer = GetComponent<AudioSource>();
    }
	
	void Update () {
		if (Input.GetMouseButtonDown(1) && !mouth.enabled) {
            whichBark = Random.Range(0, 4);
            woofer.clip = barks[whichBark];
            StartCoroutine(Barking(whichBark));
        }
	}

    private IEnumerator Barking(int theBark) {
        mouth.enabled = true;
        woofer.Play();

        yield return new WaitForSeconds(.1f);

        mouth.enabled = false;
    }
}
