using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour {

	// Use this for initialization
	private Animator anim;
	public GameObject explor;
	public GameObject laser;
	private bool xuathien = true;
	private bool bien = false;
	private bool dichuyenxuong = true;
	private static int doidichuyen;
	private int delay;
	private int HP;
	public float movespeed;
	private AudioSource audioSource;
	public AudioClip soundlaser;
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		audioSource = gameObject.GetComponent<AudioSource>();
		anim.SetTrigger("nottrungdan");
		HP = 30;
		doidichuyen = 0;
		delay = 50;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetTrigger("nottrungdan");
		if (GameController.Pause == false)
		{
			delay--;
			if (xuathien == true && dichuyenxuong == true)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * movespeed * 0.5f, 0);
				if (transform.position.y <= -7)
				{
					xuathien = false;
					GameController.appear = false;
				}
			}
			if (xuathien == true && dichuyenxuong == false)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * movespeed, 0);
				if (transform.position.y >= 7)
				{
					xuathien = false;
				}
			}
			if ((doidichuyen <= -2) && delay <= 0)
			{
				audioSource.clip = soundlaser;
				audioSource.Play();
				GameObject ls1 = Instantiate(laser, new Vector3(transform.position.x, transform.position.y - 3f, 0), Quaternion.identity);
				ls1.GetComponent<LaserUfo>().target = 0;
				GameObject ls2 = Instantiate(laser, new Vector3(transform.position.x, transform.position.y - 3f, 0), Quaternion.identity);
				ls2.GetComponent<LaserUfo>().target = -8;
				GameObject ls3 = Instantiate(laser, new Vector3(transform.position.x, transform.position.y - 3f, 0), Quaternion.identity);
				ls3.GetComponent<LaserUfo>().target = 8;
				delay = 50;
			}

			if (bien == false && xuathien == false)
			{
				transform.position = new Vector3(transform.position.x + Time.deltaTime * movespeed, transform.position.y, 0);
				if (transform.position.x >= 14)
				{
					bien = true;
					doidichuyen++;
				}
			}
			if (bien == true && xuathien == false)
			{
				transform.position = new Vector3(transform.position.x - Time.deltaTime * movespeed, transform.position.y, 0);
				if (transform.position.x <= -14)
				{
					bien = false;
					doidichuyen++;
				}
			}
			if (doidichuyen == 2)
			{
				xuathien = true;
				dichuyenxuong = false;
				doidichuyen = -4;
			}
			if (doidichuyen == -2)
			{
				xuathien = true;
				dichuyenxuong = true;
				doidichuyen = 0;
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		anim.SetTrigger("trungdan");
		if (collision.gameObject != GameObject.FindGameObjectWithTag("ship"))
		{
			Destroy(collision.gameObject);
		}
		HP--;
		if (HP <= 0)
		{
			Destroy(gameObject);
		}
	}
	private void OnDestroy()
	{
		GameObject ex = Instantiate(explor,transform.position,Quaternion.identity);
		Destroy(ex, 0.25f);
			GameController.screen = 4;
			GameController.appear = true;
			WallController.create = true;
	}
}
