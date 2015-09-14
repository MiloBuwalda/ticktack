using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    // unity inspector
    public UnityEngine.UI.Text timerText;

   // protected TimeSpan timeLeft;
    private float timeLeft;
    protected bool running;
    protected double multiplier;


	// Use this for initialization
	void Start () {
        multiplier = 1;
        timeLeft = 30;
        running = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!running)
            return;
        double totalSeconds = Time.deltaTime * multiplier;
        timeLeft -= (float) totalSeconds;
        if (timeLeft <= 0)
        {
            // player die TODO
            GameStateManager.instance.SwitchTo(GameState.GameOverState);
            return;
        }

        int minutes = (int) Mathf.FloorToInt(timeLeft / 60F);
        int seconds = (int) Mathf.FloorToInt(timeLeft - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
      
        timerText.color = Color.yellow;
        if (timeLeft <= 10 && (int)timeLeft % 2 == 0)
            timerText.color = Color.red;
        

    
	}

    void OnEnable()
    {
        Reset();
    }


    public  void Reset()
    {
        timeLeft = 30;
        this.running = true;
    }

    public bool Running
    {
        get { return running; }
        set { running = value; }
    }

    public double Multiplier
    {
        get { return multiplier; }
        set { multiplier = value; }
    }

    public bool GameOver
    {
        get { return timeLeft <= 0; }
    }

}
