using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {


    public Texture quitButtonTexture;

    void OnGUI()
    {
        float width = 100;
        float height = 20;

        // TODO remove these magic numbers for scaling (based on screen size & texture size of xna game)
       /* if (GUI.Button(new Rect(Screen.width -width - 10, 10, width, height), quitButtonTexture, GUIStyle.none))
        {
            Application.LoadLevel("Menu");
        }*/

    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
