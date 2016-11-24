using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class FollowTarget : NetworkBehaviour {
    [SyncVar]
    public Vector3 target;
    public float speed;
    public Rigidbody2D rb;
    public Vector2 dir;
    // Use this for initialization
    void Start () {
        
        speed = GameManager.instance.skillSpeed;
        
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void FixedUpdate()
    {
        dir = target - transform.position;

        if (Vector2.Distance(transform.position, target) > 0.1f)
        {
            rb.velocity = dir.normalized * speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
            Destroy(this.gameObject);
        }

        
    }
}
