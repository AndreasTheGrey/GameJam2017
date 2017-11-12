using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameManager.Instance.winner != null) {
            GetComponent<Text> ().text = GameManager.Instance.winner + " wins!";
        } else {
            GetComponent<Text> ().text = "No one wins!";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
