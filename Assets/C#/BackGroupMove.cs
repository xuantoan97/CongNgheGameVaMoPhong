using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroupMove : MonoBehaviour {

	// Use this for initialization
	public float Movespeed;
	public float MoveRange;
	private GameObject obj;
	private Vector3 oldpos;
	
	void Start () {
		obj=gameObject;
		oldpos = obj.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		obj.transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f * Movespeed,0);
		if (Vector3.Distance(oldpos, obj.transform.position) > MoveRange)
		{
			obj.transform.position = oldpos;
		}
	}
}
