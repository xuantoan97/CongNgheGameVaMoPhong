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
	//khai báo đối tượng game của ship
	private GameObject obj;
	//biến kiểm tra xuất hiện
	private bool XuatHien;

	void Start () {
		obj = gameObject;
		XuatHien = true;
	}
	
	// Update is called once per frame
	void Update () {
		//khi xuất hiện 
		if (XuatHien == true)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, 0);
			if (transform.position.y >= -4)
			{
				XuatHien = false;
			}
		}
		//điều khiển phi thuyền
		if (Input.GetKeyDown(KeyCode.Space)==true)
		{
			
			  GameObject laserclone = Instantiate(laser, new Vector3(transform.position.x, transform.position.y+0.5f,0), Quaternion.identity) as GameObject;
			  Destroy(laserclone, 4f);
			
			
		}
		if (Input.GetKey(KeyCode.W))
		{
			oldpos = transform.position;
			transform.position = new Vector3(transform.position.x, transform.position.y +0.01f*movespeed, 0);
			if (transform.position.y >= 9.4f)
			{
				transform.position = oldpos;
			}
		}
		if (Input.GetKey(KeyCode.A))
		{
			oldpos = transform.position;
			transform.position = new Vector3(transform.position.x - 0.01f * movespeed, transform.position.y , 0);
			if (transform.position.x <= -15.4f)
			{
				transform.position = oldpos;
			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			oldpos = transform.position;
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f * movespeed, 0);
			if (transform.position.y <= -9.4f)
			{
				transform.position = oldpos;
			}
		}
		if (Input.GetKey(KeyCode.D))
		{
			oldpos = transform.position;
			transform.position = new Vector3(transform.position.x + 0.01f * movespeed, transform.position.y, 0);
			if (transform.position.x >= 15.0f)
			{
				transform.position = oldpos;
			}
		}
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//hủy ship khi chạm vào các đối tượng khác
		Destroy(obj);
	}
	private void OnDestroy()
	{
		//tạo hiệu ứng nổ khi ship bị hủy
		GameObject exp = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
		Destroy(exp, 0.25f);
	}
	//private void OnCollisionEnter2D(Collision2D collision)
	//{
	//	Time.timeScale = 0;
	//}
	//void EndGame()
	//{
	//	Time.timeScale = 0;
	//}
}
