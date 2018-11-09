using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//tự hủy sau 0.25s
		Destroy(gameObject, 0.25f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
