using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerSkills : NetworkBehaviour {
    public bool skillSelected;

    public Skill currentSkill;
    public List<Skill> skills;

    public Texture2D cursorSelectedSkill;


    // Use this for initialization
    void Start() {
        skillSelected = false;

    }

    // Update is called once per frame
    void Update() {
        if (!isLocalPlayer) return;

        if (Input.GetMouseButtonDown(1) && skillSelected)
        {
            SetCursor(false);
        }
        else if (Input.GetMouseButtonDown(0) && skillSelected)
        {
            CmdFire();
        }
    }

    public void SetCursor(bool b)
    {
        if (!isLocalPlayer) return;

        if (b)
        {
            
            Cursor.SetCursor(cursorSelectedSkill, new Vector2(cursorSelectedSkill.width/2, cursorSelectedSkill.height/2), CursorMode.Auto);
        }

        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        skillSelected = b;
    }

    [Command]
    public void CmdFire()
    {
        GameObject aux = Instantiate(currentSkill.power, transform.position, currentSkill.power.transform.rotation) as GameObject;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        aux.GetComponent<FollowTarget>().target = mouse;
        NetworkServer.Spawn(aux);
        Destroy(aux, 1.0f);
        SetCursor(false);
    }

    
 }

 

