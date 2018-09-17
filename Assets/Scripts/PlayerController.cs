using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private const int UNIT = 50;
	private const int SCORE_UNIT = 50;

	private AudioSource _audioSource;
	private Rigidbody _rigidbody;
	private float speed = 5f; // 初期の速さは5
	private int borderX = 50;
	private int scoreBorderX = 10;

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();
		_rigidbody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		// 速度を設定する
		_rigidbody.velocity = new Vector3 (speed, _rigidbody.velocity.y, _rigidbody.velocity.z);

		// 基準点よりも右に進んだら
		if (transform.position.x > borderX) {
			// 左側のブロックを消して右側のブロックをUNIT個作る
			StageController.Instance.Create (borderX + UNIT, UNIT);
			StageController.Instance.Delete (borderX - UNIT);
			borderX += UNIT;
		}

		// スコアの基準点よりも右に進んだら加点
		if (transform.position.x > scoreBorderX) {
			ScoreManager.Instance.AddScore (1);
			scoreBorderX += SCORE_UNIT;
		}
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter (Collider other) {
		// アイテムを獲得したら
		if (other.gameObject.tag == "Item") {
			ScoreManager.Instance.AddScore (1);
			_audioSource.PlayOneShot (Resources.Load ("button53") as AudioClip);
			Destroy (other.gameObject);
		}
	}

	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter (Collision other) {
		_audioSource.PlayOneShot (Resources.Load ("button45") as AudioClip);
	}
}