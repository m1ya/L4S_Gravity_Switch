using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager> {

	public bool isPlay = false;

	[SerializeField]
	private GameObject startCanvas,
	endCanvas;

	[SerializeField]
	private Text highscoreLabel;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}

	// Update is called once per frame
	void Update () {
		if (!isPlay && Input.GetMouseButtonDown (0)) {
			if (startCanvas.activeSelf) {
				startCanvas.SetActive (false);
				Time.timeScale = 1;
				isPlay = true;
			} else {
				SceneManager.LoadScene ("Main");
			}
		}
	}

	public void GameOver () {
		isPlay = false;
		endCanvas.SetActive (true);

		// ハイスコアの読み込み
		int highscore = PlayerPrefs.GetInt ("HighScore");
		int score = ScoreManager.Instance.GetScore ();
		// ハイスコアの更新
		if (highscore < score) {
			PlayerPrefs.SetInt ("HighScore", score);
		} else {
			score = highscore;
		}
		// ハイスコアの表示
		highscoreLabel.text = "High Score : " + score.ToString ("000");
	}
}