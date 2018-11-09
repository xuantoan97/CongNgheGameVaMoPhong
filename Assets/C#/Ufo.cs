using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour {

	// Use this for initialization
	//đối tượng laser của ufo
	public GameObject laserufo;
	//đối tượng ship
	private GameObject ship;
	//animation nổ
	public GameObject explor;
	//đạn đuổi của ufo
	public GameObject rocket;
	//thời gian delay giữa những lần bắn đạn của ufo
	public static float delay;
	//biến để kiểm tra trạm đến biên
	private static bool bien = false;
	//biến kiểm tra lúc mới xuất hiện của đối tượng UFO
	public static bool xuathien = true;
	//vận tốc
	public float movespeed;
	//máu
	private int HP;
	void Start () {
		//khởi tạo đối tượng ship với gameobject có tag là "ship"
		ship = GameObject.FindGameObjectWithTag("ship");
		//khởi tao các giá trị ban đầu
		delay = 51;
		HP = 10;
	}

	// Update is called once per frame
	void Update()
	{
		delay--;
		//khi mới xuất hiện 
		if (xuathien)
		{
			transform.position = new Vector3(transform.position.x , transform.position.y - 0.01f * movespeed, 0);
			if (transform.position.y <= 6.5)
			{
				xuathien = false;
			}
		}
		//thời điểm bắn laser
		if (delay == 25||delay==50)
		{
			GameObject laser = Instantiate(laserufo, new Vector3(transform.position.x,transform.position.y-2f,0), Quaternion.identity) as GameObject;
			laser.GetComponent<LaserUfo>().target = Random.Range(-2f, 2f);
			Destroy(laser, 10.0f);
		}
		//thời điểm bắn rocket
		if (delay == 0)
		{
			GameObject rk = Instantiate(rocket, new Vector3(transform.position.x, transform.position.y - 3f, 0), Quaternion.identity) as GameObject;
			rk.GetComponent<Rocket>().taget = ship.transform.position;
			delay = 50;
		}
		//chạm biên thì chạy ngược lại
		if (bien == false)
		{
			transform.position = new Vector3(transform.position.x + 0.01f * movespeed, transform.position.y, 0);
			if (transform.position.x >= 13f)
			{
				bien = true;
			}
		}
		if (bien == true)
		{
			transform.position = new Vector3(transform.position.x - 0.01f * movespeed, transform.position.y, 0);
			if (transform.position.x <= -13f)
			{
				bien = false;
			}
		}
	}
	//xử lý với nhưỡng vật thể có thuộc tính trigger
	private void OnTriggerEnter2D(Collider2D collision)
	{
		HP--;
		Destroy(collision.gameObject);
		if (HP <= 0)
		{
			Destroy(gameObject);
		}
	}
	//hàm được gọi khi đối tượng bị hủy
	private void OnDestroy()
	{
		//tạo animation nổ
		GameObject exp = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
		Destroy(exp, 0.25f);
	}
}
