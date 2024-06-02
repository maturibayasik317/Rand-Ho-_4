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

    // ハートを収集するためのメソッド
    public void CollectHeart(GameObject heart)
    {
        if (currentHearts < maxHearts)
        {
            currentHearts++;
            Destroy(heart);
            UpdateHeartUI();
        }
    }

    private void UpdateHeartUI()
    {
        Debug.Log("ハート表示"); // デバッグログを追加してメソッドが呼び出されていることを確認
        heartText.text = "Hearts: " + new string('a', currentHearts) + new string('□', maxHearts - currentHearts);
    }
}
