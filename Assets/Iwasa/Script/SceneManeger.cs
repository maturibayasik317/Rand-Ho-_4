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
        GameManager.previousScene = SceneManager.GetActiveScene().name; // ���݂̃V�[������ۑ�
        SceneManager.LoadScene(PlayScene); // �Q�[����ʂɈړ�
        Debug.Log("�v���C�V�[���Ɉړ�");
    }

    public void GameClearScene()
    {
        GameManager.previousScene = SceneManager.GetActiveScene().name; // ���݂̃V�[������ۑ�
        SceneManager.LoadScene(gameClearScene); // �Q�[���N���A�V�[���Ɉړ�
        Debug.Log("�Q�[���N���A�Ɉړ�");
    }

    public void GameOverScene()
    {
        GameManager.previousScene = SceneManager.GetActiveScene().name; // ���݂̃V�[������ۑ�
        SceneManager.LoadScene(gameOverScene); // �Q�[���I�[�o�[��ʂɈړ�
        Debug.Log("�Q�[���I�[�o�[�V�[���Ɉړ�");
    }

    public void ReStartGame()
    {
        string sceneToLoad = GameManager.previousScene;
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            sceneToLoad = PlayScene; // �f�t�H���g�̃V�[����ݒ�
        }
        Debug.Log("���g���C�F" + sceneToLoad);

        try
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        catch (ArgumentException e)
        {
            Debug.LogError("The scene " + sceneToLoad + " cannot be loaded: " + e.Message);
            // �f�t�H���g�V�[���Ƀt�H�[���o�b�N
            SceneManager.LoadScene("DefaultSceneName");
        }
    }

    public void ReturnStartMenu()
    {
        SceneManager.LoadScene(startScene); // �X�^�[�g���j���[�ɑ�������V�[���Ɉړ�
        Debug.Log("�X�^�[�g��ʂɈړ�");
    }

    void Update()
    {
        // �Q�[���v���C�V�[���݂̂Ńv���C���[�̑��݂��m�F����
        if (SceneManager.GetActiveScene().name == PlayScene && !gameOver && GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOver = true;
            StartCoroutine(ChangeSceneAfterDelay("GameOver", 3.0f));
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("StartScene");
            Debug.Log("�����I��");
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
