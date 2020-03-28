using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : SingletonMonoBehavior<ScoreUI>
{
    [SerializeField]
    Text Score;

    private void Start()
    {
        Score.text = "分數：" + 0;
    }


    /// <summary>
    /// 更新分數數值
    /// </summary>
    /// <param name="Val">顯示數值</param>
    public void UpdateText(int Val)
    {
        Score.text = "分數：" + Val.ToString();
    }
}
