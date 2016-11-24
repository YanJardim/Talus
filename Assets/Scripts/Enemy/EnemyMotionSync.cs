using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class EnemyMotionSync : NetworkBehaviour {
    [SyncVar]
    public Vector2 syncPos;

    public Vector2 lastPos;

    public float lerpRate = 10;
    public float posThreshold = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TransmitMotion();
        LerpMotion();
	}

    void TransmitMotion()
    {
        if (!isServer)
        {
            return;
        }

        if(Vector2.Distance(transform.position, lastPos) > posThreshold)
        {
            lastPos = transform.position;

            syncPos = transform.position;

        }
    }

    void LerpMotion()
    {
        if (!isServer)
        {
            return;
        }

        transform.position = Vector2.Lerp(transform.position, syncPos, Time.deltaTime * lerpRate);

    }
}
