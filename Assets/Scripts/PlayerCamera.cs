using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;          // 따라갈 대상 (플레이어)
    public Vector3 offset = new Vector3(0, 0, -10); // 카메라 Z 고정
    public float smoothSpeed = 5f;    // 따라가는 부드러움 정도

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
