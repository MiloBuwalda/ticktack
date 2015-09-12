using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

    // set in unity inspector
    public GameObject titleMenu;
    public GameObject helpMenu;
    public GameObject levelMenu;
    public GameObject level;

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
            case GameState.PlayingState: break;
            case GameState.GameOverState: break;
            case GameState.LevelFinishedState: break;
        }
        currentGameState = targetGameState;
    }

    // switch to one of the three menu gamestates
    private void SwitchToMenu(GameObject menu)
    {
        menu.SetActive(true);
        level.SetActive(false);

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

        level.SetActive(true);
        
        // load level
    }



    public GameState CurrentGameState
    {
        get
        {
            return currentGameState;
        }
    }

}
