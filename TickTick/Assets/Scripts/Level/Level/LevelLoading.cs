/// <summary>
/// port of LevelLoading.cs in xna version
/// responsible for creating entities in a level
/// </summary>

using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.IO;

public partial class Level 
{
    public void LoadTiles(string path)
    {
        // read level file
        int width;
        List<string> textlines = new List<string>();
        TextAsset data = Resources.Load(path) as TextAsset;

        StringReader stringReader = new StringReader(data.text);
        string line = stringReader.ReadLine();
        width = line.Length;
        while (line != null)
        {
            textlines.Add(line);
            line = stringReader.ReadLine();
        }

        tiles = new TileField(textlines.Count - 1, width);


        GameObject quit = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Quit")) as GameObject;
        quit.transform.SetParent(LevelObject.transform, true);


        hint = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Overlay/Hint")) as GameObject;
        hint.transform.SetParent(LevelObject.transform, true);
        hint.GetComponent<Hint>().Text = textlines[textlines.Count - 1];
        

        for (int x = 0; x < width; ++x)
            for (int y = 0; y < textlines.Count - 1; ++y)
            {
                Tile t = LoadTile(textlines[y][x], x, y);
                tiles.Add(t, x, y);

            }

    }

    private Tile LoadTile(char tileType, int x, int y)
    {
        switch (tileType)
        {
            case '.':
                return new Tile();
            case '-':
                return LoadBasicTile(TileType.Platform);
            case '+':
                return LoadBasicTile(TileType.Platform, true, false);
            case '@':
                return LoadBasicTile(TileType.Platform, false, true);
            case 'X':
                return LoadEndTile(x, y);
            case 'W':
                return LoadWaterTile(x, y);
            case '1':
                return LoadStartTile(x, y);
            case '#':
                return LoadBasicTile(TileType.Normal);
            case '^':
                return LoadBasicTile(TileType.Normal, true, false);
            case '*':
                return LoadBasicTile(TileType.Normal, false, true);
            case 'T':
                return LoadTurtleTile(x, y);
            case 'R':
                return LoadRocketTile(x, y, true);
            case 'r':
                return LoadRocketTile(x, y, false);
            case 'S':
                return LoadSparkyTile(x, y);
            case 'A':
            case 'B':
            case 'C':
                return LoadFlameTile(x, y, tileType);
            default:
                 return new Tile();
        }
    }

    private Tile LoadBasicTile(TileType tileType, bool hot = false, bool ice = false)
    {
        Tile t = new Tile(tileType, hot, ice);
        t.gameObject.transform.SetParent(LevelObject.transform, true);
        return t;
    }

    private Tile LoadStartTile(int x, int y)
    {
        Vector3 startPosition = new Vector3(((float)x + 0.5f) * tiles.CellWidth, Screen.height - y * tiles.CellHeight, 10);
        player = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Player")) as GameObject;
        player.transform.SetParent(LevelObject.transform, true);
        player.transform.position = Camera.main.ScreenToWorldPoint(startPosition);   
        return new Tile();
    }

    private Tile LoadFlameTile(int x, int y, char enemyType)
    {
        GameObject enemy = null;
        switch (enemyType)
        {
            case 'A': enemy = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Unpredictable")) as GameObject; break;
            case 'B': enemy = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/PlayerFollowing")) as GameObject; break;
            case 'C':
            default: enemy = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Patrolling")) as GameObject; break;
        }
        enemy.GetComponent<PatrollingEnemy>().ScreenPosition = new Vector2(((float)x + 0.5f) * tiles.CellWidth, Screen.height - y * tiles.CellHeight);
        enemy.transform.SetParent(LevelObject.transform, true);
        enemies.Add(enemy);
        return new Tile();
    }

    private Tile LoadTurtleTile(int x, int y)
    {
        GameObject turtle = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Turtle")) as GameObject;
        turtle.GetComponent<Turtle>().ScreenPosition = new Vector2(((float)x + 0.5f) * tiles.CellWidth, Screen.height - y * tiles.CellHeight + 25.0f);
        turtle.transform.SetParent(LevelObject.transform, true);
        enemies.Add(turtle);
        return new Tile();
    }


    private Tile LoadSparkyTile(int x, int y)
    {
        GameObject sparky = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Sparky")) as GameObject;
        float initialY = Screen.height - y * tiles.CellHeight + 100f;
        sparky.GetComponent<Sparky>().InitialY = initialY;
        sparky.GetComponent<Sparky>().ScreenPosition = new Vector2(((float)x + 0.5f) * tiles.CellWidth, initialY);
        sparky.transform.SetParent(LevelObject.transform, true);
        enemies.Add(sparky);
        return new Tile();
    }

    private Tile LoadRocketTile(int x, int y, bool moveToLeft)
    {
        GameObject rocket = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Rocket")) as GameObject;
        rocket.transform.SetParent(LevelObject.transform, true);
        rocket.GetComponent<Rocket>().ScreenPosition = new Vector2(((float)x + 0.5f) * tiles.CellWidth, Screen.height - y * tiles.CellHeight);
        rocket.GetComponent<Rocket>().StartPosition = rocket.GetComponent<Rocket>().WorldPosition;

        rocket.GetComponent<Rocket>().Mirror = moveToLeft;




        enemies.Add(rocket);
        return new Tile();
    }

    private Tile LoadEndTile(int x, int y)
    {
        end = MonoBehaviour.Instantiate(Resources.Load("Prefabs/LevelObjects/Goal")) as GameObject;
        end.transform.SetParent(LevelObject.transform, true);
        end.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x * tiles.CellWidth, Screen.height - y * tiles.CellHeight, 10));
        return new Tile();
    }

     private Tile LoadWaterTile(int x, int y)
     {
        GameObject w = MonoBehaviour.Instantiate(Resources.Load("Prefabs/LevelObjects/Water")) as GameObject;
         w.transform.SetParent(LevelObject.transform, true);

       //  w.Origin = w.Center; ??
         Vector2 position = new Vector2(x * tiles.CellWidth, Screen.height - y * tiles.CellHeight + 10);
         position += new Vector2(tiles.CellWidth, - tiles.CellHeight) / 2;
         w.GetComponent<WaterDrop>().ScreenPosition = position;
         waterdrops.Add(w);
         return new Tile();
     }
}
