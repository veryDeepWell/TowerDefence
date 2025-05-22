using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private int health = 1;
    [SerializeField] private float speed = 0.5f;

    public int Health 
    {  
        get => health;
        set => health = value;
    }

    public void GetDamage(int damage)
    {
        Health = Health - damage;

        if (health <= 0)
        {
            Suicide();
        }
    }

    public void Suicide()
    {
        Destroy(gameObject);
        NotifyOfDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision with " + collision.gameObject.tag.ToString());

        if (collision.gameObject.CompareTag("Bullet"))
        {
            GetDamage(collision.gameObject.GetComponent<BulletStats>().Damage);
            Destroy(collision.gameObject);
        }
    }

    private void NotifyOfDeath()
    {
        SpawnManager spawnManager = GetComponentInParent<SpawnManager>();
        spawnManager.spawnCount--;
        spawnManager.AddScore(1);
    }

    private void EnemyMove()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,0,0), step);
    }

    private void Update()
    {
        EnemyMove();
    }
}
