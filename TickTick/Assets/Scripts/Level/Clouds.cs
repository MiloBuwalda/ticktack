using UnityEngine;
using System.Collections.Generic;

public class Clouds : MonoBehaviour {

    public List<Sprite> cloudSprites;
    float velocity = 0;


	// Use this for initialization
	void Start () {
        if(cloudSprites.Count > 0 )
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            SetRandomSprite();
            velocity = RandomXVelocity();
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(RandomX(), RandomY(), 10));       
        }
	}
	
	// Update is called once per frame
	void Update () {

        // left and right edge of sprite in screen coordinates
        float left  = Camera.main.WorldToScreenPoint(GetComponent<SpriteRenderer>().bounds.min).x;
        float right = Camera.main.ScreenToWorldPoint(GetComponent<SpriteRenderer>().bounds.max).x;

        // moving out of bounds
        if ((velocity < 0 && right < 0) || (velocity > 0 && left > Screen.width))
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            float width = GetComponent<SpriteRenderer>().bounds.size.x;
            velocity = RandomXVelocity();
            SetRandomSprite();
            float cloudHeight = RandomY();
            if (velocity < 0)
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + (width), cloudHeight, screenPos.z));
            else
            {
                transform.position = Camera.main.ScreenToWorldPoint((new Vector3(-width * 1.5f, cloudHeight, screenPos.z)));
            }
        }
        else
        {
            // move the cloud
            transform.position = new Vector3(transform.position.x + velocity * Time.deltaTime, transform.position.y, transform.position.z);
        }
	}

    private void SetRandomSprite()
    {
        int index = Random.Range(0, cloudSprites.Count);
        GetComponent<SpriteRenderer>().sprite = cloudSprites[index];
    }

    private float RandomX()
    {
        Vector3 extents = GetComponent<SpriteRenderer>().bounds.extents; // extents is size / 2
        return Random.value * Screen.width - extents.x;
    }

    private float RandomY()
    {
        Vector3 extents = GetComponent<SpriteRenderer>().bounds.extents; // extents is size /2
        return Screen.height - (Random.value * Screen.height - extents.y); //TODO check if this sin't upside down
    }

    private float RandomXVelocity()
    {
        return (Random.value * 2) - 1;
    }
}
