/// <summary>
/// TitleMenu  (replacement for TitlemenuState.cs)
/// Assigned to Child object of Main camera in menu scene
/// </summary>
using UnityEngine;
using System.Collections;

public class TitleMenu : MonoBehaviour
{

    public GameObject levelMenu;
    public GameObject help;

    public void PlayButtonClick()
    {
        levelMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void HelpButtonClick()
    {
        help.SetActive(true);
        gameObject.SetActive(false);
    }
}
