using UnityEngine;
using System.Collections;

public class PlayerDetect : MonoBehaviour {
    public bool collide;
	// Use this for initialization
	void Start () {
        collide = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            collide = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            collide = false;
        }
    }
}
