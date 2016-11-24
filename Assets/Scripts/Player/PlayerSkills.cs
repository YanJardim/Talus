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

    public Skill currentSkill;
    public GameObject shot;

    public List<Skill> skills;

    public GameObject target;

    public Texture2D cursorSelectedSkill;

    private RaycastHit2D hit;


    private SpriteRenderer lastEnemyRend;
    private Color originalColor = Color.white;
    private LayerMask detectLayerMask;
    // Use this for initialization
    void Start() {
        skillSelected = true;
        detectLayerMask = 1 << 8;
        detectLayerMask = ~detectLayerMask;
    }

    // Update is called once per frame
    void Update() {
        if (!isLocalPlayer) return;

        mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        

        if (Input.GetMouseButtonDown(1) && skillSelected)
        {
            //SetCursor(false);
        }

        if (skillSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                CmdFire(mouse);
            }
        }

        SelectEnemy();

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
    public void CmdFire(Vector2 direction)
    {
        GameObject aux = Instantiate(shot, transform.position, shot.transform.rotation) as GameObject;
             


        aux.GetComponent<FollowTarget>().target = direction;
        NetworkServer.Spawn(aux);
        Destroy(aux, 1.0f);
        //SetCursor(false);
    }

    [Client]
    public void SelectEnemy()
    {
        if (skillSelected)
        {
            //Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            hit = Physics2D.Raycast(mouse, Vector2.zero, 100f, detectLayerMask);
            //hit = Physics2D.Linecast(rayPos, transform.position);
            Debug.DrawRay(transform.position, hit.point, Color.yellow);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy") //&& hit.collider.isTrigger == false)
                {


                    lastEnemyRend = hit.collider.GetComponent<SpriteRenderer>();

                    lastEnemyRend.color = Color.red;
                    //ChangeEnemyColor();
                }


            }
            else
            {
                if (lastEnemyRend != null)
                {
                    lastEnemyRend.color = originalColor;
                }
            }
        }


    }

    /*[Client]
    void ChangeEnemyColor()
    {
        lastEnemyColor = lastEnemyRend.color;
        if (inside)
        {

            lastEnemyRend.color = Color.red;

        }
        else lastEnemyRend.color = lastEnemyColor;
    }*/

    
 }

 

