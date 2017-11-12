using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    //private FightManager fightManager;

    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);    

        DontDestroyOnLoad(gameObject);

        //fightManager = GetComponent<FightManager>();

        InitGame();
    }

    void InitGame() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

	void Start () {
		
	}
	
	void Update () {
		
	}
}
