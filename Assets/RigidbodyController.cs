using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// ゲーム中じゃなければ終わる
		if (!GameManager.Instance.isPlay) {
			return;
		}

		// 左クリックを押したら
		if (Input.GetMouseButtonDown (0)) {
			// 重力を反転させる
			Physics.gravity = -Physics.gravity;
		}
	}
}