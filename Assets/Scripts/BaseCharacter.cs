using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class BaseCharacter : NetworkBehaviour {
    [SyncVar]
    public int level;
    [SyncVar]
    public int currentHp;
    [SyncVar]
    public int xp, xpToNextLevel;

    private float modifier;
    [SerializeField]
    private float maxHp;

    private BaseCharacter lastHit;

    public GameObject levelUpPrefab, damagePrefab;

    // Use this for initialization
    void Start () {
        level = 1;
        UpdateModifier();
        UpdateHp();
        UpdateXpToNextLevel();
        currentHp = (int)maxHp;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!isServer) return;

        CheckIsALive();
        CheckLevelUP();
    }

    public void CheckLevelUP()
    {
        if(xp >= xpToNextLevel)
        {
            int restXp = xpToNextLevel - xp;

            if(restXp >= 0)
                xp = restXp;

            LevelUp();
        }
    }

    public void LevelUp()
    {
        InstantiateEffect(levelUpPrefab, 1f);
        level++;
        UpdateModifier();
        UpdateHp();
        UpdateXpToNextLevel();
    }

    public void GainXp(BaseCharacter character)
    {
        //xp += character.level * Mathf.Log()
    }

    public void UpdateHp()
    {
        maxHp = (modifier + (10 * ((level * 0.15f) * modifier)));
    }
    public void UpdateModifier()
    {
        modifier = level + 20;
    }
    public void UpdateXpToNextLevel()
    {
        //print((100) * Mathf.Sqrt(level));
        xpToNextLevel = (int)((modifier) * (Mathf.Sqrt(level + (level*8f)) * 10));
    }

    public int GainXP()
    {
        return (int)(modifier * (level * Random.Range(0.3f, 0.6f)) + 30);
    }
    public void AddXP(int amount)
    {
        xp += amount;
    }

    public int GetXpToNextLevel()
    {
        return xpToNextLevel;
    }

    public void CheckIsALive()
    {
        if (!isAlive())
        {
            KillMe();
        }
    }

    public bool isAlive()
    {

        if (currentHp > 0)
        {
            return true;
        }

        return false;
    }

    public void KillMe()
    {
        if(lastHit != null)
        {
            lastHit.AddXP(GainXP());
        }
        NetworkServer.Destroy(gameObject);
        
    }

    public void TakeDamage(int amount)
    {
        if (!isServer) return;

      
        //print(damagePrefab.GetComponent<ParticleSystem>().duration);
        InstantiateEffect(damagePrefab, 1f);
       
        currentHp -= amount;       

    }

    public BaseCharacter GetLastHit()
    {
        return lastHit;
    }

    public void SetLastHit(BaseCharacter newValue)
    {
        lastHit = newValue;
    }

    public void InstantiateEffect(GameObject effectGameObject, float timeAlive)
    {
        if (effectGameObject != null)
        {
            effectGameObject = Instantiate(levelUpPrefab, transform.position, levelUpPrefab.transform.rotation) as GameObject;
            effectGameObject.transform.parent = this.transform;
            NetworkServer.Spawn(effectGameObject);
            effectGameObject.GetComponent<ParticleSystem>().Play();
            Destroy(effectGameObject, timeAlive);
        }
        else
            print("NULL reference to " + effectGameObject.transform.name + " in Basecharacter");
    }

    public void Heal(int amount)
    {
        currentHp = currentHp + amount > maxHp ? (int)maxHp : currentHp + amount;
    }
    
}
