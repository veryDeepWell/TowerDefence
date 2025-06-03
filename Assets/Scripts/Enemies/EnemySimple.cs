using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemySimple : MonoBehaviour, IDamageble, IDealDamage, IEnemy
{
    [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;
    
    [SerializeField] private float speed = 1.5f;

    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    public int Health 
    {  
        get => health;
        set => health = value;
    }

    public void GetDamage(int damageToDeal)
    {
        Health = Health - damageToDeal;

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

    public void AddHealth(int healthToAdd)
    {
        Health = Health + healthToAdd;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GetDamage(collision.gameObject.GetComponent<BulletStats>().damage);
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().GetDamage(damage);
            Suicide();
        }
    }

    private void NotifyOfDeath()
    {
        SpawnManager spawnManager = GetComponentInParent<SpawnManager>();
        
        spawnManager.spawnCount--;
        spawnManager.killCount++;
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
