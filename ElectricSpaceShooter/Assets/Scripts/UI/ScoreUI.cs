using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

	[SerializeField] private Text score;
	[SerializeField] private GameObject scoreObject;


	private void UpdateText(int _score)
	{
		score.text = "Score: " + _score.ToString();
	}

	private void ChangeText(bool _isActive)
	{
		scoreObject.SetActive(!_isActive);
	}

	private void OnEnable()
	{
		Progression.increaseScoreUiEvent += UpdateText;
		GameOverUI.GameOverEvent += ChangeText;
	}

	private void OnDisable()
	{
		Progression.increaseScoreUiEvent -= UpdateText;
		GameOverUI.GameOverEvent -= ChangeText;
	}
}