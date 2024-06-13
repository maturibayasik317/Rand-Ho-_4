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

    [SceneField] public string PlayScene;//�`���[�g���A���X�e�[�W
    [SceneField] public string gameClearScene;//�N���A�V�[��
    [SceneField] public string gameOverScene;//�Q�[���I�[�o�[�V�[��
    [SceneField] public string startScene;//�X�^�[�g���
    [SceneField] public string Scene1;//�X�e�[�W�P
    [SceneField] public string Scene2;//�X�e�[�W�Q
    [SceneField] public string Scene3;//�X�e�[�W�R
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
        StartCoroutine(DisplayHeart());
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
            //Player�^�O���Ȃ��ꍇ�Q�[���I�[�o�[
            gameOver = true;
            StartCoroutine(ChangeSceneAfterDelay("GameOver", 3.0f));
        }
        //P�{�^���������ƃX�^�[�g��ʂɖ߂�
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("StartScene");
            Debug.Log("�����I��");
        }
    }

    //�V�[���̈ړ�����
    IEnumerator ChangeSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    //�Q�[���N���A�̏���    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameClearScene();
        }
    }

    //�n�[�g�̎擾���N���A�V�[���Ɉړ�
    IEnumerator DisplayHeart()
    {
        yield return new WaitUntil(()  =>  SceneManager.GetActiveScene().name == gameClearScene);
        
        // �v���C���Ɏ擾�����n�[�g����\��
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