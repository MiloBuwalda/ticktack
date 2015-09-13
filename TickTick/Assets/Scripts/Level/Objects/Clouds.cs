/// <summary>
/// Class to control the behaviour of clouds
/// </summary>

using UnityEngine;
using System.Collections.Generic;

public class Clouds : MonoBehaviour {

    public List<Sprite> cloudSprites;
    float velocity;

    // bottom left and top right of screen in world coordinates
    private Vector3 screenMin;
    private Vector3 screenMax;


	// Use this for initialization
	void Start () {
        if(cloudSprites.Count > 0 )
        {
            SetRandomSprite();
            velocity = RandomXVelocity();
            transform.position = new Vector3(RandomX(), RandomY(), 10);
            screenMin = Camera.main.ScreenToWorldPoint(Vector3.zero);
            screenMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            Debug.Log(screenMin + " - " + screenMax);
        }
	}


	// Update is called once per frame
	void Update () {
        // move the cloud
        transform.position = new Vector3(transform.position.x + (velocity * Time.deltaTime), transform.position.y, transform.position.z);  

        // bottom left and top right of sprite in screen coordinates
        Vector3 cloudleft = GetComponent<SpriteRenderer>().bounds.min;
        Vector3 cloudright = GetComponent<SpriteRenderer>().bounds.max;

        // moving out of bounds
        if ((velocity < 0 && cloudright.x < screenMin.x) || (velocity > 0 && cloudleft.x > screenMax.x))
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            velocity = RandomXVelocity();
            SetRandomSprite();
            // sprite dimensions could have changed
            cloudleft = GetComponent<SpriteRenderer>().bounds.min;
            cloudright = GetComponent<SpriteRenderer>().bounds.max;
            float width = cloudright.x - cloudleft.x;
            float cloudHeight = RandomY();
            if (velocity < 0)
            {
                transform.position = new Vector3(screenMax.x + width / 2f, cloudHeight, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(screenMin.x - width / 2f, cloudHeight, transform.position.z);
            }
        }
	}

    private void SetRandomSprite()
    {
        int index = Random.Range(0, cloudSprites.Count);
        GetComponent<SpriteRenderer>().sprite = cloudSprites[index];
    }

    private float RandomX()
    {
        return Random.Range(screenMin.x, screenMax.x);
    }

    private float RandomY()
    {
        return Random.Range(screenMin.y, screenMax.y); 
    }

    private float RandomXVelocity()
    {
        return Random.Range(- 0.5f, 0.5f);
    }
}
