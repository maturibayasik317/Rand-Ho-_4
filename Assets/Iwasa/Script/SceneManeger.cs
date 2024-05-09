using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    public void StartGameScene()
    {
        SceneManager.LoadScene("GamePlayScene");//ゲーム画面に移動
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");//ゲームオーバー画面に移動
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
