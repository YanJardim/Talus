using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyRange : Enemy
{
    public GameObject bullet;
    public bool cooldown;
    public float ratio;
    void Start()
    {
        cooldown = true;
        currentHP = maxHP;
        SetSpeedGameManager();

    }
    
    void Update()
    {
        if (canShot && cooldown)
        {
            StartCoroutine(Damage());
        }
    }   
     
    IEnumerator Damage()
    {
        
        GameObject t = GetNearPlayer();
        GameObject aux = Instantiate(bullet, this.transform.position, bullet.transform.rotation) as GameObject;
        aux.GetComponent<FollowTarget>().target = t.transform.position;
        StartCoroutine(Cooldown());
        yield return null;           
               
    }

    IEnumerator Cooldown()
    {
        cooldown = false;
        yield return new WaitForSeconds(ratio);
        cooldown = true;
    }
}
