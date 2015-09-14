using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (LevelManager.instance.CurrentLevelIndex < LevelManager.instance.Levels.Count - 1)
            {
                LevelManager.instance.CurrentLevelIndex++;
                GameStateManager.instance.SwitchTo(GameState.PlayingState);
            }
            else
            {
                GameStateManager.instance.SwitchTo(GameState.LevelMenu);
            }
        }
    }
}
