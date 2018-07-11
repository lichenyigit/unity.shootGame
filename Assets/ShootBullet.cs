using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//子弹发射控制
public class ShootBullet : MonoBehaviour {
	public GameObject bullet;//子弹对象
	public Transform transform;//子弹发射的位置

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//发射子弹
		if (Input.GetKeyDown(KeyCode.Space)) {
			//发射子弹
			Instantiate(bullet, transform.position, transform.rotation);
			//添加音效
			GetComponent<AudioSource>().Play();
		}
	}
}
