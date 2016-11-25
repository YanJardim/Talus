using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerSkills : NetworkBehaviour {
    [SyncVar]
    public bool skillSelected;

    [SyncVar]
    Vector3 mouse;

    [SerializeField]
    public Skill currentSkill;

    public GameObject shot;

    public List<Skill> skills;

    public GameObject target;

    public Texture2D cursorSelectedSkill;

    private RaycastHit2D hit;


    private SpriteRenderer lastEnemyRend;
    private Color originalColor = Color.white;
    private LayerMask detectLayerMask;

    private Camera playerCamera;
    public bool canShoot;

    public GameObject a;
    // Use this for initialization
    void Start() {
        skillSelected = false;
        detectLayerMask = 1 << 8;
        detectLayerMask = ~detectLayerMask;
        canShoot = false;
        playerCamera = GetComponent<Player>().playerCamera;
    }

    // Update is called once per frame
    [Client]
    void Update() {
        //if (!isLocalPlayer) return;

        mouse = playerCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        SelectEnemy();


        if (Input.GetMouseButtonDown(1) && skillSelected)
        {
            SetCursor(false);
        }

        if (skillSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
               
                CmdFire(mouse);
            }
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
            if (lastEnemyRend != null) lastEnemyRend.color = originalColor;
        }
        skillSelected = b;
    }

    [Command]
    public void CmdFire(Vector2 dir)
    {

        if (canShoot)
        {
            currentSkill.power.GetComponent<SkillHit>().localPlayer = this.GetComponent<BaseCharacter>();
            currentSkill.CmdPower(dir);
            SetCursor(false);
            //currentSkill = null;
            canShoot = false;

        }
        else
        {
            SetCursor(false);
            currentSkill = null;
        }
    }

    [Client]
    public void SelectEnemy()
    {
        if (skillSelected)
        {
            hit = Physics2D.Raycast(mouse, Vector2.zero, 100f, detectLayerMask);
            
            
            if (hit.collider != null && hit.collider.tag == "Enemy")
            {
                
               
                lastEnemyRend = hit.collider.GetComponent<SpriteRenderer>();
                lastEnemyRend.color = Color.red;
                canShoot = true;
                
            }
            else
            {
                if (lastEnemyRend != null)
                {
                    lastEnemyRend.color = originalColor;
                    canShoot = false;
                }
            }
        }


    }

    
 }

 

