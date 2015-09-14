using UnityEngine;
using System.Collections;

public class Hint : MonoBehaviour {

    // unity inspector
    public UnityEngine.UI.Text hintText;
    
    private float timeLeft;
    private string text;

	// Use this for initialization
	void Start () {
        Reset();
	
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= (float)Time.deltaTime;
        if (timeLeft <= 0)
            gameObject.SetActive(false);
	}

    public void Reset()
    {
        timeLeft = 5;
        
    }

    public string Text
    {
       get { return text; }
       set { 
                text = value;
                hintText.text = text;
           }
    }
}
