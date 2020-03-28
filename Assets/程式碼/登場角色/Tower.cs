using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Character
{

    public override void OnDead()
    {
        //塔死亡時就會失敗
        print("GameOver" );
        SpawnExpEffect();
    }
}
