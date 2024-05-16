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
        SceneManager.LoadScene("Iwasa");//�Q�[����ʂɈړ�
        Debug.Log("�v���C�V�[���Ɉړ�");
    }

    public void GameClearScene()
    {
        SceneManager.LoadScene("GameClear");//�Q�[���N���A�V�[���Ɉړ�
        Debug.Log("�Q�[���N���A�Ɉړ�");
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOver");//�Q�[���I�[�o�[��ʂɈړ�
        Debug.Log("�Q�[���I�[�o�[�V�[���Ɉړ�");
    }

    public void RestartGame()
    {
        // ���݂̃V�[�����ă��[�h����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("���g���C");
    }

    public void ReturnStartMenu()
    {
        // �X�^�[�g���j���[�ɑ�������V�[���Ɉړ�����
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
