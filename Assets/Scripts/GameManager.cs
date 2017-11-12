using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;
    private FightManager fightManager;
    public string winner;

    void Awake() {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);    

        DontDestroyOnLoad(gameObject);

        fightManager = GetComponent<FightManager>();

        ShowMenu();
    }

    public void ShowMenu() {
        UnloadScene ("EndMenu");
        SceneManager.LoadScene ("Menu", LoadSceneMode.Additive);
    }

    public void StartGame(int playerAmount) {
        UnloadScene ("Menu");
        fightManager.startNewFight (playerAmount);
    }

    public void FightEnd(string winningDwarfName) {
        winner = winningDwarfName;
        SceneManager.LoadScene ("EndMenu", LoadSceneMode.Additive);
    }

    private void UnloadScene(string scene) {
        try { SceneManager.UnloadSceneAsync (scene); } catch (ArgumentException exc) {}
    }

	void Start () {
	}
	
	void Update () {
		
	}
}
