using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    public GameObject GoalPoint;
    private bool gameOver = false;

    [SceneField] public string PlayScene;
    [SceneField] public string gameClearScene;
    [SceneField] public string gameOverScene;
    [SceneField] public string startScene;
    [SceneField] public string Scene1;
    [SceneField] public string Scene2;
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
            gameOver = true;
            StartCoroutine(ChangeSceneAfterDelay("GameOver", 3.0f));
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("StartScene");
            Debug.Log("強制終了");
        }
    }

    IEnumerator ChangeSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameClearScene();
        }
    }
}
