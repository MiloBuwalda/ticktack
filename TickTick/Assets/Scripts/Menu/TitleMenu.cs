/// <summary>
/// TitleMenu  handles input that was found in TitlemenuState.cs
/// Assigned to TitleMenu canvas in scene
/// </summary>
using UnityEngine;
using System.Collections;

public class TitleMenu : MonoBehaviour
{
    public void PlayButtonClick()
    {
        GameStateManager.instance.SwitchTo(GameState.LevelMenu);
    }

    public void HelpButtonClick()
    {
        GameStateManager.instance.SwitchTo(GameState.HelpMenu);
    }
}
