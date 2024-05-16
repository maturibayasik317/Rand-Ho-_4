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
        SceneManager.LoadScene("Iwasa");//ゲーム画面に移動
        Debug.Log("プレイシーンに移動");
    }

    public void GameClearScene()
    {
        SceneManager.LoadScene("GameClear");//ゲームクリアシーンに移動
        Debug.Log("ゲームクリアに移動");
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOver");//ゲームオーバー画面に移動
        Debug.Log("ゲームオーバーシーンに移動");
    }

    public void RestartGame()
    {
        // 現在のシーンを再ロードする
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("リトライ");
    }

    public void ReturnStartMenu()
    {
        // スタートメニューに相当するシーンに移動する
        SceneManager.LoadScene("StartScene");
    }
    // Update is called once per frame
    void Update()
    {
        if (!gameOver && GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOver = true;
            StartCoroutine(ChangeSceneAfterDelay("GameOver", 3.0f));
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
