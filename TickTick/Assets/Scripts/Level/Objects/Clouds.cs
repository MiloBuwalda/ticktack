/// <summary>
/// Class to control the behaviour of clouds
/// </summary>

using UnityEngine;
using System.Collections.Generic;

public class Clouds : SpriteObject {

    public List<Sprite> cloudSprites;


	// Use this for initialization
	void Start () {
        base.Start();
        if(cloudSprites.Count > 0 )
        {
            SetRandomSprite();
            velocity.x = RandomXVelocity();
            WorldPosition = new Vector3(RandomXWorld(), RandomYWorld(), 10);
        }
	}

	// Update is called once per frame
	void Update () {
        base.Update();


        // moving out of bounds
        if ((velocity.x < 0 && MaxSpriteWorld.x < ScreenMinWorld.x) || (velocity.x > 0 && MinSpriteWorld.x > ScreenMaxWorld.x))
        {
            velocity.x = RandomXVelocity();
            SetRandomSprite();
            float cloudHeight = RandomYWorld();
            if (velocity.x < 0)
            {
                WorldPosition = new Vector3(ScreenMaxWorld.x + Width / 2f, cloudHeight, WorldPosition.z);
            }
            else
            {
                WorldPosition = new Vector3(ScreenMinWorld.x - Width / 2f, cloudHeight, WorldPosition.z);
            }
        }
	}

    private void SetRandomSprite()
    {
        int index = Random.Range(0, cloudSprites.Count);
        SetSprite(cloudSprites[index]);
    }

    private float RandomXWorld()
    {
        return Random.Range(ScreenMinWorld.x, ScreenMaxWorld.x);
    }

    private float RandomYWorld()
    {
        return Random.Range(ScreenMinWorld.y, ScreenMaxWorld.y); 
    }

    private float RandomXVelocity()
    {
        return Random.Range(- 0.5f, 0.5f);
    }
}
