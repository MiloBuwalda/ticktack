/// <summary>
/// A grid for the object in a level, (ported from xna version TileField.cs & ObjectGrid.cs)
/// </summary>

using UnityEngine;
using System.Collections;

public class TileField  {

    protected Tile[,] grid;
    protected int cellWidth, cellHeight;

    public TileField(int rows, int columns)
    {
        cellWidth = Screen.width / 20;
        cellHeight = Screen.height / 15;

        grid = new Tile[columns, rows];
        for (int x = 0; x < columns; x++)
            for (int y = 0; y < rows; y++)
                grid[x, y] = null;
    }

    public void Add(Tile obj, int x, int y)
    {
        grid[x, y] = obj;
        
        if (obj != null) // TODO remove these debug if statements
        {
            if (obj.gameObject != null)
            {
                Vector3 position =  new Vector3(((float)x + 0.5f) * cellWidth, Screen.height - (y + 0.5f) * cellHeight, 10);
                obj.gameObject.transform.position = Camera.main.ScreenToWorldPoint(position);
            }
        }
    }

    public Tile Get(int x, int y)
    {
        if (x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1))
            return grid[x, y];
        else
            return null;
    }

    public Tile[,] Objects
    {
        get
        {
            return grid;
        }
    }

    public Vector2 GetAnchorPosition(Tile s)
    {
        for (int x = 0; x < Columns; x++)
            for (int y = 0; y < Rows; y++)
                if (grid[x, y] == s)
                    return new Vector2(x * cellWidth, y * cellHeight);
        return Vector2.zero;
    }

    public int Rows
    {
        get { return grid.GetLength(1); }
    }

    public int Columns
    {
        get { return grid.GetLength(0); }
    }

    public int CellWidth
    {
        get { return cellWidth; }
        set { cellWidth = value; }
    }

    public int CellHeight
    {
        get { return cellHeight; }
        set { cellHeight = value; }
    }

    public TileType GetTileType(int x, int y)
    {
        if (x < 0 || x >= Columns)
            return TileType.Normal;
        if (y < 0 || y >= Rows)
            return TileType.Background;
        Tile current = this.Objects[x, y] as Tile;
        return current.TileType;
    }

  /*  TODO
   * public override void Reset()
    {
        base.Reset();
        foreach (GameObject obj in grid)
            obj.Reset();
    }*/
}
