/// <summary>
/// Help  (replacement for HelpState.cs)
/// Assigned to Child object of Main camera in menu scene
/// </summary>
using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour {

    public void BackButtonClick()
    {
        GameStateManager.instance.SwitchTo(GameState.TitleMenu);
    }
}
