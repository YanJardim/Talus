using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera mainCamera;

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else
        {
            mainCamera = Camera.main;
            if (mainCamera != null) mainCamera.gameObject.SetActive(false);
        }

        Register("Player");
	}

    void Register(string prefix)
    {
        string id = prefix + GetComponent<NetworkIdentity>().netId;
        transform.name = id;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnDisable()
    {
        if(mainCamera != null)
        {
            mainCamera.gameObject.SetActive(true);
        }
    }
}
