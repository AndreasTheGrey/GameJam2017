using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetup : MonoBehaviour {

	void Awake () {
        GetComponent<Camera> ().aspect = 1920 / 1080;
	}
	
	void Update () {
		
	}
}
