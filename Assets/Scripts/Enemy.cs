using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public GameObject target;
    public float speed;
    public bool canMove, left, right, up, down;
    private PlayerDetect detectLeft, detectRight, detectUp, detectDown;

    public Vector2 direction;
    // Use this for initialization
    void Start () {
        speed = GameManager.instance.enemySpeed;

        direction.Set(0, 0);
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (target != null) //&& Vector2.Distance()
        {
            GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(transform.position, target.transform.position, speed) );
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
        }
    }    
}
