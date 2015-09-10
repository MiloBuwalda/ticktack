/// <summary>
/// Help  (replacement for HelpState.cs)
/// Assigned to Child object of Main camera in menu scene
/// </summary>
using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour {

    public GameObject titleMenu;

    public void BackButtonClick()
    {
        titleMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
