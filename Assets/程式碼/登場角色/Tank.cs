using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Character
{
    // Update is called once per frame
    void Update()
    {
        //看著塔
        transform.LookAt(gameManager.instance.tower.transform , Vector3.back);
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
