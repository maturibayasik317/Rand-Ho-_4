using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll_map : MonoBehaviour
{
    public float scrollSpeed = 2.0f; // �X�N���[�����x

    void Update()
    {
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
    }
}
