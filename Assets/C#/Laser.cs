using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	// Use this for initialization
	//vận tốc
	public float movespeed = 25;
	public GameObject obj;
	void Start () {
		obj=gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f * movespeed, 0);
		}
	
}
