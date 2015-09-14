using UnityEngine;
using System.Collections;

public abstract class SpriteObject : MonoBehaviour {

    private Vector2 screenPosition;
    private float width;
    private float height;
    private Vector3 screenMinWorld;
    private Vector3 screenMaxWorld;

    private bool mirror;
 
    protected Vector2 velocity;
    protected float screenDepth = 10;

	// Use this for initialization
	protected void Start () {
        velocity = Vector2.zero;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition = new Vector2(screenPos.x, screenPos.y);
        calcDimensions();
        screenMinWorld = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, screenDepth));
        screenMaxWorld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, screenDepth));
	}
	
	// Update is called once per frame
	protected void Update () {
        if(velocity != Vector2.zero)
            transform.position = new Vector3(transform.position.x + (velocity.x * Time.deltaTime), transform.position.y + (velocity.y * Time.deltaTime), transform.position.z); 
	}

    protected Vector3 MinSpriteWorld
    {
        get { return GetComponent<SpriteRenderer>().bounds.min;}
    }

    protected Vector3 MaxSpriteWorld
    {
        get { return GetComponent<SpriteRenderer>().bounds.max; }
    }

    public Vector2 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    public bool Mirror
    {
        get { return mirror; }
        set { mirror = value; }
    }

    public Vector3 ScreenPosition
    {
        get { return screenPosition; }
        set { 
                screenPosition = value;
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, screenDepth));
            }
    }

    public Vector3 WorldPosition
    {
        get { return transform.position; }
        set
        {
            transform.position = value;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(value);
            screenPosition = new Vector2(screenPos.x, screenPos.y);
        }
    }

    public Vector3 ScreenMinWorld
    {
        get { return screenMinWorld; }
    }

    public Vector3 ScreenMaxWorld
    {
        get { return screenMaxWorld; }
    }
    public float Width
    {
        get { return width; }
    }

    public float Height
    {
        get { return height; }
    }

    protected bool visible 
    {
        get {return GetComponent<SpriteRenderer>().enabled;}
        set {GetComponent<SpriteRenderer>().enabled = value;}
    }


    protected void SetSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        calcDimensions();
    }

    private void calcDimensions()
    {
        // TODO check if bounds.size work too
        width = MaxSpriteWorld.x - MinSpriteWorld.x;
        height = MaxSpriteWorld.y - MinSpriteWorld.y;
    }

    
}
