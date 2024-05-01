using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;            //カメラが追跡する対象（
    public float smoothSpeed = 0.125f;  //追跡のスムーズ化に使用する速度
    public Vector3 offset;              //カメラとプレイヤーの距離

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            float clampedX = Mathf.Clamp(transform.position.x, -100f, 100f); //x方向の制限は適宜調整して
            float clampedY = Mathf.Clamp(transform.position.y, -100f, 100f); //y方向の制限は適宜調整して
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
