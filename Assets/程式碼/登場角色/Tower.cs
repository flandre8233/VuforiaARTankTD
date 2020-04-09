using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Character
{
    //因為塔繼承通用角色設定，所以他已經會有：攻擊對方、被對方攻擊、死亡

    public override void OnDead()
    {
        //塔死亡時就會失敗
        print("GameOver" );
        SpawnExpEffect();
    }
}
