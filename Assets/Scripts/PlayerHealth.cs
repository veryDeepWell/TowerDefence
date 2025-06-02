using System;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour, IDamageble
{
    [SerializeField] private TMP_Text HealthText;
    [SerializeField] private Administrator Admin;
    
    [SerializeField] private int health = 10;

    public int Health 
    {  
        get => health;
        set => health = value;
    }

    private void Awake()
    {
        HealthText.text = Health.ToString();
    }

    public void GetDamage(int DamageToDeal)
    {
        Health = Health - DamageToDeal;
        
        HealthText.text = Health.ToString();

        if (health <= 0)
        {
            Suicide();
        }
    }

    public void Suicide()
    {
        Admin.GameOver();
    }

    public void AddHealth(int HealthToAdd)
    {
        Health = Health + HealthToAdd;
        
        HealthText.text = Health.ToString();
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
