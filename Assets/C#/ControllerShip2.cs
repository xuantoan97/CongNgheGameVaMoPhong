using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerShip2 : MonoBehaviour {

	// Use this for initialization
	//Vẫn tốc của ship
	public float movespeed = 15;
	//vị trí ở thời điểm trước đó của phi thuyển
	private Vector3 oldpos;
	//các đối tượng game
	public GameObject laser;
	//animation nổ
	public GameObject explor;
	private Animator anim;
	//khai báo đối tượng game của ship
	private GameObject obj;
	//biến kiểm tra xuất hiện
	public static bool XuatHien;
	private AudioSource audioSource;
	public AudioClip shoot;
	public AudioClip gameover;
	//mạng
	public static int Life;
	
	void Start () {
		obj = gameObject;
		XuatHien = true;
		audioSource = obj.GetComponent<AudioSource>();
		Life = 3;
		anim = gameObject.GetComponent<Animator>();
		anim.SetTrigger("nottrungdan");
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetTrigger("nottrungdan");
		//khi xuất hiện 
		if (XuatHien == true&&GameController.screen!=0)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, 0);
			if (transform.position.y >= -6)
			{
				XuatHien = false;
			}
		}
		//điều khiển phi thuyền

		if (Input.GetKeyDown(KeyCode.Space)==true && GameController.Pause == false)
		{
			audioSource.clip = shoot;
			audioSource.Play();
			  GameObject laserclone = Instantiate(laser, new Vector3(transform.position.x, transform.position.y+1f,0), Quaternion.identity) as GameObject;
				laserclone.GetComponent<Laser>().huongcualaser = 1;
		}
		if (Input.GetKey(KeyCode.W) && GameController.Pause == false)
		{
			oldpos = transform.position;
			transform.position = new Vector3(transform.position.x, transform.position.y +0.01f*movespeed, 0);
			if (transform.position.y >= 9.4f)
			{
				transform.position = oldpos;
			}
		}
		if (Input.GetKey(KeyCode.A) && GameController.Pause == false)
		{
			oldpos = transform.position;
			transform.position = new Vector3(transform.position.x - 0.01f * movespeed, transform.position.y , 0);
			if (transform.position.x <= -15.4f)
			{
				transform.position = oldpos;
			}
		}
		if (Input.GetKey(KeyCode.S) && GameController.Pause == false)
		{
			oldpos = transform.position;
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f * movespeed, 0);
			if (transform.position.y <= -9.4f)
			{
				transform.position = oldpos;
			}
		}
		if (Input.GetKey(KeyCode.D) &&GameController.Pause == false)
		{
			oldpos = transform.position;
			transform.position = new Vector3(transform.position.x + 0.01f * movespeed, transform.position.y, 0);
			if (transform.position.x >= 15.0f)
			{
				transform.position = oldpos;
			}
		}
		if (Boss.IsLive == false&&GameController.screen==4)
		{
			transform.position = new Vector3(0, -15, 0);
		}
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		anim.SetTrigger("trungdan");
		//hủy ship khi chạm vào các đối tượng khác
		Life--;
		if (Life <= 0)
		{
			Life = 0;
			GameObject exp = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
			Destroy(exp, 0.25f);
			audioSource.clip = gameover;
			audioSource.Play();
			transform.position = new Vector3(0, -15, 0);
			GameController.Restart = false;
		}
		if (collision.isTrigger == true)
		{

			Destroy(collision.gameObject);
		}
	}
	//private void OnDestroy()
	//{
	//	//tạo hiệu ứng nổ khi ship bị hủy
	//	Life = 0;
	//	GameObject exp = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
	//	Destroy(exp, 0.25f);
	//	audioSource.clip = gameover;
	//	audioSource.Play();
	
}
