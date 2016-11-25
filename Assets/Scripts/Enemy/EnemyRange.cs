using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyRange : Enemy
{
    public GameObject Tiro;

    void Start()
    {
        currentHP = maxHP;
        SetSpeedGameManager();        
        StartCoroutine(DeuDano());
    }
    
    void Update()
    {

    }   
     
    IEnumerator DeuDano()
    {
        if (acho == true)
        {
            GameObject t = GetNearPlayer();
            GameObject aux = Instantiate(Tiro, this.transform.position, Tiro.transform.rotation) as GameObject;
            aux.GetComponent<FollowTarget>().target = t.transform.position;
            yield return new WaitForSeconds(2.0f);
            StartCoroutine(DeuDano());
        }
    }
}
