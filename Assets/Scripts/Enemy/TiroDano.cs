using UnityEngine;
using System.Collections;

public class TiroDano : MonoBehaviour {

    public float speed = 5.0f;

    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {            
            other.gameObject.GetComponent<BaseCharacter>().TakeDamage(7);
            Destroy(this.gameObject);
        }
    }
}
