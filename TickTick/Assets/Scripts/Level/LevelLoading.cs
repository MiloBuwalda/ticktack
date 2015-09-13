using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.IO;

public partial class Level 
{
    public void LoadTiles(string path)
    {
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

        /*
        GameObjectList hintfield = new GameObjectList(100);
        this.Add(hintfield);
        string hint = textlines[textlines.Count - 1];
        SpriteGameObject hint_frame = new SpriteGameObject("Overlays/spr_frame_hint", 1);
        hintfield.Position = new Vector2((GameEnvironment.Screen.X - hint_frame.Width) / 2, 10);
        hintfield.Add(hint_frame);
        TextGameObject hintText = new TextGameObject("Fonts/HintFont", 2);
        hintText.Text = textlines[textlines.Count - 1];
        hintText.Position = new Vector2(120, 25);
        hintText.Color = Color.Black;
        hintfield.Add(hintText);
        VisibilityTimer hintTimer = new VisibilityTimer(hintfield, 1, "hintTimer");
        this.Add(hintTimer);
        */

        
        //this.Add(tiles);
      //  tiles.CellWidth = 72;
        //tiles.CellHeight = 55;

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
           /* case 'T':
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
                return LoadFlameTile(x, y, tileType);*/
            default:
                 return null; //new Tile("");
        }
    }

    private Tile LoadBasicTile(TileType tileType, bool hot = false, bool ice = false)
    {
        Tile t = new Tile(tileType);
        t.Hot = hot;
        t.Ice = ice;
        t.gameObject.transform.SetParent(LevelObject.transform, true);
        return t;
    }

    private Tile LoadStartTile(int x, int y)
    {
        Vector3 startPosition = new Vector3(((float)x + 0.5f) * tiles.CellWidth, Screen.height - (y ) * tiles.CellHeight, 10);
        player = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Player")) as GameObject;
        player.transform.SetParent(LevelObject.transform, true);
        player.transform.position = Camera.main.ScreenToWorldPoint(startPosition);
        
        return new Tile();
    }

  /*  private Tile LoadFlameTile(int x, int y, char enemyType)
    {
        GameObjectList enemies = this.Find("enemies") as GameObjectList;
        TileField tiles = this.Find("tiles") as TileField;
        GameObject enemy = null;
        switch (enemyType)
        {
            case 'A': enemy = new UnpredictableEnemy(); break;
            case 'B': enemy = new PlayerFollowingEnemy(); break;
            case 'C': 
            default:         enemy = new PatrollingEnemy(); break;
        }
        enemy.Position = new Vector2(((float)x + 0.5f) * tiles.CellWidth, (y + 1) * tiles.CellHeight);
        enemies.Add(enemy);
        return new Tile();
    }*/

   /* private Tile LoadTurtleTile(int x, int y)
    {
        GameObjectList enemies = this.Find("enemies") as GameObjectList;
        TileField tiles = this.Find("tiles") as TileField;
        Turtle enemy = new Turtle();
        enemy.Position = new Vector2(((float)x + 0.5f) * tiles.CellWidth, (y + 1) * tiles.CellHeight + 25.0f);
        enemies.Add(enemy);
        return new Tile();
    }*/


   /* private Tile LoadSparkyTile(int x, int y)
    {
        GameObjectList enemies = this.Find("enemies") as GameObjectList;
        TileField tiles = this.Find("tiles") as TileField;
        Sparky enemy = new Sparky((y + 1) * tiles.CellHeight - 100f);
        enemy.Position = new Vector2(((float)x + 0.5f) * tiles.CellWidth, (y + 1) * tiles.CellHeight - 100f);
        enemies.Add(enemy);
        return new Tile();
    }*/

   /* private Tile LoadRocketTile(int x, int y, bool moveToLeft)
    {
        GameObjectList enemies = this.Find("enemies") as GameObjectList;
        TileField tiles = this.Find("tiles") as TileField;
        Vector2 startPosition = new Vector2(((float)x + 0.5f) * tiles.CellWidth, (y + 1) * tiles.CellHeight);
        Rocket enemy = new Rocket(moveToLeft, startPosition);
        enemies.Add(enemy);
        return new Tile();
    }*/

    private Tile LoadEndTile(int x, int y)
    {
        end = MonoBehaviour.Instantiate(Resources.Load("Prefabs/LevelObjects/Goal")) as GameObject;
        end.transform.SetParent(LevelObject.transform, true);
        end.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x * tiles.CellWidth, Screen.height - (y) * tiles.CellHeight, 10));
        return new Tile();
    }

     private Tile LoadWaterTile(int x, int y)
     {
        GameObject w = MonoBehaviour.Instantiate(Resources.Load("Prefabs/LevelObjects/Water")) as GameObject;
         w.transform.SetParent(LevelObject.transform, true);

       //  w.Origin = w.Center;
         Vector3 position = new Vector3(x * tiles.CellWidth, Screen.height - y * tiles.CellHeight + 10, 10);
         position += new Vector3(tiles.CellWidth, - tiles.CellHeight, 0) / 2;
         //w.Position = new Vector2(x * tiles.CellWidth, y * tiles.CellHeight - 10);
         //w.Position += new Vector2(tiles.CellWidth, tiles.CellHeight) / 2;
         w.transform.position = Camera.main.ScreenToWorldPoint(position);
         waterdrops.Add(w);
         return new Tile();
     }
}
