using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

public class Impact : Skill {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public override void SkillBehaviour()
    {

    }

    void OnGUI()
    {
        if (!isLocalPlayer) return;
        UI();
    }

    public override void UI()
    {
        if(GUI.Button(new Rect(new Vector2(Screen.width / 2 - icon.width, Screen.height - icon.height - 10), new Vector2(icon.width, icon.height)), icon, style))
        {
            Action();
        }
    }

    public override void Action()
    {
        GetComponent<PlayerSkills>().SetCursor(true);
        GetComponent<PlayerSkills>().currentSkill = this;
    }


}
