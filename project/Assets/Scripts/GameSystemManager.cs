using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO; // ← ファイル保存、読み込みに必要

[System.Serializable]
public class SaveData
{
    public int HighScore;
}

public class GameSystemManager : MonoBehaviour

{

    public int Score;
    public int HighScore;
    public Text ScoreText;
    public Text HighScoreText;
    public Image HighScoreText_back;
    public bool IsHighScore;

    string path;

    void Start()
    {
        Time.timeScale = 1;
        path = Application.persistentDataPath + "/save.json";
        Load();
        HighScoreText.gameObject.SetActive(false);
        HighScoreText_back.gameObject.SetActive(false);
    }

    void Update()
    {
        ScoreText.text = Score.ToString();
    }
    public void Save()
    {
        // 保存用データを作成
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        // JSONの文字列に変換
        string json = JsonUtility.ToJson(data);
        // ファイルに書き込み
        File.WriteAllText(path, json);

        Debug.Log("保存完了だぜ!");
    }

    public void CheckHighScore()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
            IsHighScore = true;
            Save();
        }
        else
        {
            IsHighScore = false;
        }
    }

    public void Load()
    {
        // ファイルが存在するか確認
        if (File.Exists(path))
        {
            // 文字列として読み込む
            string json = File.ReadAllText(path);
            // JSONからSaveDataに変換
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            // ハイスコアに適用
            HighScore = data.HighScore;

            Debug.Log("ロード完了だぜ!");
        }
    }
}
