using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {


    public Texture quitButtonTexture;

    public void QuitButtonClick()
    {
        Application.LoadLevel("Menu");
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
