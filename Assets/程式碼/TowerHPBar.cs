using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHPBar : MonoBehaviour
{
    [SerializeField]
    SimpleHealthBar SimpleHealthBar;

    // Update is called once per frame
    void Update()
    {
        SimpleHealthBar.UpdateBar(gameManager.instance.tower.HP , gameManager.instance.tower.MaxHP);
    }
}