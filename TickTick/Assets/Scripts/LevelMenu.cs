/// <summary>
/// LevelMenu  (replacement for LevelMenuState.cs)
/// Assigned to Child object of Main camera in menu scene
/// </summary>

using UnityEngine;
using System.Collections;

public class LevelMenu : MonoBehaviour
{

    public GameObject titleMenu;

    // textures assigned in unity inspector
    public Texture backgroundTexture;
    public Texture backButtonTexture;


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);


        /* for ..
           
         add button for each level
          
          */


        // TODO remove these magic numbers for scaling (based on screen size & texture size of xna game)
        float width = 0.16f * Screen.width;
        float height = 0.065f * Screen.height;
        if (GUI.Button(new Rect((Screen.width - width) / 2, (int)(Screen.height * 0.909), width, height), backButtonTexture, GUIStyle.none))
        {
            titleMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    /*
     select levels etc
     * /

}
