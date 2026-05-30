using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float Timer = 60;
    public Text TimerText;
    public GameObject ClearWindow;
    public GameObject Player;
    public GameSystemManager GameSystemManager;

    void Start()
    {
        
    }

    void Update()
    {
        if (Player)
        {
            Timer -= Time.deltaTime;
            TimerText.text = ((int)Timer).ToString();
        }

        if (Timer <= 0)
        {
            GameSystemManager.CheckHighScore();
            ClearWindow.SetActive(true);
            if (GameSystemManager.IsHighScore)
            {
                GameSystemManager.HighScoreText.gameObject.SetActive(true);
                GameSystemManager.HighScoreText_back.gameObject.SetActive(true);
            }
            Time.timeScale = 0;
            enabled = false; // タイマーを停止
            //enabled = false;はスクリプトを無効化することで、Updateメソッドの呼び出しを停止する
        }
    }
}
