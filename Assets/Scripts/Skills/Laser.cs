using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

public class Laser : Skill {

	// Use this for initialization
	
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

    [Command]
    public override void CmdPower(Vector2 direction)
    {

    }

    public override void Apply(GameObject target)
    {

    }

    public new void Action()
    {
        GetComponent<PlayerSkills>().SetCursor(true);
        GetComponent<PlayerSkills>().currentSkill = this;
    }

    [ClientRpc]
    public void RpcAction()
    {
        
    }

   


}
