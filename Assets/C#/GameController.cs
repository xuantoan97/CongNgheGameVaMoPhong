using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	// Use this for initialization
	//âm thanh
	private AudioSource audioSource;
	public AudioClip backgroupmusic;
	public AudioClip gameover;
	private GameObject ufo;
	//UI
	public GameObject PlStartGame;
	public GameObject PLEndGame;
	public GameObject PLabout;
	public GameObject PlPlayGuide;
	public Text TextLife;
	public Text TextScreen;
	public Text SwitchScreen;
	public Text TextPause;
	public Text TextPLEndGame;
	//biến
	public static int screen = 0;
	public static bool appear;
	public static bool Pause;
	public static bool Restart;
	void Start () {
		PlStartGame.SetActive(true);
		PLEndGame.SetActive(false);
		PLabout.SetActive(false);
		PlPlayGuide.SetActive(false);
		appear = false;
		Pause = true;
		Restart = false;
		TextLife.text = "";
		TextScreen.text = "";
		SwitchScreen.text = "";
		TextPause.text = "";
		TextPLEndGame.text = "Game Over";
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = backgroupmusic;
		audioSource.loop = true;
		audioSource.Play();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameController.screen != 0)
		{
			PlStartGame.SetActive(false);
			TextLife.text = "Life : " + ControllerShip2.Life;
			TextScreen.text = "Screen : " + screen;
		}
		if (appear == true)
		{
			SwitchScreen.text = "Screen " + screen;
		}
		if (appear == false)
		{
			SwitchScreen.text = "";
		
		}
		if (ControllerShip2.Life == 0)
		{
			audioSource.clip = gameover;
			audioSource.loop = false;
			audioSource.Play();
			PLEndGame.SetActive(true);
			GameController.Pause = true;
			TextLife.text = "";
			TextScreen.text = "";
			SwitchScreen.text = "";
			GameObject[] ufo = GameObject.FindGameObjectsWithTag("boss");
			for (int i = 0; i < ufo.Length; i++)
			{
				Destroy(ufo[i]);
			}
		}
		if (Boss.IsLive == false&&ControllerShip2.Life>0&&Restart==false)
		{
			TextPLEndGame.text = "You Win";
			PLEndGame.SetActive(true);
			GameController.Pause = true;
			TextLife.text = "";
			TextScreen.text = "";
			SwitchScreen.text = "";
		}
		if (Input.GetKey(KeyCode.P)&&Pause==false)
		{
				
				TextPause.text = "Nhấn phím R để tiếp tục";
				Time.timeScale = 0;
				Pause = true;
		}
		if ( Input.GetKey(KeyCode.R)&& ControllerShip2.Life > 0 && GameController.screen != 0)
		{
			TextPause.text = "";
			Time.timeScale = 1;
			Pause = false;
		}
	}

	public  void BtStart()
	{
		GameController.screen = 1;
		appear = true;
		Pause = false;
		Time.timeScale = 1;
	}
	public void BTexit()
	{
		Application.Quit();
	}
	public void BTrestart()
	{
		ControllerShip2.Life = 3;
		screen = 1;
		Ufo2.SL = 0;
		bosscon2.SL = 6;
		Boss.IsLive = true;
		audioSource.clip = backgroupmusic;
		audioSource.loop = true;
		audioSource.Play();
		TextPLEndGame.text = "Game Over";
		PLEndGame.SetActive(false);
		GameController.Pause = false;
		Restart = true;
		WallController.create = true;
		ControllerShip2.XuatHien = true;
	}
	 public void BtAbout()
	{
		PLabout.SetActive(true);
		PlStartGame.SetActive(false);

	}
	public void BtPlayguide()
	{
		PlPlayGuide.SetActive(true);
		PlStartGame.SetActive(false);
	}
	public void BtBack()
	{
		PlStartGame.SetActive(true);
		PLabout.SetActive(false);
		PlPlayGuide.SetActive(false);
	}
}


