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
	//animation trúng đạn
	private Animator anime;
			
	//đạn đuổi của ufo
	public GameObject rocket;
	//thời gian delay giữa những lần bắn đạn của ufo
	public  float delay;
	//biến để kiểm tra trạm đến biên
	private  bool bien = false;
	//biến kiểm tra lúc mới xuất hiện của đối tượng UFO
	public  bool xuathien = true;
	//vận tốc
	public float movespeed;
	//máu
	private int HP;
	private AudioSource audioSource;
	public AudioClip soundlaser;
	void Start () {
		//khởi tạo đối tượng ship với gameobject có tag là "ship"
		ship = GameObject.FindGameObjectWithTag("ship");
		anime = gameObject.GetComponent<Animator>();
		audioSource = gameObject.GetComponent<AudioSource>();
		anime.SetTrigger("nottrungdan");
		//khởi tao các giá trị ban đầu
		delay = 51;
		HP = 20;
	}

	// Update is called once per frame
	void Update()
	{
		anime.SetTrigger("nottrungdan");
		if (GameController.Pause == false)
		{
			delay--;
			//khi mới xuất hiện 
			if (transform.position.y > 6.5)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y - 0.005f * movespeed, 0);
			}
			//thời điểm bắn laser
			if (delay == 25 || delay == 50)
			{
				audioSource.clip = soundlaser;
				audioSource.Play();
				GameObject laser = Instantiate(laserufo, new Vector3(transform.position.x, transform.position.y - 2f, 0), Quaternion.identity) as GameObject;
				laser.GetComponent<LaserUfo>().target = Random.Range(-2f, 2f);

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
	}
	//xử lý với nhưỡng vật thể có thuộc tính trigger
	private void OnTriggerEnter2D(Collider2D collision)
	{
		anime.SetTrigger("trungdan");
		HP--;
		if (collision.gameObject != GameObject.FindGameObjectWithTag("ship"))
		{
			Destroy(collision.gameObject);
		}
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
		GameController.screen = 2;
		GameController.appear = true;
		WallController.create = true;
	}
}
