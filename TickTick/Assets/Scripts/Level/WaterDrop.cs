﻿/// <summary>
/// Controls the behaviour (bounce) of the water
/// </summary>

using UnityEngine;
using System.Collections;

public class WaterDrop : MonoBehaviour {

    private float bounce;

	// Use this for initialization
	void Start () {
	
	}

    void FixedUpdate()
    {
        float t = Time.realtimeSinceStartup * 3.0f + Camera.main.WorldToScreenPoint(gameObject.transform.position).x;
        bounce = Mathf.Sin(t) * 0.002f;
        transform.position = new Vector3(transform.position.x, transform.position.y + bounce, transform.position.z);
    }


	// Update is called once per frame
	void Update () {
       
        /*
         * TODO
         * Player player = GameWorld.Find("player") as Player;
        if (this.visible && this.CollidesWith(player))
        {
            this.visible = false;
            GameEnvironment.AssetManager.PlaySound("Sounds/snd_watercollected");
        }
         * */
	}
}