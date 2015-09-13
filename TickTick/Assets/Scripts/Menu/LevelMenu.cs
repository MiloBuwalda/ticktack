/// <summary>
/// LevelMenu  (replaces input functionality from LevelMenuState.cs)
/// Assigned to LevelMenu canvas in scene
/// </summary>

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{

    // Sprites & buttons assigned in unity inspector
    public Sprite lockedLevel;
    public Sprite unsolvedLevel;
    public Sprite solvedLevel;

    public Button[] levelButtons;

    public void BackButtonClick()
    {
        GameStateManager.instance.SwitchTo(GameState.TitleMenu);
    }

    // refresh button images when levelMenu shows up
    void OnEnable()
    {
        SetButtonTextures();
    }

    // change the button texture instead of creating a new button
    private void SetButtonTextures()
    {
        List<Level> levels = LevelManager.instance.Levels;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            
            if (i <= levels.Count)
            {
                if (levels[i].Locked)
                    SetButtonTexture(lockedLevel, i);
                else if (levels[i].Solved)
                    SetButtonTexture(solvedLevel, i);
                else
                    SetButtonTexture(unsolvedLevel, i);
            }
        }
    }

    public void LevelButtonClick(int levelIndex)
    {
        LevelManager.instance.CurrentLevelIndex = levelIndex;
        Debug.Log("click1");
        GameStateManager.instance.SwitchTo(GameState.PlayingState);
    }

    private void SetButtonTexture(Sprite texture, int levelIndex)
    {
        levelButtons[levelIndex].image.sprite = texture;
    }

}
