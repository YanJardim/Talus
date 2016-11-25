using UnityEngine;
using UnityEngine.Networking;

using System.Collections;
using System.Collections.Generic;

public abstract class Enemy : NetworkBehaviour {
    public int maxHP;

    [SerializeField]
    [SyncVar]
    protected int currentHP;
    public bool canShot;
    protected List<GameObject> players = new List<GameObject>();
    public GameObject target;
    public float speed;
    public float distanceToStop;
    

    // Use this for initialization
    void Start () {
        SetSpeedGameManager();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeTarget();
        RemoveMissing();
    }

    void FixedUpdate()
    {
        IA();
    }

    protected void IA()
    {
        if (!isServer) return;

        if (target != null) //&& Vector2.Distance()
        {
            if (Vector2.Distance(transform.position, target.transform.position) > distanceToStop)
            {
                GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(transform.position, target.transform.position, speed));
                canShot = false;
            }
            else
                canShot = true;
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
    
    protected void ChangeTarget()
    {
        target = GetNearPlayer();

    }    

    public GameObject GetNearPlayer()
    {
        GameObject near = null;
        if (players.Count == 0)
            return near;

        foreach(GameObject a in players)
        {
            if (near == null)
                near = a;

            else if(target != null)
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

    protected void SetSpeedGameManager()
    {
        speed = GameManager.instance.enemySpeed;
    }

    protected void RemoveMissing()
    {
        players.RemoveAll(GameObject => GameObject == null);
    }

    

}
