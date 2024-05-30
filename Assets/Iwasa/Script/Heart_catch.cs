using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart_catch : MonoBehaviour
{
    public static Heart_catch instance;

    public int maxHearts = 3;
    public GameObject[] hearts; // ハートオブジェクトの配列
    public Text heartText; // ハートの数を表示するUIテキスト

    private int currentHearts = 0; // 現在のハートの数

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateHeartUI();
    }

    // ハートを収集するためのメソッド
    public void CollectHeart(GameObject heart)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] == heart)
            {
                currentHearts++;
                Destroy(heart); // ハートを破壊
                UpdateHeartUI();
                break;
            }
        }
    }

    private void UpdateHeartUI()
    {
        heartText.text = "Hearts: " + new string('?', currentHearts) + new string('?', maxHearts - currentHearts);
    }
}