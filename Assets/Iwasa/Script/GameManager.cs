using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //制限時間系
    public TextMeshProUGUI timerText;
    public float timeRemaining = 180; //制限時間
    public GameObject PlayerObuject;
    private bool isTimeLow = false; // 時間が少ないかどうかを確認する

    //シーン移動を記録する
    public static string previousScene;

    void Start()
    {
        Debug.LogError("Timer Text is not assigned!");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)//制限時間の処理
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            Destroy(PlayerObuject);//プレイヤーの破壊
            timerText.text = "TIME UP!!";//タイムアップのメッセージ
            this.enabled = false; //タイマーを停止
            Debug.Log("TIME UP!!");
        }

        // 残り時間が1分未満になったらテキストの色を赤に変更
        if (!isTimeLow && timeRemaining <= 60)
        {
            timerText.color = Color.red;
            isTimeLow = true; 
        }
    }

    void DisplayTime(float timeToDisplay)//残り時間の表示
    {
        if (timerText == null)
        {
            Debug.LogError("Timer Text is not assigned!");
            return;
        }

        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format(" {0:00}:{1:00}", minutes, seconds);
    }
}
