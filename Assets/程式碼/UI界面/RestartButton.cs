using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    //重置遊戲
    public void RestartGame()
    {
        //重載這個場景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
