using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;
    private FightManager fightManager;

    void Awake() {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);    

        DontDestroyOnLoad(gameObject);

        fightManager = GetComponent<FightManager>();

        InitGame();
    }

    void InitGame() {
        SceneManager.LoadScene ("Menu", LoadSceneMode.Additive);
    }

    public void StartGame(int playerAmount) {
        SceneManager.UnloadSceneAsync ("Menu");
        fightManager.startNewFight (playerAmount);
    }

	void Start () {
	}
	
	void Update () {
		
	}
}
