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

	//các thuộc tính điều khiển chuyển động của ufo
	private static bool MaxY = false;
	private  bool Bienx = false;
	private float bien;

	//vận tốc
	public float movespeed;

	//vị trí cũ,ở thời điểm trước đó
	Vector3 oldpos;
	void Start()
	{
		ship = GameObject.FindGameObjectWithTag("ship");
	
	}

	// Update is called once per frame
	void Update()
	{
		delay--;
		if (delay == 0)
		{
			GameObject laser = Instantiate(laserufo, new Vector3(transform.position.x, transform.position.y - 1f, 0), Quaternion.identity) as GameObject;
			laser.GetComponent<LaserUfo>().target = Random.Range(-2f, 2f);
			Destroy(laser, 2.0f);
			delay = 25;
		}
		if (MaxY == false)
		{
			transform.position = new Vector3(transform.position.x , transform.position.y - 0.01f * movespeed, 0);
			bien = Random.Range(6f,9f);
			if (transform.position.y <=bien)
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
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(collision.gameObject);
		Destroy(gameObject);
		GameController.man1 = true;
	}
	private void OnDestroy()
	{
		GameController.SLufo += 1;
		GameController.man1 = true;
		Ufo2.MaxY = false;
		GameObject exp = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
		Destroy(exp, 0.25f);
	}
}
