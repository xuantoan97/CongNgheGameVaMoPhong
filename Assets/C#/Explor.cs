using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explor : MonoBehaviour {

	// Use this for initialization
	public AudioClip explor;
	private AudioSource audioSource;
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = explor;
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject, 0.25f);
	}
	
}
