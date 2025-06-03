using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private Camera _camera;

    private Vector3 _mousePos;
    private float _angleRad;
    private float _angleDeg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = (Vector2)_camera.ScreenToWorldPoint(Input.mousePosition);
        _angleRad = Mathf.Atan2(_mousePos.y - transform.position.y , _mousePos.x - transform.position.x);
        _angleDeg = (180 / Mathf.PI) * _angleRad - 90;

        transform.rotation = Quaternion.Euler(0f, 0f, _angleDeg);
    }
}
