using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartUI : MonoBehaviour
{
    [SerializeField]
    Button StartButton;

    private void Update()
    {
        //如果在遊戲未開始時未偵測到中AR物件就不讓遊戲開始
        if (!gameManager.instance.isGameStart)
        {
            StartButton.gameObject.SetActive(gameManager.instance.isDetect);
        }
    }
}
