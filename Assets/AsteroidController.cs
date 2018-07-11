using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//小行星控制器
public class AsteroidController : MonoBehaviour
{
	private PlayerController playerController;

	//小行星对象
	public GameObject asteroid;
	//小行星旋转速度
	public float tumble;
	//爆炸对象
	public GameObject bulletBomb;//子弹爆炸
	public GameObject playerBomb;//飞船爆炸

	//小行星出现
	public float waitTime;//出现间隔时间
	public float asteroidMoveRate;//小行星移动速度

	// Use this for initialization
	void Start()
	{
		GameObject playControllerObj = GameObject.FindGameObjectWithTag("Player");
		if (playControllerObj != null)
		{
			playerController = playControllerObj.GetComponent<PlayerController>();
		}
		else
		{
			Debug.Log("没有找到 'PlayerController' ");
		}

		//小行星旋转动作
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
		//小行星移动
		GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, transform.position.z * -asteroidMoveRate);
	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log("AsteroidController update");
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Bullet"))
		{//如果是子弹
		 //产生爆炸效果并且发出声音
			Instantiate(bulletBomb, transform.position, transform.rotation);
			//更新分数
			playerController.addScore();
			//飞船,子弹和小行星消失
			Destroy(other.gameObject);
			Destroy(asteroid);
		}
		//如果是飞船进行碰撞
		if (other.tag.Equals("Player"))
		{
			//产生爆炸效果并且发出声音
			Instantiate(playerBomb, transform.position, transform.rotation);
			playerController.GameOver();
			//飞船,子弹和小行星消失
			Destroy(other.gameObject);
			Destroy(asteroid);
		}
	}
}
