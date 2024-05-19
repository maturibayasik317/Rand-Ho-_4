using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    public GameObject GoalPoint;
    private bool gameOver = false;

    public void StartGameScene()
    {
        GameManager.previousScene = SceneManager.GetActiveScene().name; // 現在のシーン名を保存
        SceneManager.LoadScene("Iwasa"); // ゲーム画面に移動
        Debug.Log("プレイシーンに移動");
    }

    public void GameClearScene()
    {
        GameManager.previousScene = SceneManager.GetActiveScene().name; // 現在のシーン名を保存
        SceneManager.LoadScene("GameClear"); // ゲームクリアシーンに移動
        Debug.Log("ゲームクリアに移動");
    }

    public void GameOverScene()
    {
        GameManager.previousScene = SceneManager.GetActiveScene().name; // 現在のシーン名を保存
        SceneManager.LoadScene("GameOver"); // ゲームオーバー画面に移動
        Debug.Log("ゲームオーバーシーンに移動");
    }

    public void ReStartGame()
    {
        string sceneToLoad = GameManager.previousScene;
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            sceneToLoad = "Iwasa"; // デフォルトのシーンを設定
        }
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("リトライ：" + sceneToLoad);
    }

    public void ReturnStartMenu()
    {
        SceneManager.LoadScene("StartScene"); // スタートメニューに相当するシーンに移動
        Debug.Log("スタート画面に移動");
    }

    void Update()
    {
        // ゲームプレイシーンのみでプレイヤーの存在を確認する
        if (SceneManager.GetActiveScene().name == "Iwasa" && !gameOver && GameObject.FindGameObjectWithTag("Player") == null)
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
