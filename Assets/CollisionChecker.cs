using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour {
	[SerializeField]
	private GameObject breakParticle;

	// Use this for initialization
	void Start () { }

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter (Collider other) {
		// 壁に当たったら壊れる
		if (other.gameObject.tag == "Stage") {
			GameManager.Instance.GameOver ();
			// 順番に注意
			Debug.Log (Resources.Load ("button43") as AudioClip);
			Instantiate (breakParticle, transform.position, Quaternion.identity);
			Destroy (gameObject.transform.parent.gameObject);
		}
	}
}