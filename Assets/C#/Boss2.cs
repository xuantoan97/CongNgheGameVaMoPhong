using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour {

	// Use this for initialization
	private Animator anim;
	public GameObject explor;
	public GameObject laser;
	public GameObject bosscon;
	private GameObject obj;
	private int HP;
	public float movespeed;
	private  bool xuathien = true;
	private  bool bien = false;
	private int delay;
	private bool tontaibosscon =false;
	public AudioClip laserufo;
	private AudioSource audioSource;
	void Start () {
		
		obj = gameObject;
		anim = obj.GetComponent<Animator>();
		anim.SetTrigger("nottrungdan");
		audioSource = obj.GetComponent<AudioSource>();
		HP = 50;
		delay = 600;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetTrigger("nottrungdan");
		if (GameController.Pause == false)
		{
			delay--;
			if (xuathien == true)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * movespeed * 0.5f, 0);
				if (transform.position.y <= 5)
				{
					xuathien = false;
					GameController.appear = false;
				}
			}
			if (delay % 60 == 0 && delay > 0)
			{

				GameObject rk1 = Instantiate(laser, new Vector3(transform.position.x - 7f, transform.position.y - 2f, 0), Quaternion.identity);
				GameObject rk2 = Instantiate(laser, new Vector3(transform.position.x - 3.5f, transform.position.y - 3.5f, 0), Quaternion.identity);
				GameObject rk3 = Instantiate(laser, new Vector3(transform.position.x, transform.position.y - 6f, 0), Quaternion.identity);
				GameObject rk4 = Instantiate(laser, new Vector3(transform.position.x + 3.5f, transform.position.y - 3.5f, 0), Quaternion.identity);
				GameObject rk5 = Instantiate(laser, new Vector3(transform.position.x + 7f, transform.position.y - 2f, 0), Quaternion.identity);
			}
			if (delay <= 0 && tontaibosscon == false)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * movespeed, 0);
				if (transform.position.y >= 11)
				{
					GameObject bc1 = Instantiate(bosscon, new Vector3(transform.position.x - 5f, transform.position.y - 6f, 0), Quaternion.identity) as GameObject;
					bc1.GetComponent<bosscon2>().bien = true;
					bc1.GetComponent<bosscon2>().delay = 30;
					GameObject bc2 = Instantiate(bosscon, new Vector3(transform.position.x + 5f, transform.position.y - 6f, 0), Quaternion.identity) as GameObject;
					bc2.GetComponent<bosscon2>().bien = false;
					bc2.GetComponent<bosscon2>().delay = 40;
					GameObject bc3 = Instantiate(bosscon, new Vector3(transform.position.x + 5f, transform.position.y - 6f, 0), Quaternion.identity) as GameObject;
					bc3.GetComponent<bosscon2>().bien = true;
					bc3.GetComponent<bosscon2>().delay = 50;
					GameObject bc4 = Instantiate(bosscon, new Vector3(transform.position.x + 2.5f, transform.position.y - 6f, 0), Quaternion.identity) as GameObject;
					bc4.GetComponent<bosscon2>().bien = false;
					bc4.GetComponent<bosscon2>().delay = 60;
					GameObject bc5 = Instantiate(bosscon, new Vector3(transform.position.x, transform.position.y - 6f, 0), Quaternion.identity) as GameObject;
					bc5.GetComponent<bosscon2>().bien = true;
					bc5.GetComponent<bosscon2>().delay = 70;
					GameObject bc6 = Instantiate(bosscon, new Vector3(transform.position.x - 5, transform.position.y - 6f, 0), Quaternion.identity) as GameObject;
					bc6.GetComponent<bosscon2>().bien = false;
					bc6.GetComponent<bosscon2>().delay = 80;
					tontaibosscon = true;

				}
			}
			if (bosscon2.SL <= 0)
			{
				tontaibosscon = false;
				xuathien = true;
				delay = 600;
				bosscon2.SL = 6;
			}
			if (bien == false && xuathien == false)
			{
				transform.position = new Vector3(transform.position.x - Time.deltaTime * movespeed, transform.position.y, 0);
				if (transform.position.x <= -8)
				{
					bien = true;
				}
			}
			if (bien == true && xuathien == false)
			{
				transform.position = new Vector3(transform.position.x + Time.deltaTime * movespeed, transform.position.y, 0);
				if (transform.position.x >= 8)
				{
					bien = false;
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
		if (tontaibosscon == false)
		{
			HP--;
			anim.SetTrigger("trungdan");
		}
		if (HP <= 0)
		{
			Destroy(gameObject);
		}
	}
	private void OnDestroy()
	{
			
			GameObject ex = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
			Destroy(ex, 0.25f);
			GameController.appear = true;
			GameController.screen = 3;
			WallController.create = true;
	}
}
