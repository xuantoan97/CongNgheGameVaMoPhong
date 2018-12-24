using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	// Use this for initialization
	//vận tốc
	public float movespeed = 25;
	public GameObject obj;
	public float huongcualaser;
	
	void Start () {
		obj=gameObject;
		Destroy(obj, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.Pause == false)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f * movespeed * huongcualaser, 0);
		}
		}
	
}
