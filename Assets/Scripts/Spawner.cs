using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Spawner : NetworkBehaviour {

    public GameObject Enemy;
    public GameObject EnemyRanged;
    private float spawnRatio;
    public List<GameObject> points = new List<GameObject>();


	// Use this for initialization
	void Start ()
    {
        if (!isServer) return;
        spawnRatio = GameManager.instance.spawnRatio;
        StartCoroutine(SetPoints());
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    IEnumerator SpawnEnemy()
    {
        while (true)
        {            
            yield return new WaitForSeconds(spawnRatio);          

            GameObject e = Instantiate(Enemy, points[Random.Range(0, points.Count)].transform.position, this.transform.rotation) as GameObject;
            NetworkServer.Spawn(e);    
        }       
        yield return null;
    }

    IEnumerator SetPoints()
    {
        yield return new WaitForSeconds(0.2f);
        //points = new List<GameObject>(GameObject.FindGameObjectsWithTag("Point"));
        StartCoroutine(SpawnEnemy());
    }

}
