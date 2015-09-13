﻿using UnityEngine;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour {

    // set in unity inspector
    public GameObject titleMenu;
    public GameObject helpMenu;
    public GameObject levelMenu;

    private GameState currentGameState;

    public static GameStateManager instance = null;


    // Singleton instance, to be able to call GameStateManager.instance.SwitchTo   etc
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(this); // or gameObject
    }


	// Use this for initialization
	void Start () {
        currentGameState = GameState.TitleMenu;
        SwitchToMenu(titleMenu);
	}

    // switch gamestates
    public void SwitchTo(GameState targetGameState)
    {
        switch (targetGameState)
        {
            case GameState.TitleMenu: SwitchToMenu(titleMenu); break;
            case GameState.LevelMenu: SwitchToMenu(levelMenu); break;
            case GameState.HelpMenu: SwitchToMenu(helpMenu); break;
            case GameState.PlayingState: SwitchToPlaying();  break;
            case GameState.GameOverState: throw new System.NotImplementedException();  //break;
            case GameState.LevelFinishedState: throw new System.NotImplementedException();  //break;
        }
        currentGameState = targetGameState;
    }

    // switch to one of the three menu gamestates
    private void SwitchToMenu(GameObject menu)
    {
        menu.SetActive(true);
        Debug.Log("before disable");
        DisableLevels();

        if( menu != titleMenu)
            titleMenu.SetActive(false);
        if (menu != helpMenu)
            helpMenu.SetActive(false);
        if (menu != levelMenu)
            levelMenu.SetActive(false);
    }


    private void SwitchToPlaying()
    {
        titleMenu.SetActive(false);
        helpMenu.SetActive(false);
        levelMenu.SetActive(false);

        int index = LevelManager.instance.CurrentLevelIndex;
        DisableLevels();
        Debug.Log(index);
        LevelManager.instance.Levels[index].LevelObject.SetActive(true);
    }

    private void DisableLevels()
    {
        List<Level> levels = LevelManager.instance.Levels;
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].LevelObject.SetActive(false);
            //reset
        }
    }


    public GameState CurrentGameState
    {
        get
        {
            return currentGameState;
        }
    }

}
