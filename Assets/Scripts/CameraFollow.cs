using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Alvo")]
    public Transform target;

    [Header("Movimento")]
    public float smoothSpeed = 8f;

    public SpriteRenderer mapRenderer;

    [Header("Limites do mapa (world space) - preenchidos automaticamente se Map Renderer estiver setado")]
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Start()
    {
        if (mapRenderer != null)
        {
            Bounds bounds = mapRenderer.bounds;
            minX = bounds.min.x;
            maxX = bounds.max.x;
            minY = bounds.min.y;
            maxY = bounds.max.y;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        float camHalfHeight = cam.orthographicSize;
        float camHalfWidth = camHalfHeight * cam.aspect;

        float clampedX = (maxX - minX < camHalfWidth * 2)
            ? (minX + maxX) / 2f
            : Mathf.Clamp(smoothedPosition.x, minX + camHalfWidth, maxX - camHalfWidth);

        float clampedY = (maxY - minY < camHalfHeight * 2)
            ? (minY + maxY) / 2f
            : Mathf.Clamp(smoothedPosition.y, minY + camHalfHeight, maxY - camHalfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}