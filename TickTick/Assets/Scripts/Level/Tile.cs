/// <summary>
/// Port of tile.cs in xna version
/// with added unity GameObject for in the scene
/// </summary>

using UnityEngine;
using System.Collections;

public enum TileType
{
    Background,
    Normal,
    Platform
}

public class Tile {

    protected TileType type;
    protected bool hot;
    protected bool ice;
    public GameObject gameObject;

    public Tile(TileType tp = TileType.Background)
    {
        type = tp;
        hot = false;
        ice = false;
        if (type != TileType.Background)
            setGameObject();      
    }

    private void setGameObject()
    {
        if (type == TileType.Normal)
        {
            if(hot)
                gameObject = MonoBehaviour.Instantiate(Resources.Load("Prefabs/LevelObjects/WallHot")) as GameObject;
            else if (ice)
                gameObject = MonoBehaviour.Instantiate(Resources.Load("Prefabs/LevelObjects/WallIce")) as GameObject;
            else
                gameObject = MonoBehaviour.Instantiate(Resources.Load("Prefabs/LevelObjects/Wall")) as GameObject;
        }
        else if (type == TileType.Platform)
        {
            if (hot)
                gameObject = MonoBehaviour.Instantiate(Resources.Load("Prefabs/LevelObjects/PlatformHot")) as GameObject;
            else if (ice)
                gameObject = MonoBehaviour.Instantiate(Resources.Load("Prefabs/LevelObjects/PlatformIce")) as GameObject;
            else
                gameObject = MonoBehaviour.Instantiate(Resources.Load("Prefabs/LevelObjects/Platform")) as GameObject;
        }
    }

    public TileType TileType
    {
        get { return type; }
    }

    public bool Hot
    {
        get { return hot; }
        set { hot = value; }
    }

    public bool Ice
    {
        get { return ice; }
        set { ice = value; }
    }
}
