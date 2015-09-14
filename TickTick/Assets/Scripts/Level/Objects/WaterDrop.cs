/// <summary>
/// Controls the behaviour (bounce) of the water
/// </summary>

using UnityEngine;
using System.Collections;

public class WaterDrop : SpriteObject {

    public AudioClip CollectSound;
    private float bounce;

	// Use this for initialization
	void Start () {
        base.Start();
	}

    void FixedUpdate()
    {
        float t = Time.realtimeSinceStartup * 3.0f + Camera.main.WorldToScreenPoint(gameObject.transform.position).x;
        bounce = Mathf.Sin(t) * 0.002f;
        WorldPosition = new Vector3(transform.position.x, transform.position.y + bounce, transform.position.z);
    }


	// Update is called once per frame
	void Update () {

        base.Update();

        bool collidesWithPlayer = false;

        if (visible && collidesWithPlayer /* this.CollidesWith(player)*/)
        {
            visible = false;
            AudioSource.PlayClipAtPoint(CollectSound, transform.position);
            
        }
    }


    public void Reset()
    {
        visible = true;
    }
}
