using UnityEngine;
using System;

public class GameOverUI : MonoBehaviour
{
	public static Action<bool> GameOverEvent;

	public static GameOverUI Instance { get { return GetInstance(); } }

	#region Singleton
	private static GameOverUI instance;

	private static GameOverUI GetInstance()
	{
		if (instance == null)
		{
			instance = FindObjectOfType<GameOverUI>();
		}
		return instance;
	}
	#endregion

	public bool IsGameOver { get { return isGameOver; } }

	[SerializeField] private GameObject gameOver;
	[SerializeField] private GameObject restart;

	private bool isGameOver;

	private void GameOverStarted()
	{
		isGameOver = true;
		if (GameOverEvent != null)
		{
			GameOverEvent(isGameOver);
		}

		if (isGameOver)
		{
			gameOver.SetActive(true);
			restart.SetActive(true);
		}
	}

	private void OnEnable()
	{
		PlayerController.playerDiedEvent += GameOverStarted;
	}

	private void OnDisable()
	{
		PlayerController.playerDiedEvent -= GameOverStarted;
	}
}