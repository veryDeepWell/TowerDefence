using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private Vector3 _mousePos;
    private float _angleRad;
    private float _angleDeg;

    [SerializeField] private float speed = 5.0f;
    
    [SerializeField] Administrator _administrator;
    
    // sex
    private void Awake()
    {
        //_administrator = GameObject.Find("Administrator").GetComponent<Administrator>();
        _administrator = transform.root.GetComponentInParent<Administrator>();
    }

    private float _nextFire = 0.0F;
    
    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > _nextFire)
        {
            Shot();
            _nextFire = Time.time + _administrator.statsManager.shotDelay;
        }
    }

    private void Shot()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        
        GameObject projectile = (GameObject)Instantiate(bulletPrefab, myPos, rotation);
        
        projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * _administrator.statsManager.shotSpeed;
    }
}
