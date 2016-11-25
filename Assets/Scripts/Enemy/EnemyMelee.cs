using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyMelee : Enemy {

   public bool relando;

    void Start()
    {
        currentHP = maxHP;
        SetSpeedGameManager();
        distanceToStop = 0;        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            relando = true;
            StartCoroutine(DeuDano(other.gameObject));
        }        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            relando = true;            
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            relando = false;            
    }

    IEnumerator DeuDano(GameObject other)
    {        
        if(relando == true && other != null )
        {            
            other.gameObject.GetComponent<BaseCharacter>().TakeDamage(10);
            yield return new WaitForSeconds(2.0f);
            StartCoroutine(DeuDano(other.gameObject));
        }       
    }
}
