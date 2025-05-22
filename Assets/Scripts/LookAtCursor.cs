using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private Camera _camera;

    private Vector3 mousePos;
    private float angleRad;
    private float angleDeg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = (Vector2)_camera.ScreenToWorldPoint(Input.mousePosition);
        angleRad = Mathf.Atan2(mousePos.y - transform.position.y , mousePos.x - transform.position.x);
        angleDeg = (180 / Mathf.PI) * angleRad - 90;

        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);
    }
}
