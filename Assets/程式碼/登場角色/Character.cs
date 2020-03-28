using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
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

    public bool isDead
    {
        get
        {
            return (HP <= 0);
        }
    }

    /// <summary>
    /// 輸出傷害給另一單位
    /// </summary>
    /// <param name="Target">是攻擊哪一個目標</param>
    /// <param name="Dmg">輸出多少傷害</param>
    public void AttackedOtherCharacter(Character Target ,int Dmg)
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

    public void SpawnExpEffect()
    {
        GameObject Effect = Instantiate(ExplosionEffectObject, transform.position, Quaternion.identity);
        Destroy(Effect, 3f);
    }
}
