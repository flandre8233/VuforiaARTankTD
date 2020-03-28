using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    /// <summary>
    /// 初始生成坦克所需秒數
    /// </summary>
    [SerializeField]
    float InitCoolDown;
    /// <summary>
    /// 當前生成秒數值
    /// </summary>
    float CurCoolDown;

    /// <summary>
    /// 遊戲總時長
    /// </summary>
    float TotalTime;
    /// <summary>
    /// 遊戲難度
    /// </summary>
    int Level = 1;
    /// <summary>
    /// 生成坦克所需秒數
    /// </summary>
    float CoolDown
    {
        //運算求得當前的生成坦克所需秒數是多少
        get
        {
            //讓初始秒數跟遊戲難度有關係 難度每上升一級 所需秒數就會加快0.3秒
            float val = InitCoolDown + 0.3f - (0.3f * Level);

            //不過新的所需秒數已到0時，就把輸出數值強制鎖在0.1
            if (val <= 0)
            {
                return 0.1f;
            }
            return val;
        }
    }

    /// <summary>
    /// 坦克的Prefab
    /// </summary>
    [SerializeField]
    GameObject TankPrefab;

    // Update is called once per frame
    void Update()
    {
        //如果遊戲未開始就不做生成敵人
        if (!gameManager.instance.isGameStart)
        {
            return;
        }

        //計時器運算
        if (CoolDown <= CurCoolDown)
        {
            //時間到就生成一台坦克在遊戲地面上
            SpawnTank(CircleRandomPoint(), gameManager.instance.GameGround);
            //重置計時器
            CurCoolDown = 0;
        }
        //運算計時
        CurCoolDown += Time.deltaTime;

        //計遊戲總時長
        TotalTime += Time.deltaTime;
        //每10秒就增加一級難度
        if (TotalTime >= 10 * Level)
        {
            Level++;
        }
    }

    /// <summary>
    /// 隨機求得在中心點（0,0）的圓形坐標
    /// </summary>
    /// <returns>輸出一個隨機後的極坐標</returns>
    Vector3 CircleRandomPoint()
    {
        //給極坐標隨機數據
        Vector2 Polar = PolarToCartesian(Random.Range(0,360f), Random.Range(3,5f) );
        return new Vector3(Polar.x , 0 , Polar.y );
    }

    /// <summary>
    /// 極坐標運算
    /// </summary>
    /// <param name="angle">角度</param>
    /// <param name="radius">半徑距離</param>
    /// <returns>輸出極坐標</returns>
    public static Vector2 PolarToCartesian(float angle, float radius)
    {
        float angleRad = (Mathf.PI / 180.0f) * (angle - 90f);
        float x = radius * Mathf.Cos(angleRad);
        float y = radius * Mathf.Sin(angleRad);
        return new Vector2(x, y);
    }
    /// <summary>
    /// 坦克生成器
    /// </summary>
    /// <param name="spawnPoint">要在哪一點生成</param>
    /// <param name="Parent">生成後要和哪一個父物件綁定</param>
    void SpawnTank(Vector3 spawnPoint , Transform Parent)
    {
        //生成坦克
        GameObject SpawnedObj = Instantiate(TankPrefab, Parent);
        //為這剛生成的坦克設定他的坐標（因為極坐標輸出是以0,0作中心點，而塔就在GameGround的正中央，所以可以把極坐標數值設定至坦克localPosition而不是世界坐標
        SpawnedObj.transform.localPosition = spawnPoint;
    }

}
