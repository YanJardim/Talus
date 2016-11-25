using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : NetworkBehaviour
{
    public float speed;
    public Camera playerCamera;
      

    private Text hpText, levelText, xpText;

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer) return;
        //playerCamera.transform.FindChild("Camera").GetComponent<Camera>();
        GameManager.instance.AddPlayer(this.gameObject);

        hpText = GameObject.Find("HP").GetComponent<Text>();
        levelText = GameObject.Find("Level").GetComponent<Text>();
        xpText = GameObject.Find("XP").GetComponent<Text>();

    }


    void Update()
    {
        //Limite da tela
        /* var distanceZ = (transform.position - Camera.main.transform.position).z;
         var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).x;
         var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceZ)).x;
         var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).y;
         var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanceZ)).y;

         transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, rightBorder), Mathf.Clamp(transform.position.y, topBorder, bottomBorder), transform.position.z);*/
        hpText.text = "HP: " + GetComponent<BaseCharacter>().currentHp + "/" + (int)GetComponent<BaseCharacter>().maxHp;
        levelText.text = "Level: " + GetComponent<BaseCharacter>().level;
        xpText.text = "XP: " + GetComponent<BaseCharacter>().xp;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(h * speed * Time.deltaTime, v * speed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }

    public override void OnStartLocalPlayer()
    {
        //GameManager.instance.AddPlayer(this.gameObject);
    }



}
