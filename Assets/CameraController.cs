﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private GameObject target;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.position = new Vector3 (target.transform.position.x, 0, + -10f);
		}
	}
}