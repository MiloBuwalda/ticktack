/// <summary>
/// LevelMenu  (replacement for LevelMenuState.cs)
/// Assigned to Child object of Main camera in menu scene
/// </summary>

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{

    public GameObject titleMenu;
    public Sprite lockedLevel;
    public Sprite unsolvedLevel;
    public Sprite solvedLevel;

    public Button[] levelButtons;

    public void BackButtonClick()
    {
        titleMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    void OnEnable()
    {

        SetButtonTextures();
    }

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

    public void LevelButtonClick(int id)
    {
        
    }

    private void SetButtonTexture(Sprite texture, int buttonID)
    {
        levelButtons[buttonID].image.sprite = texture;
    }

}
