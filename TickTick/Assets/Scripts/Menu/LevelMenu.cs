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

    public void LevelButtonClick(int id)
    {
        if (id == 0)
        {
           // SetButtonTexture(solvedLevel, 0);
            Application.LoadLevel("AssetLevel");
        }
    }

    private void SetButtonTexture(Sprite texture, int buttonID)
    {
        levelButtons[buttonID].image.sprite = texture;
    }

}
