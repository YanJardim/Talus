using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
public class PlayerSkills : NetworkBehaviour {
    public bool skillSelected;
    public Skill currentSkill;
    public Button bSkill1;
	// Use this for initialization
	void Start () {
        
        bSkill1 = GameObject.Find("Image").GetComponent<Button>();
	    bSkill1.onClick.AddListener(() => RpcSetColor());
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    [ClientRpc]
    void RpcSetColor()
    {
        if (!isLocalPlayer) return;
            GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
