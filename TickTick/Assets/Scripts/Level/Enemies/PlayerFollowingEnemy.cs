using UnityEngine;
using System.Collections;

public class PlayerFollowingEnemy : PatrollingEnemy
{

	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {

        GameObject playerObj = LevelManager.instance.CurrentLevel.Player;
        Player player = playerObj.GetComponent<Player>();

        float direction = player.WorldPosition.x - WorldPosition.x;
        if (Mathf.Sign(direction) != Mathf.Sign(velocity.x) && player.Velocity.x != 0.0f && velocity.x != 0.0f)
            TurnAround();
        base.Update();
    }


}
