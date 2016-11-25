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

    }


    void Update()
    {
        //Limite da tela
        /*var distanceZ = (transform.position - playerCamera.transform.position).z;
        var leftBorder = playerCamera.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).x;
        var rightBorder = playerCamera.ViewportToWorldPoint(new Vector3(1, 0, distanceZ)).x;
        var topBorder = playerCamera.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).y;
        var bottomBorder = playerCamera.ViewportToWorldPoint(new Vector3(0, 1, distanceZ)).y;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, rightBorder), Mathf.Clamp(transform.position.y, topBorder, bottomBorder), transform.position.z);*/

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
