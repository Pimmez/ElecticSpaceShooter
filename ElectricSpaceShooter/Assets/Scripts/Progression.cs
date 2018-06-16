using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Progression : MonoBehaviour
{
	public static Action<int> increaseScoreUiEvent;

	[SerializeField] private GameObject playerPrefab;
	private int totalScore;

	private void UpdateScore(int _score)
	{
		totalScore += _score;

		if(increaseScoreUiEvent != null)
		{
			increaseScoreUiEvent(totalScore);
		}
	}

	private void Update()
	{
		if(GameOverUI.Instance.IsGameOver == true)
		{ 
			if(Input.GetKeyDown(KeyCode.R))
			{
				ResetAll();
			}
		}
	}

	private void ResetAll()
	{
		SceneManager.LoadScene(0);

	}

	private void OnEnable()
	{
		Asteroid.scoreIncreaseEvent += UpdateScore;
	}

	private void OnDisable()
	{
		Asteroid.scoreIncreaseEvent -= UpdateScore;
	}
}