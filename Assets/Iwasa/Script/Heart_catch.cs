using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Heart_catch : MonoBehaviour
{
    public static Heart_catch instance;

    public int maxHearts = 3;
    public GameObject[] hearts; // ハートオブジェクトの配列
    public TextMeshProUGUI heartText; // ハートの数を表示するUIテキスト

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            Debug.Log("Heart collected");
            CollectHeart(other.gameObject);
        }
    }

    // ハートを収集するためのメソッド
    public void CollectHeart(GameObject Heart)
    {
        if (currentHearts < maxHearts)
        {
            currentHearts++;
            Destroy(Heart);
            UpdateHeartUI();
        }
    }

    private void UpdateHeartUI()
    {
        Debug.Log("ハート出現"); // デバッグログを追加してメソッドが呼び出されていることを確認
        heartText.text = "Hearts: " + new string('❤', currentHearts) + new string('□', maxHearts - currentHearts);
    }
}
