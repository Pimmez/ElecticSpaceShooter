using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

	[SerializeField] private Text score;
	[SerializeField] private Text highscore;

	[SerializeField] private GameObject scoreObject;

	private void UpdateText(int _score)
	{
		score.text = "Score: " + _score;
	}

	private void UpdateHighscore(int _score)
	{
		highscore.text = "TotalScore: " + _score;
	}

	private void ChangeText(bool _isActive)
	{
		scoreObject.SetActive(!_isActive);
	}

	private void OnEnable()
	{
		Progression.increaseScoreUiEvent += UpdateText;
		Progression.increaseScoreUiEvent += UpdateHighscore;

		GameOverUI.GameOverEvent += ChangeText;
	}

	private void OnDisable()
	{
		Progression.increaseScoreUiEvent -= UpdateText;
		Progression.increaseScoreUiEvent -= UpdateHighscore;

		GameOverUI.GameOverEvent -= ChangeText;
	}
}