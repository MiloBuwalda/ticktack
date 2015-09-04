﻿/// <summary>
/// TitleMenu  (replacement for TitlemenuState.cs)
/// Assigned to Main camera in TitleMenu scene
/// </summary>
using UnityEngine;
using System.Collections;

public class TitleMenu : MonoBehaviour
{

    // textures assigned in unity inspector
    public Texture backgroundTexture;
    public Texture playButtonTexture;
    public Texture helpButtonTexture;


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        // TODO remove these magic numbers for scaling (based on screen size & texture size of xna game)
        float width = 0.16f * Screen.width;
        float height = 0.065f * Screen.height;
        if (GUI.Button(new Rect((Screen.width - width) / 2, (int)(Screen.height * 0.65), width, height), playButtonTexture, GUIStyle.none))
        {
            Application.LoadLevel("LevelMenu");
        }
        if (GUI.Button(new Rect((Screen.width - width) / 2, (int)(Screen.height * 0.72), width, height), helpButtonTexture, GUIStyle.none))
        {
            Application.LoadLevel("Help");
        }
    }

}
