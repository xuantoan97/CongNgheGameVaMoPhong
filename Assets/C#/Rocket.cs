using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	// Use this for initialization
	//vị trí của vật muốn tấn công
	public Vector3 taget;
	//vận tốc
	private float movespeed;
	//đối tượng nổ
	public GameObject ex;
	void Start () {
		movespeed = 2.5f;
	}
	
	// Update is called once per frame
	void Update () {
		//di chuyển chuyển theo vật có tọa độ taget
		transform.Translate((transform.position - taget) * movespeed * Time.deltaTime*-1);
		Destroy(gameObject,1.5f);
	}
	private void OnDestroy()
	{
		//tạo animation khi hủy
		GameObject e = Instantiate(ex, transform.position, Quaternion.identity);
		Destroy(e, 0.5f);

	}
}
