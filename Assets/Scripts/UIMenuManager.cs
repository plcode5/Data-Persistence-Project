using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
	using UnityEditor;
#endif

public class UIMenuManager : MonoBehaviour
{
	[SerializeField] TMP_InputField nameInputField;
	[SerializeField] TMP_Text highScoreText;

	private void Start()
	{
		nameInputField.text = GameManager.Instance.playerName;
		highScoreText.text = $"High Score : {GameManager.Instance.playerNameHighScore} : {GameManager.Instance.highScore}";
	}

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void Exit()
	{
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
	}

	private void Update()
	{
	}

	public void SetPlayerName()
	{
		Debug.LogFormat(nameInputField.text);
		GameManager.Instance.playerName = nameInputField.text;
	}
}
