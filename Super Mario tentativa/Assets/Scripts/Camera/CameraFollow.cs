using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject map;
    float lastTargetX;
    Renderer rd;

    float minX;
    float maxX;


    void Start()
    {
        rd = map.GetComponent<Renderer>();
        lastTargetX = target.transform.position.x;
    }

    void LateUpdate()
    {
        Vector3 curPos = transform.position;
        Vector3 targetPos = target.transform.position;
        if (targetPos.x > lastTargetX)
        {
            lastTargetX = targetPos.x;
            float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
            minX = rd.bounds.min.x + halfWidth;
            maxX = rd.bounds.max.x - halfWidth;
            float clampedX = Mathf.Clamp(targetPos.x, minX, maxX);
            transform.position = new Vector3(clampedX, curPos.y, curPos.z);
        }
        
    }



}
