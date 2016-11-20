using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : NetworkBehaviour {
	public float speed;
	public int tileRange;
	public Vector2 direction;
	public bool canMove;

	// Use this for initialization
	void Start () {
		tileRange = 1;
		canMove = true;
	}

	void Update(){

        if (canMove)
        {
            if (Input.GetKey(KeyCode.A))
            {
                direction = new Vector2(transform.position.x - tileRange, transform.position.y);
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction = new Vector2(transform.position.x + tileRange, transform.position.y);
            }
            if (Input.GetKey(KeyCode.W))
            {
                direction = new Vector2(transform.position.x, transform.position.y + tileRange);
            }
            if (Input.GetKey(KeyCode.S))
            {
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
}
