﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayHit : MonoBehaviour
{
    //射線檢測器需要以下數個功能
    //檢測畫面正中央有沒有打中坦克
    //播放音效

    //開火音效
    [SerializeField]
    AudioSource FireAudioSource;
    // Update is called once per frame
    void Update()
    {
        //假如得知遊戲已經輪掉就拒絕不做接下來的程式碼
        if (gameManager.instance.IsLose)
        {
            return;
        }

        //當按下滑鼠左鍵（GetMouseButtonDown(0)是左鍵也是手機點擊
        if (Input.GetMouseButtonDown(0))
        {
            //因為發射子彈，所以需要有開火聲
            FireAudioSource.Play();

            //求得手機晝面中心點
            Vector3 CenterScreenPoint = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
            //把手機晝面中心點轉為世界坐標
            Vector3 CenterGamePoint = Camera.main.ScreenToWorldPoint(CenterScreenPoint);

            //初設射線
            Ray ray = new Ray(CenterGamePoint, Camera.main.transform.forward * 100);
            //在Scene裡畫出一條紅線，好讓我們看到射線射在哪
            Debug.DrawLine(CenterGamePoint, CenterGamePoint + Camera.main.transform.forward * 100, Color.red);

            RaycastHit hit;
            //射線判定，結果會輸出在hit
            if (Physics.Raycast(ray, out hit, 100))
            {
                //試在射線結果中找出坦克特徵
                Tank enemy = hit.collider.GetComponent<Tank>();
                //確定射線結果真的為坦克
                if (enemy)
                {
                    //輸出100點傷害，這肯定必死了
                    enemy.BeAttacked(100);
                    //確定對方真的死透
                    if (enemy.isDead)
                    {
                        //總得分加一分
                        gameManager.instance.Score++;
                        //讓UI更新得分
                        ScoreUI.instance.UpdateText(gameManager.instance.Score);
                    }


                }
            }
        }

    }
}