using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

public class Heal : Skill {

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
        if(GUI.Button(new Rect(new Vector2(Screen.width / 2 - icon.width *2.5f , Screen.height - icon.height - 10), new Vector2(icon.width, icon.height)), icon, style))
        {

            Action();
        }
    }

    public override void Apply(GameObject target)
    {
        //target.GetComponent<Player>().cu
    }

    [Command]
    public override void CmdPower(Vector2 direction)
    {
        if (power.transform.name == "Impact") print("PQP");
        GameObject aux = Instantiate(power, transform.position, power.transform.rotation) as GameObject;
        NetworkServer.Spawn(aux);
        aux.GetComponent<FollowTarget>().target = direction;
        //Destroy(aux, 1.0f);
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
