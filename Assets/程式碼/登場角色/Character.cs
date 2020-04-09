using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //通用角色設定需要以下數個功能
    //攻擊對方
    //被對方攻擊
    //死亡

    /// <summary>
    /// 當死亡時的爆炸特效
    /// </summary>
    public GameObject ExplosionEffectObject;

    /// <summary>
    /// 生命值上限
    /// </summary>
    public int MaxHP;
    /// <summary>
    /// 當前生命值
    /// </summary>
    public int HP;

    private void Start()
    {
        //初始化生命值
        HP = MaxHP;
    }

    /// <summary>
    /// 是否死亡
    /// </summary>
    public bool isDead
    {
        get
        {
            //生命值到0時就會死
            return (HP <= 0);
        }
    }

    /// <summary>
    /// 輸出傷害給另一單位
    /// </summary>
    /// <param name="Target">是攻擊哪一個目標</param>
    /// <param name="Dmg">輸出多少傷害</param>
    public void AttackedOtherCharacter(Character Target, int Dmg)
    {
        Target.BeAttacked(Dmg);
    }

    /// <summary>
    /// 被攻擊時
    /// </summary>
    /// <param name="DmgTaken">被攻擊了多少傷害</param>
    public void BeAttacked(int DmgTaken)
    {
        HP -= DmgTaken;

        if (isDead)
        {
            OnDead();
        }
    }

    /// <summary>
    /// 當角色死亡時
    /// </summary>
    public abstract void OnDead();
    /// <summary>
    /// 生成爆炸特效
    /// </summary>
    public void SpawnExpEffect()
    {
        GameObject Effect = Instantiate(ExplosionEffectObject, transform.position, Quaternion.identity);
        //計時3
        Destroy(Effect, 3f);
    }
}
