using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour {

    public Sprite[] sprites;

    void Start () {
        if (GameManager.Instance.winner != null) {
            Debug.Log (GameManager.Instance.winner);
            if (GameManager.Instance.winner == "Player 1") {
                GetComponent<Image> ().overrideSprite = sprites [0];
            } else if (GameManager.Instance.winner  == "Player 2") {
                GetComponent<Image> ().overrideSprite = sprites [1];
            } else if (GameManager.Instance.winner  == "Player 3") {
                GetComponent<Image> ().overrideSprite = sprites [2];
            } else if (GameManager.Instance.winner  == "Player 4") {
                GetComponent<Image> ().overrideSprite = sprites [3];
            }
        }
	}
	
	void Update () {
	}
}
