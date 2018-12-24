using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserUfo : MonoBehaviour {

	// Use this for initialization
	public float target;
	//vận tốc
	public float movespeed;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate((transform.position - target) * movespeed * Time.deltaTime * -1);
		if (GameController.Pause == false)
		{
			transform.position = new Vector3(transform.position.x + Time.deltaTime * target, transform.position.y - Time.deltaTime * movespeed, 0);
			Destroy(gameObject, 2f);
		}
		}
	
}
