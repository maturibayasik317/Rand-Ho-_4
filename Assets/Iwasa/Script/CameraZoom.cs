using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float smoothTime = 0.1f; // �X���[�Y���Ɏg�p���鎞��
    public Vector3 offset; // �J�����ƃv���C���[�̋���
    public float minZoom = 5f; // �ŏ��Y�[���l
    public float maxZoom = 10f; // �ő�Y�[���l
    public float zoomSpeed = 10f; // �Y�[���̃X�s�[�h
    public float jumpThreshold = -1f; // �W�����v�Ɣ��肷�鍂��

    private Vector3 velocity = Vector3.zero;
    private Camera cam;
    private Transform target;

    void Start()
    {

    }

    void Update()
    {
        cam = GetComponent<Camera>();

        // Player�^�O���t�����I�u�W�F�N�g��T����target�ɐݒ�
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            target = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player�^�O���t�����I�u�W�F�N�g��������܂���I");
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            bool isJumping = target.position.y > jumpThreshold;


            // �W�����v���Ă���Ƃ��̓Y�[���A�E�g�A���Ă��Ȃ��Ƃ��̓Y�[���C��
            float targetZoom = isJumping ? maxZoom : minZoom;
            float newZoom = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
            cam.orthographicSize = newZoom;

            float clampedX = Mathf.Clamp(transform.position.x, -10000f, 10000f);
            float clampedY = Mathf.Clamp(transform.position.y, -10000f, 10000f);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
