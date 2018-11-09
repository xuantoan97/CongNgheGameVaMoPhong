using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	public static int SLufo=0;
	public static bool man1 = true;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public enum ManCHoi : int
	{
		Man1 =1,
		Man2 =2,
		Man3= 3
	}
	public int getSLufo()
	{
		return SLufo;
	}
}
