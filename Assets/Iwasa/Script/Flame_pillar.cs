using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame_pillar : MonoBehaviour
{
    public GameObject flamePrefab; // ���̃v���n�u
    public float flameDuration = 2.0f; // ���̎�������
    public float interval = 5.0f; // �����o��Ԋu
    public float flameLength = 5.0f; // ���̒���
    private GameObject flameInstance;

    void Start()
    {
        // ���̐������J�n����
        StartCoroutine(FlameRoutine());
    }

    IEnumerator FlameRoutine()
    {
        while (true)
        {
            // �w�肳�ꂽ�Ԋu�őҋ@
            yield return new WaitForSeconds(interval);

            // ���𐶐�
            SpawnFlame();

            // �w�肳�ꂽ���Ԃ����ҋ@
            yield return new WaitForSeconds(flameDuration);

            // �����\���ɂ���
            if (flameInstance != null)
            {
                flameInstance.SetActive(false);
            }
        }
    }

    void SpawnFlame()
    {
        if (flamePrefab == null)
        {
            Debug.LogError("Flame prefab is not assigned!");
            return;
        }

        // �����܂���������Ă��Ȃ��ꍇ�A��������
        if (flameInstance == null)
        {
            flameInstance = Instantiate(flamePrefab, transform.position, Quaternion.identity);
            flameInstance.transform.SetParent(transform);
        }

        // ����\�����A�����𒲐�����
        flameInstance.SetActive(true);
        flameInstance.transform.localScale = new Vector3(flameInstance.transform.localScale.x, flameLength, flameInstance.transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Debug.Log("Player destroyed by flame");
        }
    }
}
