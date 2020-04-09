using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Character
{
    //因為坦克繼承通用角色設定，所以他已經會有：攻擊對方、被對方攻擊、死亡
    //接下來新增以下功能
    //看著塔
    //然後前進
    //判定是否撞上塔


    // Update is called once per frame
    void Update()
    {
        //看著塔
        transform.LookAt(gameManager.instance.tower.transform);
        //往看著的方向移動
        transform.position += transform.forward * Time.deltaTime;

        Vector3 PointA = transform.position;
        Vector3 PointB = gameManager.instance.HitTowerVector3;
        //偵測當前坦克和塔的距離
        if (Vector3.Distance(PointA, PointB) <= 0.5f ) {
            //如果有相近就做坦克自爆和輸出傷害給塔
            OnDead();
            AttackedOtherCharacter(gameManager.instance.tower,1);

        }

    }

    public override void OnDead()
    {
        //移除該坦克
        Destroy(gameObject);
        SpawnExpEffect();
    }
}
