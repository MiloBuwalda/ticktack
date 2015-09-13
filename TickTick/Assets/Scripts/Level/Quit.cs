/// <summary>
/// quit button formerly found in Level.cs in xna
/// </summary>

using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

    public void QuitButtonClick()
    {
        GameStateManager.instance.SwitchTo(GameState.LevelMenu);
    }
}
