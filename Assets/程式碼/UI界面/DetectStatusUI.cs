using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DetectStatusUI : MonoBehaviour
{
    [SerializeField]
    Text DetectStatusText;
    // Update is called once per frame
    void Update()
    {
        //如果在遊戲時未偵測到中AR物件就彈出提示
        if (gameManager.instance.isGameStart && !gameManager.instance.IsLose)
        {
            DetectStatusText.gameObject.SetActive(!gameManager.instance.isDetect);
        }
    }
}
