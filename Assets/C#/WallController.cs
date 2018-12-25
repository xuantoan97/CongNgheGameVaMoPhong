using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	// Use this for initialization
	//đối tượng ufo
	public GameObject ufo2;
	public GameObject ufo;
	public GameObject boss;
	public GameObject boss2;
	public GameObject boss3;
	public GameObject ship;
	public GameObject boscon2;
	public GameController GameController;
	public static bool create;
	void Start ()
	{
		GameObject s = Instantiate(ship, new Vector3(transform.position.x, transform.position.y - 35, 0), Quaternion.identity) as GameObject;
		create = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (GameController.screen == 1&&create==true&&Ufo2.SL<5)
		{
			GameObject u = Instantiate(ufo2, new Vector3(transform.position.x, transform.position.y - 5, 0), Quaternion.identity) as GameObject;
			create = false;
		}
		if (GameController.screen == 1 && create == true && Ufo2.SL >= 5)
		{
			GameObject u = Instantiate(ufo, new Vector3(transform.position.x, transform.position.y - 5, 0), Quaternion.identity) as GameObject;
			create = false;
		}
		if (GameController.screen == 2 && create == true)
		{
			GameObject b2 = Instantiate(boss2, new Vector3(transform.position.x, transform.position.y - 5, 0), Quaternion.identity) as GameObject;
			create = false;
		}
		if (GameController.screen == 3 && create == true)
		{
			GameObject b3 = Instantiate(boss3, new Vector3(transform.position.x, transform.position.y - 5, 0), Quaternion.identity) as GameObject;
			create = false;
		}
		if (GameController.screen == 4 && create == true)
		{
			GameObject b = Instantiate(boss, new Vector3(transform.position.x, transform.position.y - 5, 0), Quaternion.identity) as GameObject;
			create = false;
		}
	}	

}
