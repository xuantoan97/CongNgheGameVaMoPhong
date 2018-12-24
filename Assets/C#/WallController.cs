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
	private int deley;
	void Start ()
	{
		deley = 100;
		GameObject s = Instantiate(ship, new Vector3(transform.position.x, transform.position.y - 35, 0), Quaternion.identity) as GameObject;
		create = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		deley--;
		//tạo ufo2
		//if (man == GameController.ManCHoi.Man1 && GameController.man1 == true && GameController.SLufo <= 2)
		//{

		//	GameObject u = Instantiate(ufo2, new Vector3(transform.position.x + Random.Range(-15f, 15), transform.position.y - 3, 0), Quaternion.identity) as GameObject;
		//	GameController.man1 = false;

		//}
		////ufo 
		//if (GameController.SLufo > 2 && Ufo.xuathien == true)
		//{

		//	GameObject u = Instantiate(ufo, new Vector3(transform.position.x, transform.position.y - 5, 0), Quaternion.identity) as GameObject;
		//	Ufo.xuathien = false;

		//if (GameController.Restart == true&&deley<=0)
		//{
		//	GameObject s = Instantiate(ship, new Vector3(transform.position.x, transform.position.y - 35, 0), Quaternion.identity) as GameObject;
		//	create = true;
		//	GameController.Restart = false;
		//	deley = 100;
		//}
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
