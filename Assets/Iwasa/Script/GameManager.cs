using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //制限時間系
    public TextMeshProUGUI timerText;
    public float timeRemaining = 180; //制限時間
    public GameObject PlayerObuject;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void DisplayTime(float timeToDisplay)//残り時間の表示
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format(" {0:00}:{1:00}", minutes, seconds);
    }
}
