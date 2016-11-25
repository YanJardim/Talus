using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : NetworkBehaviour
{
    public float speed;
    
    // Use this for initialization
    void Start()
    {
        
        GameManager.instance.AddPlayer(this.gameObject);

    }


    void Update()
    {
        //Limite da tela
        var distanceZ = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceZ)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanceZ)).y;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, rightBorder), Mathf.Clamp(transform.position.y, topBorder, bottomBorder), transform.position.z);

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
