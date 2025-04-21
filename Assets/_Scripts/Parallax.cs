using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _length, _startPosition;
    public GameObject mainCamera;
    [Range(0,1), SerializeField] private float parallaxFactor;

    private void Start()
    {
        _startPosition = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x; //  Getting the width of the sprite
    }

    private void FixedUpdate()
    {
        // Used to determine when a background should loop
        var temp = (mainCamera.transform.position.x * (1 - parallaxFactor));
        
        // Used to determine how much a background should move
        var dist = (mainCamera.transform.position.x * parallaxFactor);

        // Move the background object based on camera movement and parallax factor
        transform.position = new Vector3(_startPosition + dist, transform.position.y, transform.position.z);

        if (temp > _startPosition + _length)
        {
            _startPosition += _length;
        }
        else if (temp < _startPosition - _length)
        {
            _startPosition -= _length;
        }
    }
}
