using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject map;
    float lastTargetX;
    Renderer renderer;

    public float minX;
    public float maxX;

    void Start()
    {
        renderer= map.GetComponent<Renderer>();
    }

    void LateUpdate()
    {
        Vector3 curPos = transform.position;
        Vector3 targetPos = target.transform.position;
        float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        minX = renderer.bounds.min.x + halfWidth;
        maxX = renderer.bounds.max.x - halfWidth;
        float clampedX = Mathf.Clamp(targetPos.x, minX, maxX);
        transform.position = new Vector3(clampedX, curPos.y, curPos.z);
    }



}
