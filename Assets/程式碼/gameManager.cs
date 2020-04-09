using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
public class gameManager : SingletonMonoBehavior<gameManager>
{
    /// <summary>
    /// 總得分
    /// </summary>
    public int Score;

    /// <summary>
    /// 取得本場景塔數據（塔在這場景是唯一存在，所以存放在GameManager給所有程式讀取
    /// </summary>
    public Tower tower;
    /// <summary>
    /// 取得本場景塔的坐標
    /// </summary>
    public Vector3 HitTowerVector3
    {
        get
        {
            return tower.transform.position;
        }
    }
    /// <summary>
    /// 遊戲是否開始了
    /// </summary>
    public bool isGameStart = false;

    /// <summary>
    /// 調查一下塔是不是已經死亡，如果塔已死亡就代表已經輸了
    /// </summary>
    public bool IsLose
    {
        get
        {
            return tower.isDead;
        }
    }
    /// <summary>
    /// 取得本場景所使用的AR圖片元件
    /// </summary>
    [SerializeField]
     ImageTargetBehaviour ARImage;
    /// <summary>
    /// 取得本場景AR圖片元件下的遊戲地面
    /// </summary>
    [SerializeField]
    public Transform GameGround;
    /// <summary>
    /// UI上的遊戲結束畫面畫布
    /// </summary>
    [SerializeField]
    GameObject GameLoseCanvas;

    /// <summary>
    /// 準星畫布
    /// </summary>
    [SerializeField]
    public GameObject SightingUI;

    /// <summary>
    /// 檢查當前AR圖片有沒有被偵測到
    /// </summary>
    public bool isDetect
    {
        get
        {
            return (ARImage.CurrentStatus == TrackableBehaviour.Status.DETECTED ||
             ARImage.CurrentStatus == TrackableBehaviour.Status.TRACKED ||
             ARImage.CurrentStatus == TrackableBehaviour.Status.EXTENDED_TRACKED);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //如果輸掉就把遊戲結束畫面輸出
        if (IsLose)
        {
            SightingUI.SetActive(false);
            GameLoseCanvas.SetActive(true);
            return;
        }

        //檢查當前AR圖片
        if (isDetect)
        {
            //存在AR圖片就繼續運行遊戲
            Time.timeScale = 1;
        }
        else
        {
            //不存在AR圖片就先暫停遊戲
            Time.timeScale = 0;
        }
    }


}
