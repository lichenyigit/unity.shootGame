using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//子弹移动
public class BulletMove : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
