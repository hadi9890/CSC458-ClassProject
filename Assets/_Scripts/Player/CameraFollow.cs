using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, -10);
    }
}
