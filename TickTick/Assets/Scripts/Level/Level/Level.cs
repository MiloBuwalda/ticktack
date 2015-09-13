/// <summary>
/// Port of level.cs in xna version
/// responsible for creating level instance
/// </summary>
using UnityEngine;
using System.Collections.Generic;

public partial class Level  {

    protected bool locked, solved;

    public GameObject LevelObject;

    private List<GameObject> backgrounds;
    private GameObject timer;
    private List<GameObject> waterdrops = new List<GameObject>();
    private List<GameObject> enemies;
    private TileField tiles;
    private GameObject player;
    private GameObject end;
    private GameObject hint;

    public Level(int levelIndex)
    {
        LevelObject = new GameObject("Level" + levelIndex);
        LevelObject.SetActive(false);
        LevelObject.transform.SetParent(LevelManager.instance.gameObject.transform);
        
        // load the backgrounds
        backgrounds = new List<GameObject>();
        GameObject background_main = MonoBehaviour.Instantiate(Resources.Load("Prefabs/BackgroundCanvas")) as GameObject;
        background_main.transform.SetParent(LevelObject.transform, true);
        backgrounds.Add(background_main);


        // add a few random mountains
        for (int i = 0; i < 5; i++)
        {
            GameObject mountain = MonoBehaviour.Instantiate(Resources.Load("Prefabs/BackgroundObjects/Mountain" + (Random.Range(1,3)))) as GameObject;
            mountain.transform.SetParent(LevelObject.transform, true);
            // TODO nicer way to get correct sprite dimensions
            Vector3 min = Camera.main.WorldToScreenPoint(mountain.GetComponent<SpriteRenderer>().bounds.min);
            Vector3 max = Camera.main.WorldToScreenPoint(mountain.GetComponent<SpriteRenderer>().bounds.max);
            Vector3 dif = max - min;
            mountain.transform.position = Camera.main.ScreenToWorldPoint(new Vector3 (Random.value * Screen.width , dif.y / 2f, 10));
            backgrounds.Add(mountain);
        }

        // add random clouds
        for (int i = 0; i < 3; i++)
        {
            GameObject cloud = MonoBehaviour.Instantiate(Resources.Load("Prefabs/BackgroundObjects/Clouds")) as GameObject;
            cloud.transform.SetParent(LevelObject.transform, true);
            backgrounds.Add(cloud);
        }

        timer = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Overlay/Timer"), Camera.main.ScreenToWorldPoint(new Vector3(80,Screen.height - 50, 10)), Quaternion.identity) as GameObject;
        timer.transform.SetParent(LevelObject.transform);

        this.LoadTiles("Levels/" + levelIndex);
    }

    public bool Completed
    {
        get
        {
           /* TODO
            * SpriteGameObject exitObj = this.Find("exit") as SpriteGameObject;
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
            /* TODO
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
