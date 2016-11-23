using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject Enemy;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnEnemy());
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    IEnumerator SpawnEnemy()
    {
        while (true)
        {           
            yield return new WaitForSeconds(10f);          

            Instantiate(Enemy, this.transform.position, this.transform.rotation);          
        }       
        yield return null;
    }

}
