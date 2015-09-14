using UnityEngine;
using System.Collections;

public class UnpredictableEnemy : PatrollingEnemy
{

	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        if (waitTime > 0 || Random.value > 0.01)
            return;
        TurnAround();
        velocity.x = Mathf.Sign(velocity.x) * Random.value * 5.0f;       
	}


}
