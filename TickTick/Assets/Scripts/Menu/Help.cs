/// <summary>
/// Help  (implements input from HelpState.cs)
/// Assigned to Help canvas in scene
/// </summary>
using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour {

    public void BackButtonClick()
    {
        GameStateManager.instance.SwitchTo(GameState.TitleMenu);
    }
}
