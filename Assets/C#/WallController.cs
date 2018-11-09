using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	// Use this for initialization
	GameController.ManCHoi man;
	//đối tượng ufo
	public GameObject ufo2;
	public GameObject ufo;
	
	void Start ()
	{
		//khởi tạo với màn chơi 1
		man = GameController.ManCHoi.Man1;

	}
	
	// Update is called once per frame
	void Update ()
	{
		//tạo ufo2
		if (man == GameController.ManCHoi.Man1&&GameController.man1==true&&GameController.SLufo<=2)
		{
			
			GameObject u = Instantiate(ufo2, new Vector3(transform.position.x+Random.Range(-15f,15), transform.position.y-3, 0), Quaternion.identity) as GameObject;
			GameController.man1 = false;

		}
		//ufo 
		if (GameController.SLufo > 2&&Ufo.xuathien==true)
		{

			GameObject u = Instantiate(ufo, new Vector3(transform.position.x , transform.position.y - 5, 0), Quaternion.identity) as GameObject;
			Ufo.xuathien = false;
			
		}
	}
}
