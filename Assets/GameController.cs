using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//整个游戏控制器
public class GameController : MonoBehaviour
{
	private PlayerController playerController;

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
	}

	// Update is called once per frame
	void Update()
	{
		if (playerController.gameOver)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
