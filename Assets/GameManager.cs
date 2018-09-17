using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager> {

	public bool isPlay = false;

	[SerializeField]
	private GameObject startCanvas,
	endCanvas;

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
	}
}