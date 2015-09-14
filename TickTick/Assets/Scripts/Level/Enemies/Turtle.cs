using UnityEngine;
using System.Collections;

public class Turtle : SpriteObject {

    protected float sneezeTime;
    protected float idleTime;

    // TODO   animations & player collision 

	// Use this for initialization
	void Start () {
        base.Start();
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        if (sneezeTime > 0)
        {
            //this.PlayAnimation("sneeze");
            sneezeTime -= (float)Time.deltaTime;
            if (sneezeTime <= 0.0f)
            {
                idleTime = 5.0f;
                sneezeTime = 0.0f;
            }
        }
        else if (idleTime > 0)
        {
            //this.PlayAnimation("idle");
            idleTime -= (float)Time.deltaTime;
            if (idleTime <= 0.0f)
            {
                idleTime = 0.0f;
                sneezeTime = 5.0f;
            }
        }

        CheckPlayerCollision();
	}

    public void Reset()
    {
        sneezeTime = 0.0f;
        idleTime = 5.0f;
    }


    public void CheckPlayerCollision()
    {
       /* Player player = GameWorld.Find("player") as Player;
        if (!this.CollidesWith(player))
            return;
        if (sneezeTime > 0)
            player.Die(false);
        else if (idleTime > 0 && player.Velocity.Y > 0)
            player.Jump(1500);
         */
    }
}
