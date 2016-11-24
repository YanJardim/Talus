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

    public abstract void SkillBehaviour();
    public abstract void UI();

    public virtual void Action()
    {
        GetComponent<PlayerSkills>().SetCursor(true);
        GetComponent<PlayerSkills>().currentSkill = this;
    }
	
}
