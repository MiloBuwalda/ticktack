/// <summary>
/// Responsible for loading and creating levels
/// Shares functionality with PlayingState.cs in the xna version
/// </summary>

using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class LevelManager : MonoBehaviour {

    protected List<Level> levels = new List<Level>();
    protected int currentLevelIndex;
    protected int numberOfLevels = 10;

    public static LevelManager instance;

    // Singleton instance, to be able to call LevelManager.instance.   etc
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(this); // or gameObject

    }

	// Use this for initialization
	void Start () {
        UnlockAllLevels(); // TODO remove this debug call
        LoadLevels();
        LoadLevelsStatus();

	}
	
	// Update is called once per frame
	void Update () {
        //TODO implement this down here
	     
        //CurrentLevel.Update(gameTime);
       /* if (CurrentLevel.GameOver)
            GameStateManager.instance.SwitchTo(GameState.GameOverState);
        else if (CurrentLevel.Completed)
        {
            CurrentLevel.Solved = true;
            GameStateManager.instance.SwitchTo(GameState.LevelFinishedState);
        }*/
	}

    public Level CurrentLevel
    {
        get
        {
            return levels[currentLevelIndex];
        }
    }

    public int CurrentLevelIndex
    {
        get
        {
            return currentLevelIndex;
        }
        set
        {
            if (value >= 0 && value < levels.Count)
            {
                currentLevelIndex = value;
                //TODO  CurrentLevel.Reset();
            }
        }
    }

    public List<Level> Levels
    {
        get
        {
            return levels;
        }
    }
 



   /* public virtual void Reset()
    {
    * TODO
        CurrentLevel.Reset();
    }*/

    public void NextLevel()
    {
        // TODO CurrentLevel.Reset();
        if (currentLevelIndex >= levels.Count - 1)
            GameStateManager.instance.SwitchTo(GameState.LevelMenu);
        else
        {
            CurrentLevelIndex++;
            levels[currentLevelIndex].Locked = false;
        }
        WriteLevelsStatus();
    }

    // load all levels from their text files
    public void LoadLevels()
    {
        for (int currLevel = 1; currLevel <= numberOfLevels; currLevel++)
            levels.Add(new Level(currLevel));
    }

    // load the status of locked/solved levels from the unity player preferences (persistent storage)
    public void LoadLevelsStatus()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            string locked = PlayerPrefs.GetString(LevelStatus.Locked(i));
            string solved = PlayerPrefs.GetString(LevelStatus.Solved(i));


            // if no saved state is found for a level, set it to: (locked, unsolved)
            if (locked == "")
                levels[i].Locked = true;
            else
                levels[i].Locked = bool.Parse(locked);
            if (i == 0)
                levels[i].Locked = false; // ensure atleast the first level is unlocked


            if (solved == "")
                levels[i].Solved = false;              
            else
                levels[i].Solved = bool.Parse(solved);
        }
    }

    public void WriteLevelsStatus()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            PlayerPrefs.SetString(LevelStatus.Locked(i), levels[i].Locked.ToString());
            PlayerPrefs.SetString(LevelStatus.Solved(i), levels[i].Solved.ToString());
        }
    }

    // strings used for storing the level status in unity PlayerPrefs
    private struct LevelStatus
    {
        public static string Solved(int levelIndex)
        {
            return string.Format(string.Format("Level{0}.Solved", levelIndex));
        }

        public static string Locked(int levelIndex)
        {
            return string.Format(string.Format("Level{0}.Locked", levelIndex));
        }
    }

    // development method for testing levels
    private void UnlockAllLevels()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            PlayerPrefs.SetString(LevelStatus.Locked(i), false.ToString());
        }
    }

}
