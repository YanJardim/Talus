using UnityEngine;
using System.Collections;

public class EnemyMelee : Enemy {
    void Start()
    {
        currentHP = maxHP;
        SetSpeedGameManager();
        distanceToStop = 0;
    }


}
