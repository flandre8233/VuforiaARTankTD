using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartButton : SingletonMonoBehavior<StartButton>
{
   
    public void StartGame()
    {
        //隱藏這按鈕
        gameObject.SetActive(false);
        gameManager.instance.SightingUI.SetActive(true);
        //發出開始遊戲信號
        gameManager.instance.isGameStart = true;
    }

}
