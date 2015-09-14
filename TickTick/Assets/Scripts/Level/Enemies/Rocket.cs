using UnityEngine;
using System.Collections;

public class Rocket : SpriteObject {

    protected double spawnTime;
    protected Vector3 startPosition;

    // TODO animaitons & player collision

	// Use this for initialization
	void Start () {
        base.Start();
       // this.LoadAnimation("Sprites/Rocket/spr_rocket@3", "default", true, 0.2f);
       // this.PlayAnimation("default");
       // this.Mirror = moveToLeft;
        Reset();

	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
            return;
        }
        visible = true;
        velocity.x = 5;
        if (Mirror)
            velocity.x *= -1f;
        CheckPlayerCollision();
        // check if we are outside the screen

        Vector3 rocketleft = GetComponent<SpriteRenderer>().bounds.min;
        Vector3 rocketright = GetComponent<SpriteRenderer>().bounds.max;

        if(rocketright.x < ScreenMinWorld.x || rocketleft.x > ScreenMaxWorld.x)
            this.Reset();
	}

    public  void Reset()
    {
        visible = false;
        transform.position = startPosition;
        velocity = Vector2.zero;
        this.spawnTime = Random.value * 5;
    }


    public Vector3 StartPosition
    {
        get { return startPosition; }
        set { startPosition = value; }
    }

    public void CheckPlayerCollision()
    {
       /* Player player = GameWorld.Find("player") as Player;
        if (this.CollidesWith(player) && this.Visible)
            player.Die(false);*/
    }
}
