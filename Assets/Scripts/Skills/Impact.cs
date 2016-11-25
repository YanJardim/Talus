using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

public class Impact : Skill {

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

    public override void Apply(GameObject target)
    {

    }

    [Command]
    public override void CmdPower(Vector2 direction)
    {
        Debug.Log("Antes do Power");
        GameObject aux = Instantiate(power, transform.position, power.transform.rotation) as GameObject;
        NetworkServer.Spawn(aux);
        aux.GetComponent<FollowTarget>().target = direction;
        Destroy(aux, 1.0f);
        Debug.Log("Depois do Power");
    }

    public new void Action()
    {
        Debug.Log("Antes do Action");
        GetComponent<PlayerSkills>().SetCursor(true);
        GetComponent<PlayerSkills>().currentSkill = this;
        Debug.Log("Depois do Action");
    }

    [ClientRpc]
    public void RpcAction()
    {
        
    }

   


}
