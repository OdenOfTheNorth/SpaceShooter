using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform = null;

    private Transform camTransform = null;

    private void Awake()
    {
        camTransform = transform;
    }

    private void LateUpdate()
    {
        camTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -10.0f);
    }
}
