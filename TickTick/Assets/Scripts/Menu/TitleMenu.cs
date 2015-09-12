/// <summary>
/// TitleMenu  (replacement for TitlemenuState.cs)
/// Assigned to Child object of Main camera in menu scene
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
