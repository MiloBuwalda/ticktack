using UnityEngine;
using System.Collections.Generic;

public partial class Level  {

    protected bool locked, solved;
    //protected Button quitButton

    public GameObject LevelObject;

    private List<GameObject> backgrounds;
    private GameObject timer;
    private List<GameObject> waterdrops = new List<GameObject>();
    private List<GameObject> enemies;
    private TileField tiles;
    private GameObject player;
    private GameObject end;

    public Level(int levelIndex)
    {
        LevelObject = new GameObject("Level" + levelIndex);
        LevelObject.SetActive(false);
        LevelObject.transform.SetParent(LevelManager.instance.gameObject.transform);
        // load the backgrounds
        backgrounds = new List<GameObject>();
     //   GameObjectList backgrounds = new GameObjectList(0, "backgrounds");
       // SpriteGameObject background_main = new SpriteGameObject("Backgrounds/spr_sky");
        GameObject background_main = MonoBehaviour.Instantiate(Resources.Load("Prefabs/BackgroundCanvas")) as GameObject;
        background_main.transform.SetParent(LevelObject.transform, true);

      //  background_main.Position = new Vector2(0, GameEnvironment.Screen.Y - background_main.Height);
        backgrounds.Add(background_main);


        // add a few random mountains
        for (int i = 0; i < 5; i++)
        {
            GameObject mountain = MonoBehaviour.Instantiate(Resources.Load("Prefabs/BackgroundObjects/Mountain" + (Random.Range(1,3)))) as GameObject;
            //mountain.Position = new Vector2((float)GameEnvironment.Random.NextDouble() * GameEnvironment.Screen.X - mountain.Width / 2, GameEnvironment.Screen.Y - mountain.Height);
            Vector3 mountainSize = mountain.GetComponent<SpriteRenderer>().bounds.size;
            mountain.transform.position = Camera.main.ScreenToWorldPoint(new Vector3 (Random.value * Screen.width - mountainSize.x / 2, 0, 10));
            mountain.transform.SetParent(LevelObject.transform, true);
            backgrounds.Add(mountain);
        }



        for (int i = 0; i < 3; i++)
        {
            GameObject cloud = MonoBehaviour.Instantiate(Resources.Load("Prefabs/BackgroundObjects/Clouds")) as GameObject;
            cloud.transform.SetParent(LevelObject.transform, true);
            backgrounds.Add(cloud);
        }


        timer = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Overlay/Timer")) as GameObject;
        timer.transform.SetParent(LevelObject.transform, true);

        /*SpriteGameObject timerBackground = new SpriteGameObject("Sprites/spr_timer", 100);
        timerBackground.Position = new Vector2(10, 10);
        this.Add(timerBackground);
        TimerGameObject timer = new TimerGameObject(101, "timer");
        timer.Position = new Vector2(25, 30);
        this.Add(timer);

        quitButton = new Button("Sprites/spr_button_quit", 100);
        quitButton.Position = new Vector2(GameEnvironment.Screen.X - quitButton.Width - 10, 10);
        this.Add(quitButton);


        this.Add(new GameObjectList(1, "waterdrops"));
        this.Add(new GameObjectList(2, "enemies"));*/

        this.LoadTiles("Levels/" + levelIndex);
    }

    public bool Completed
    {
        get
        {
           /* SpriteGameObject exitObj = this.Find("exit") as SpriteGameObject;
            Player player = this.Find("player") as Player;
            if (!exitObj.CollidesWith(player))
                return false;
            GameObjectList waterdrops = this.Find("waterdrops") as GameObjectList;
            foreach (GameObject d in waterdrops.Objects)
                if (d.Visible)
                    return false;*/
            return true;
        }
    }

    public bool GameOver
    {
        get
        {
            /*
            TimerGameObject timer = this.Find("timer") as TimerGameObject;
            Player player = this.Find("player") as Player;
            return !player.IsAlive || timer.GameOver;
             */
            return false;
        }
       
    }

    public bool Locked
    {
        get { return locked; }
        set { locked = value; }
    }

    public bool Solved
    {
        get { return solved; }
        set { solved = value; }
    }
	
}
