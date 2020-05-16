using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHPBar : SingletonMonoBehavior<TowerHPBar>
{
    //生命條組件
    [SerializeField]
    SimpleHealthBar SimpleHealthBar;

    // Update is called once per frame
    void Update()
    {
        
        //實時更新當前血量
        SimpleHealthBar.UpdateBar(gameManager.instance.tower.HP , gameManager.instance.tower.MaxHP);
    }
}