using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;//移动速率
	public float tile;//倾斜度

	public Boundary boundary;

	//小行星
	public GameObject asteroid;
	//小行星位置
	public Vector3 asteroidPosition;
	private int asteroidCount = 1;//一次出现小行星的数量
	public float asteroidWaitTime;

	private int score = 0;//默认分数为0
	public Text ScoreText;
	public Text restartText;//重新开始

	public bool gameOver = false;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(ShowAsteroid());//出现子弹
	}

	// Update is called once per frame
	void Update()
	{
	}

	private void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");//水平移动的距离
		float vertical = Input.GetAxis("Vertical");//垂直移动的距离
												   //开始移动
		GetComponent<Rigidbody>().velocity = new Vector3(horizontal * speed, 0.0f, vertical * speed);
		//Debug.Log(GetComponent<Rigidbody>().velocity.x * -tile);
		//飞船倾斜
		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tile);//求解释
																														//飞船移动范围
		GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
	}
	IEnumerator ShowAsteroid()
	{
		while (true)
		{
			for (int i = 0; i < asteroidCount; i++)
			{
				//随机生成位置
				Vector3 position = new Vector3(UnityEngine.Random.Range(-asteroidPosition.x, asteroidPosition.x), asteroidPosition.y, UnityEngine.Random.Range(asteroidPosition.z + 1, asteroidPosition.z + 3));
				Instantiate(asteroid, position, Quaternion.identity);
			}
			yield return new WaitForSeconds(asteroidWaitTime);
		}
	}

	public void addScore()
	{
		score += 10;
		ScoreText.text = "Score: " + score;
	}

	private void resetScore()
	{
		ScoreText.text = "Score: 0";
	}

	public void GameOver()
	{
		gameOver = true;
		restartText.text = "       游戏结束  \r\n请按R键重新开始";
	}
}

[Serializable]
public class Boundary
{
	public float xMax, xMin, zMax, zMin;
}
