using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // カメラが追跡する対象
    public float smoothTime = 0.1f; // スムーズ化に使用する時間
    public Vector3 offset; // カメラとプレイヤーの距離

    private Vector3 velocity = Vector3.zero;


    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            float clampedX = Mathf.Clamp(transform.position.x, -100f, 100f); // x方向の制限は適宜調整して
            float clampedY = Mathf.Clamp(transform.position.y, -100f, 100f); // y方向の制限は適宜調整して
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
