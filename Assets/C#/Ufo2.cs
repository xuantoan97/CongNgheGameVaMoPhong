using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo2 : MonoBehaviour
{

	// Use this for initialization
	public GameObject laserufo;
	private GameObject ship;
	public GameObject explor;

	//thời gian giữa các lần bắn
	static float delay=50;
	//hp
	private int HP;
	//các thuộc tính điều khiển chuyển động của ufo
	private static bool MaxY = false;
	private  bool Bienx = false;
	private float bien;
	public static int SL = 0;

	//vận tốc
	public float movespeed;

	//vị trí cũ,ở thời điểm trước đó
	Vector3 oldpos;
	void Start()
	{
		HP = 2;
		ship = GameObject.FindGameObjectWithTag("ship");
	
	}

	// Update is called once per frame
	void Update()
	{
		if(GameController.Pause==false)
		{
		delay--;
		if (delay == 0)
		{
			GameObject laser = Instantiate(laserufo, new Vector3(transform.position.x, transform.position.y - 1f, 0), Quaternion.identity) as GameObject;
			laser.GetComponent<LaserUfo>().target = Random.Range(-2f, 2f);
			delay = 25;
		}
		if (MaxY == false)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f * movespeed, 0);
			bien = Random.Range(6f, 9f);
			if (transform.position.y <= bien)
			{
				MaxY = true;

			}
		}
		if (MaxY == true)
		{

			if (Bienx == false)
			{
				transform.position = new Vector3(transform.position.x + 0.01f * movespeed, transform.position.y, 0);
				if (transform.position.x >= 15f)
				{
					Bienx = true;
					GameController.appear = false;
				}
			}
			if (Bienx == true)
			{
				transform.position = new Vector3(transform.position.x - 0.01f * movespeed, transform.position.y, 0);
				if (transform.position.x <= -15f)
				{
					Bienx = false;
				}
			}
		}
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject != GameObject.FindGameObjectWithTag("ship"))
		{
			Destroy(collision.gameObject);
		}
		HP--;
		if (HP == 0)
		{
			Destroy(gameObject);
		}
	}
	private void OnDestroy()
	{
		SL++;
		WallController.create = true;
		Ufo2.MaxY = false;
		GameObject exp = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
		Destroy(exp, 0.25f);
	}
}
