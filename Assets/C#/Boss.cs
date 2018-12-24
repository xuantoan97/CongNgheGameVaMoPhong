using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

	// Use this for initialization
	//animation 
	private Animator anim;
	public GameObject explor;
	//máu
	private static int HP;
	//vấn tốc
	public float movespeed;
	//kiểm tra biên
	private static bool bien = false;
	private static bool bien1 = false;
	//kiểm tra lúc mới xuất hiện
	private static bool xuathien1 = true;
	//laser-blue
	public GameObject laserblue;
	//laser
	public GameObject laser;
	//thời gian delay
	private static int delay;
	public AudioClip laserufo;
	private AudioSource audioSource;
	public static bool IsLive= true;
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		anim.SetTrigger("nottrungdan");
		HP = 50;
		delay = 500;
		audioSource = gameObject.GetComponent<AudioSource>();
		IsLive = true;
	}

	// Update is called once per frame
	void Update() {
		anim.SetTrigger("nottrungdan");
		if (GameController.Pause == false)
		{
			delay--;
			if (bien1 == false)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f * movespeed, 0);
				if (transform.position.y <= 5)
				{
					bien1 = true;
					GameController.appear = false;
				}
			}
			if (bien1 == true)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f * movespeed, 0);
				if (transform.position.y >= 11)
				{
					bien1 = false;
				}
			}
			if (delay == 500 || delay == 400 || delay == 300 || delay == 200 || delay == 100)
			{
				if (GameController.Pause == false)
				{
					audioSource.clip = laserufo;
					audioSource.Play();
					GameObject lsb1 = Instantiate(laserblue, new Vector3(transform.position.x, transform.position.y - 4.2f, 0), Quaternion.identity);
					lsb1.GetComponent<LaserUfo>().target = -15f;
					GameObject lsb2 = Instantiate(laserblue, new Vector3(transform.position.x, transform.position.y - 4.2f, 0), Quaternion.identity);
					lsb2.GetComponent<LaserUfo>().target = -9f;
					GameObject lsb3 = Instantiate(laserblue, new Vector3(transform.position.x, transform.position.y - 4.2f, 0), Quaternion.identity);
					lsb3.GetComponent<LaserUfo>().target = -3f;
					GameObject lsb4 = Instantiate(laserblue, new Vector3(transform.position.x, transform.position.y - 4.2f, 0), Quaternion.identity);
					lsb4.GetComponent<LaserUfo>().target = 3f;
					GameObject lsb5 = Instantiate(laserblue, new Vector3(transform.position.x, transform.position.y - 4.2f, 0), Quaternion.identity);
					lsb5.GetComponent<LaserUfo>().target = 9f;
					GameObject lsb6 = Instantiate(laserblue, new Vector3(transform.position.x, transform.position.y - 4.2f, 0), Quaternion.identity);
					lsb6.GetComponent<LaserUfo>().target = 15f;
				}
			}
			if (delay <= 0 && GameController.Pause == false)
			{
				audioSource.clip = laserufo;
				audioSource.Play();
				GameObject ls = Instantiate(laser, new Vector3(transform.position.x, transform.position.y - 3.5f, 0), Quaternion.identity);
				ls.GetComponent<LaserUfo>().target = Random.Range(-15f, 15f);
				if (delay <= -50)
				{
					delay = 550;
				}
			}
			if (bien == false)
			{
				transform.position = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y, 0);
				if (transform.position.x <= -12)
				{
					bien = true;
				}
			}
			if (bien == true)
			{
				transform.position = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y, 0);
				if (transform.position.x >= 12)
				{
					bien = false;
				}
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
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(collision.gameObject);
	}
	private void OnDestroy()
	{
		GameObject ex = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
		Destroy(ex, 0.25f);
		IsLive = false;
		GameController.Restart = false;
	}
}
