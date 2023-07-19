using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    AIDestinationSetter destination;

    AIPath aipath;
    [SerializeField] string tagTarget;
    [SerializeField] float startSpeed = 5f;
    float health;
    [SerializeField] float startHealth = 100f;
    [SerializeField] int cashGain = 100;
    [SerializeField] Image healthBar;
    bool isDead = false;
    void Start()
    {
        destination = GetComponent<AIDestinationSetter>();
        destination.target = GameObject.FindGameObjectWithTag(tagTarget).transform;
        aipath = GetComponent<AIPath>();
        aipath.maxSpeed = startSpeed;        
        health = startHealth;
    }

    private void Update()
    {
        aipath.maxSpeed = startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.GetComponent<Image>().fillAmount = health / startHealth;

        if (health <= 0 && !isDead) 
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        aipath.maxSpeed = startSpeed * (1f - pct);
    }
    public void Die() 
    {
        PlayerStats.Cash += cashGain;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagTarget)
        {
            ApplyDamage();
            Debug.Log(PlayerStats.Lives);
        }
    }
    public void ApplyDamage()
    {
        isDead = true;
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
