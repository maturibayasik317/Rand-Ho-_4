using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class SceneManeger : MonoBehaviour
{
    public GameObject GoalPoint;
    private bool gameOver = false;

    [SceneField] public string PlayScene;//チュートリアルステージ
    [SceneField] public string gameClearScene;//クリアシーン
    [SceneField] public string gameOverScene;//ゲームオーバーシーン
    [SceneField] public string startScene;//スタート画面
    [SceneField] public string Scene1;//ステージ１
    [SceneField] public string Scene2;//ステージ２
    [SceneField] public string Scene3;//ステージ３
    public void StartGameScene()
    {
        GameManager.previousScene = SceneManager.GetActiveScene().name; // 現在のシーン名を保存
        SceneManager.LoadScene(PlayScene); // ゲーム画面に移動
        Debug.Log("プレイシーンに移動");
    }

    public void GameClearScene()
    {
        GameManager.previousScene = SceneManager.GetActiveScene().name; // 現在のシーン名を保存
        SceneManager.LoadScene(gameClearScene); // ゲームクリアシーンに移動
        Debug.Log("ゲームクリアに移動");
        StartCoroutine(DisplayHeart());
    }

    public void GameOverScene()
    {
        GameManager.previousScene = SceneManager.GetActiveScene().name; // 現在のシーン名を保存
        SceneManager.LoadScene(gameOverScene); // ゲームオーバー画面に移動
        Debug.Log("ゲームオーバーシーンに移動");
    }

    public void ReStartGame()
    {
        string sceneToLoad = GameManager.previousScene;
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            sceneToLoad = PlayScene; // デフォルトのシーンを設定
        }
        Debug.Log("リトライ：" + sceneToLoad);

        try
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        catch (ArgumentException e)
        {
            Debug.LogError("The scene " + sceneToLoad + " cannot be loaded: " + e.Message);
            // デフォルトシーンにフォールバック
            SceneManager.LoadScene("DefaultSceneName");
        }
    }

    public void ReturnStartMenu()
    {
        SceneManager.LoadScene(startScene); // スタートメニューに相当するシーンに移動
        Debug.Log("スタート画面に移動");
    }

    void Update()
    {
        // ゲームプレイシーンのみでプレイヤーの存在を確認する
        if (SceneManager.GetActiveScene().name == PlayScene && !gameOver && GameObject.FindGameObjectWithTag("Player") == null)
        {
            //Playerタグがない場合ゲームオーバー
            gameOver = true;
            StartCoroutine(ChangeSceneAfterDelay("GameOver", 3.0f));
        }
        //Pボタンを押すとスタート画面に戻る
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("StartScene");
            Debug.Log("強制終了");
        }
    }

    //シーンの移動処理
    IEnumerator ChangeSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    //ゲームクリアの処理    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameClearScene();
        }
    }

    //ハートの取得をクリアシーンに移動
    IEnumerator DisplayHeart()
    {
        yield return new WaitUntil(()  =>  SceneManager.GetActiveScene().name == gameClearScene);
        
        // プレイ中に取得したハート数を表示
        if (Heart_catch.instance != null)
        {
            TextMeshProUGUI heartText = GameObject.Find("HeartText").GetComponent<TextMeshProUGUI>();
            if (heartText != null)
            {
                int currentHearts = Heart_catch.instance.GetCurrentHearts();
                heartText.text = "Collected Hearts: " + currentHearts.ToString();
            }
            else
            {
                Debug.LogError("HeartText component not found in the scene.");
            }
        }
        else
        {
            Debug.LogError("Heart_catch instance not found.");
        }
    }
}

internal class SceneFieldAttribute1 : Attribute
{
}