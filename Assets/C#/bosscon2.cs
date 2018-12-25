using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosscon2 : MonoBehaviour {

	// Use this for initialization
	public GameObject explor;
	public float movespeed;
	public  int delay;
	public  bool bien ;
	public GameObject laser;
	public static int SL = 6;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.Pause == false)
		{
			delay--;
			if (delay <= 0)
			{

				GameObject ls = Instantiate(laser, new Vector3(transform.position.x, transform.position.y - 1.5f, 0), Quaternion.identity) as GameObject;
				ls.GetComponent<Laser>().huongcualaser = -1;
				delay = 40;
			}
			if (bien == false)
			{
				transform.position = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y, 0);
				if (transform.position.x >= 15f)
				{
					bien = true;
				}
			}
			if (bien == true)
			{
				transform.position = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y, 0);
				if (transform.position.x <= -15f)
				{
					bien = false;
				}
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		SL--;
		Destroy(collision.gameObject);
		Destroy(gameObject);
	}
	private void OnDestroy()
	{
		
			GameObject ex = Instantiate(explor, transform.position, Quaternion.identity);
			Destroy(ex, 0.25f);
		
	}
}
