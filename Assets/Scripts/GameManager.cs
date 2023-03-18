using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	//public Color TeamColor;

	public string playerName;
	public string playerNameHighScore;
	public int highScore;
	//public TMP_Text highScoreText;

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
		LoadHighScoreData();
	}

	private void Start()
	{
		//highScoreText.text = $"High Score : {playerNameHighScore} : {highScore}";
		Debug.Log("?");
	}

	[System.Serializable]
	class HighScoreData
	{
		public string playerNameSave;
		public int highScoreSave;
	}

	public void SaveHighScoreData()
	{
		HighScoreData dataToSave = new HighScoreData();
		dataToSave.playerNameSave = playerNameHighScore;
		dataToSave.highScoreSave = highScore;

		string json = JsonUtility.ToJson(dataToSave);

		File.WriteAllText(Application.persistentDataPath + "/HighScore.json", json);
	}

	public void LoadHighScoreData()
	{
		string path = Application.persistentDataPath + "/HighScore.json";
		if(File.Exists (path))
		{
			string json = File.ReadAllText(path);
			HighScoreData dataToLoad = JsonUtility.FromJson<HighScoreData>(json);

			playerNameHighScore = dataToLoad.playerNameSave;
			highScore = dataToLoad.highScoreSave;
		}
	}
}
