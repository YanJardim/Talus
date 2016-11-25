using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : NetworkBehaviour
{
    public float speed;
    public Camera playerCamera;

    public int maxHp, currentHp;
    
    // Use this for initialization
    void Start()
    {
        //playerCamera.transform.FindChild("Camera").GetComponent<Camera>();
        GameManager.instance.AddPlayer(this.gameObject);
        currentHp = maxHp;
    }


    void Update()
    {
        

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
