using Unity.Mathematics;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;

    private Camera _camera;

    private Vector3 mousePos;
    private float angleRad;
    private float angleDeg;

    [SerializeField]
    private float speed = 5.0f;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();

            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            
            GameObject projectile = (GameObject)Instantiate(BulletPrefab, myPos, rotation);
            projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
        }
    }
}
