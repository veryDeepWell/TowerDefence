using System;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour, IDamageble
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Administrator admin;
    
    [SerializeField] private int health = 10;

    public int Health 
    {  
        get => health;
        set => health = value;
    }

    private void Awake()
    {
        healthText.text = Health.ToString();
    }

    public void GetDamage(int damageToDeal)
    {
        Health = Health - damageToDeal;
        
        healthText.text = Health.ToString();

        if (health <= 0)
        {
            Suicide();
        }
    }

    public void Suicide()
    {
        admin.GameOver();
    }

    public void AddHealth(int healthToAdd)
    {
        Health = Health + healthToAdd;
        
        healthText.text = Health.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<IDamageble>().Suicide();
            GetDamage(collision.gameObject.GetComponent<IDealDamage>().Damage);
        }*/
    }
}
