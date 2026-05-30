using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour

{
    public GameObject Player;
    public GameObject GameOverCanvas;

    void Update()
    {
        if (!Player)
        {
            GameOverCanvas.SetActive(true);
        }
        
    }

    public void GameReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //リスタート(リセット)関数
    }
}
