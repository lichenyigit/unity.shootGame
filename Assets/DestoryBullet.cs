using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//销毁未爆炸的子弹
public class DestoryBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("DestoryBullet update " + Time.time);
	}

	private void OnTriggerExit(Collider other){
		Destroy(other.gameObject);
	}

}
