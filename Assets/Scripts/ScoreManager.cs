using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

	private int score = 0;

	[SerializeField]
	private Text scoreLabel;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// スコアを加算する
	public void AddScore (int i) {
		score += i;
		scoreLabel.text = score.ToString ();
	}

	public int GetScore () {
		return score;
	}
}