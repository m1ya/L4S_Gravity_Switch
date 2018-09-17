using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : SingletonMonoBehaviour<StageController> {

	private const int PATERN_UNIT = 10;
	private const int ITEM_UNIT = 25;

	[SerializeField]
	private GameObject block,
	item;

	// 2次元配列のステージパターンを格納した一次元の配列
	private int[, , ] patern = new int[, , ] {
		{ { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 }
		}, { {-1, -1, -1, 0, 0, 0, 0, 1, 1, 1 },
			{ 0, 0, 0, -1, -1, -1, -1, 0, 0, 0 }
		},
	};

	List<GameObject> stage = new List<GameObject> ();

	// Use this for initialization
	void Start () {
		// 初期のステージを作成する
		Create (-50, 150);
	}

	// Update is called once per frame
	void Update () {

	}

	/// <summary>
	/// ステージをxからlength分作る
	/// </summary>
	/// <param name="length"></param>
	public void Create (int x, int length) {
		// ステージのパターンを選ぶ
		int stagePatern = Random.Range (0, 2);
		// アイテムが上か下かを決める
		int itemPos = Random.Range (0, 2);

		for (int i = 0; i < length; i++) {
			if (i % PATERN_UNIT == 0) {
				stagePatern = Random.Range (0, 2);
			}
			if (i % ITEM_UNIT == 0) {
				itemPos = Random.Range (0, 2);
			}
			//上下の二列
			for (int j = 0; j < 2; j++) {
				float posY;
				if (j == 0) {
					posY = 8;
				} else {
					posY = -8;
				}
				// パターンに沿って高さを決める
				posY += patern[stagePatern, j, i % PATERN_UNIT];
				GameObject obj = Instantiate (block, new Vector3 (x + i, posY, 0), Quaternion.identity);
				obj.transform.SetParent (transform);
				stage.Add (obj);
				// アイテムを生成する
				if (i % ITEM_UNIT == 0 && j == itemPos) {
					// posY - 1 + j * 2で上でも下でも内側に出る
					posY = posY - 6 + j * 12;
					GameObject itemObj = Instantiate (item, new Vector3 (x + i, posY, 0), Quaternion.identity);
					itemObj.transform.SetParent (transform);
					stage.Add (itemObj);
				}
				// 色を交互に設定する 
				if (i % 2 == 0) {
					obj.GetComponent<Renderer> ().material.color = new Color (0.77f, 0.68f, 0.83f);
				} else {
					obj.GetComponent<Renderer> ().material.color = new Color (0.68f, 0.77f, 0.83f);
				}
			}
		}
	}

	/// <summary>
	/// xより左側のブロックを消す
	/// </summary>
	/// <param name="x"></param>
	public void Delete (int x) {
		// リストは要素を消すとindexが繰り上がるので上から調べて行く
		// for (int i = 0; i < stage.Count; i++) {
		for (int i = stage.Count - 1; i >= 0; i--) {
			if (stage[i] == null) {
				continue;
			}
			if (stage[i].transform.position.x < x) {
				Destroy (stage[i]);
				stage.Remove (stage[i]);
			}
		}

	}
}