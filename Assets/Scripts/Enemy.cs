using UnityEngine;
using UnityEngine.Networking;

using System.Collections;
using System.Collections.Generic;

public class Enemy : NetworkBehaviour {
    public List<GameObject> players = new List<GameObject>();
    public GameObject target;
    public float speed;

    // Use this for initialization
    void Start () {
        speed = GameManager.instance.enemySpeed;
 
    }

    // Update is called once per frame
    void Update()
    {
        ChangeTarget();
    }

    void FixedUpdate()
    {
        if (!isServer) return;

        if (target != null) //&& Vector2.Distance()
        {
            GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(transform.position, target.transform.position, speed) );
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            players.Add(other.gameObject);

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            players.Remove(other.gameObject);
        }
    }
    
    void ChangeTarget()
    {
        target = GetNearPlayer();

    }    

    GameObject GetNearPlayer()
    {
        GameObject near = null;
        if (players.Count == 0)
            return near;

        foreach(GameObject a in players)
        {
            if (near == null)
                near = a;

            else
            {
                if (Vector2.Distance(transform.position, a.transform.position) <
                        Vector2.Distance(transform.position, target.transform.position))
                {
                    near = a;
                }
            }
        }

        return near;
    }
}
