using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : NetworkBehaviour {
	public float speed;
	public float tileRange;
	public Vector2 direction, lastPosition;
	public bool canMove, left, right, up, down;

    public PlayerDetect detectLeft, detectRight, detectUp, detectDown;

	// Use this for initialization
	void Start () {
		canMove = true;
        left = right = up = down = true;
        detectLeft = transform.FindChild("Left").GetComponent<PlayerDetect>();
        detectRight = transform.FindChild("Right").GetComponent<PlayerDetect>();
        detectUp = transform.FindChild("Up").GetComponent<PlayerDetect>();
        detectDown = transform.FindChild("Down").GetComponent<PlayerDetect>();
        //detect = transform.FindChild("Detect").gameObject;
    }

	void Update(){
        left = detectLeft.collide;
        right = detectRight.collide;
        up = detectUp.collide;
        down = detectDown.collide;

        if (canMove)
        {
            if (Input.GetKey(KeyCode.A) && !left)
            {
                lastPosition = transform.position;
                direction = new Vector2(transform.position.x - tileRange, transform.position.y);
                
            }
            if (Input.GetKey(KeyCode.D) && !right)
            {
                lastPosition = transform.position;
                direction = new Vector2(transform.position.x + tileRange, transform.position.y);
            }
            if (Input.GetKey(KeyCode.W) && !up)
            {
                lastPosition = transform.position;
                direction = new Vector2(transform.position.x, transform.position.y + tileRange);
            }
            if (Input.GetKey(KeyCode.S) && !down)
            {
                lastPosition = transform.position;
                direction = new Vector2(transform.position.x, transform.position.y - tileRange);
            }
        }

        if (transform.position != new Vector3(direction.x, direction.y, transform.position.z))
        {
            canMove = false;
        }
        else canMove = true;
			
	}

	// Update is called once per frame
	void FixedUpdate () {
        if (!isLocalPlayer)
        {
            return;
        }
        GetComponent<Rigidbody2D>().MovePosition (Vector2.MoveTowards( transform.position, direction, speed));
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    

}
