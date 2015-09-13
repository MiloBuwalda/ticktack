/// <summary>
/// Controls the behaviour (bounce) of the water
/// </summary>

using UnityEngine;
using System.Collections;

public class WaterDrop : MonoBehaviour {

    public AudioClip CollectSound;
    private float bounce;
    private bool visible;

	// Use this for initialization
	void Start () {
        visible = true;
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
         */ 
        bool collidesWithPlayer = false;

        if (this.visible && collidesWithPlayer /* this.CollidesWith(player)*/)
        {
            visible = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = visible;
            AudioSource.PlayClipAtPoint(CollectSound, transform.position);
            
        }
    }


    public void Reset()
    {
        if (!visible)
        {
            visible = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = visible;
        }
    }
}
