using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {
    public static GameManager instance;
    public float enemySpeed;
    public List<GameObject> players = new List<GameObject>();

    public float gridSize = 0.32f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void AddPlayer(GameObject player)
    {
        players.Add(player);
    }
    void Awake()
    {
        instance = this;
    }

}
