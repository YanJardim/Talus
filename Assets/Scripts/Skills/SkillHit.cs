using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SkillHit : NetworkBehaviour {
    public GameObject col;
    public Skill skill;

    public BaseCharacter localPlayer, enemy;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == skill.targetTag)
        {
            BaseCharacter enemyBase = collision.gameObject.GetComponent<BaseCharacter>();
            enemyBase.SetLastHit(localPlayer);
            if (!skill.heal)
            {
                enemyBase.TakeDamage(skill.damage);
            }
            else
            {
                enemyBase.Heal(skill.damage);
            }
            
            //CmdTakeDamage(collision.gameObject);
        }
    }
    
}
