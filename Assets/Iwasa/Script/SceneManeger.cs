using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    public void StartGameScene()
    {
        SceneManager.LoadScene("GamePlayScene");//�Q�[����ʂɈړ�
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");//�Q�[���I�[�o�[��ʂɈړ�
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
