using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.Networking;

public abstract class Skill : NetworkBehaviour {

    public GameObject power;
    public GameObject target;
    public Button button;
    public Texture icon;

    public GUIStyle style;

    public int damage;
    public string targetTag;

    public bool enemyTarget;

    public abstract void SkillBehaviour();
    public abstract void UI();
    public abstract void Apply(GameObject target);

    [Command]
    public abstract void CmdPower(Vector2 direction);

    void Start()
    {
        if(power!= null)
            power.GetComponent<SkillHit>().skill = this;
    }

    public virtual void Action()
    {
        GetComponent<PlayerSkills>().SetCursor(true);
        GetComponent<PlayerSkills>().currentSkill = this;
    }
	
}
