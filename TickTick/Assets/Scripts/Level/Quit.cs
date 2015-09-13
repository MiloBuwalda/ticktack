/// <summary>
/// quit button formerly found in Level.cs in xna
/// </summary>

using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {


    public Texture quitButtonTexture;

    public void QuitButtonClick()
    {
        GameStateManager.instance.SwitchTo(GameState.LevelMenu);
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
