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
        GameManager.previousScene = SceneManager.GetActiveScene().name; // ���݂̃V�[������ۑ�
        SceneManager.LoadScene("Iwasa"); // �Q�[����ʂɈړ�
        Debug.Log("�v���C�V�[���Ɉړ�");
    }

    public void GameClearScene()
    {
        GameManager.previousScene = SceneManager.GetActiveScene().name; // ���݂̃V�[������ۑ�
        SceneManager.LoadScene("GameClear"); // �Q�[���N���A�V�[���Ɉړ�
        Debug.Log("�Q�[���N���A�Ɉړ�");
    }

    public void GameOverScene()
    {
        GameManager.previousScene = SceneManager.GetActiveScene().name; // ���݂̃V�[������ۑ�
        SceneManager.LoadScene("GameOver"); // �Q�[���I�[�o�[��ʂɈړ�
        Debug.Log("�Q�[���I�[�o�[�V�[���Ɉړ�");
    }

    public void ReStartGame()
    {
        string sceneToLoad = GameManager.previousScene;
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            sceneToLoad = "Iwasa"; // �f�t�H���g�̃V�[����ݒ�
        }
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("���g���C�F" + sceneToLoad);
    }

    public void ReturnStartMenu()
    {
        SceneManager.LoadScene("StartScene"); // �X�^�[�g���j���[�ɑ�������V�[���Ɉړ�
        Debug.Log("�X�^�[�g��ʂɈړ�");
    }

    void Update()
    {
        // �Q�[���v���C�V�[���݂̂Ńv���C���[�̑��݂��m�F����
        if (SceneManager.GetActiveScene().name == "Iwasa" && !gameOver && GameObject.FindGameObjectWithTag("Player") == null)
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
