using UnityEngine;
using System.Collections;

public class Sparky : SpriteObject {

    protected float idleTime;
    protected float yoffset;
    private float initialY;

    // TODO animations, position, player collision

	// Use this for initialization
	void Start () {
        base.Start();
        //this.LoadAnimation("Sprites/Sparky/spr_electrocute@6x5", "electrocute", false);
       // this.LoadAnimation("Sprites/Sparky/spr_idle", "idle", true);
       // this.PlayAnimation("idle");
       // this.initialY = initialY;
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        if (idleTime <= 0)
        {
            //this.PlayAnimation("electrocute");
            if (velocity.y != 0)
            {
                // falling down
                yoffset -= velocity.y * (float)Time.deltaTime;
                if (yoffset <= 0)
                    velocity.y = 0;
                else if (yoffset >= 120.0f)
                    this.Reset();
            }
            else //if (Current.AnimationEnded)
                velocity.y = 1;
        }
        else
        {
           // this.PlayAnimation("idle");
            idleTime -= (float)Time.deltaTime;
            if (idleTime <= 0.0f)
                velocity.y = -1;

        }

        CheckPlayerCollision();
	}


    public float InitialY
    {
        get { return initialY; }
        set { initialY = value; }
    }

    public void Reset()
    {
        idleTime = Random.value * 5;
        float initialWorldY = Camera.main.ScreenToWorldPoint(new Vector3(0, initialY, 0)).y;
        WorldPosition = new Vector3(transform.position.x, initialWorldY, transform.position.y);
        yoffset = 120;
        velocity.y = 0;
    }   

    public void CheckPlayerCollision()
    {
       /* Player player = GameWorld.Find("player") as Player;
        if (this.CollidesWith(player) && idleTime <= 0.0f)
            player.Die(false);
        * */
    }
}
