using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {
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
        //dir = transform.position - target;
        //rb.velocity = dir.normalized * speed * Time.deltaTime;
        rb.MovePosition(Vector2.MoveTowards(transform.position, target, speed));
    }
}
