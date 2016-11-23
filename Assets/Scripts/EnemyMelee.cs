using UnityEngine;
using System.Collections;

public class EnemyMelee : Enemy {
    void Start()
    {
        SetSpeedGameManager();
        distanceToStop = 0;
    }


}
