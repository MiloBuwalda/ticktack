using UnityEngine;
using System.Collections;

public class PatrollingEnemy : SpriteObject
{

    protected float waitTime;

    // TODO animations & player collision

    // Use this for initialization
    protected void Start()
    {
        base.Start();
        waitTime = 0.0f;
        velocity.x = 120;
        //this.LoadAnimation("Sprites/Flame/spr_flame@9", "default", true);
        //this.PlayAnimation("default");
    }

    // Update is called once per frame
    protected void Update()
    {
       // base.Update(gameTime);
        if (waitTime > 0)
        {
            waitTime -= (float)Time.deltaTime;
            if (waitTime <= 0.0f)
                TurnAround();
        }
        else
        {
            TileField tiles = LevelManager.instance.CurrentLevel.Tiles;
            float posX = MinSpriteWorld.x;
            if (!Mirror)
                posX = MaxSpriteWorld.x;
            int tileX = (int)Mathf.Floor(posX / tiles.CellWidth);
            int tileY = (int)Mathf.Floor(ScreenPosition.y / tiles.CellHeight);
            if (tiles.GetTileType(tileX, tileY - 1) == TileType.Normal ||
                tiles.GetTileType(tileX, tileY) == TileType.Background)
            {
                waitTime = 0.5f;
                velocity.x = 0.0f;
            }
        }
        this.CheckPlayerCollision();
    }


    public void CheckPlayerCollision()
    {
        /*Player player = GameWorld.Find("player") as Player;
        if (this.CollidesWith(player))
            player.Die(false);*/
    }

    public void TurnAround()
    {
        Mirror = !Mirror;
        velocity.x = 120;
        if (Mirror)
            velocity.x = -velocity.x;
    }

}