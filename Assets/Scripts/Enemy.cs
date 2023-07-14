using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    AIDestinationSetter destination;

    AIPath aipath;
    [SerializeField] string tagTarget;
    [SerializeField] float startSpeed = 5f;
    [SerializeField] float health = 100;
    [SerializeField] int cashGain = 100;
    void Start()
    {
        destination = GetComponent<AIDestinationSetter>();
        destination.target = GameObject.FindGameObjectWithTag(tagTarget).transform;
        aipath = GetComponent<AIPath>();
        aipath.maxSpeed = startSpeed;
    }

    private void Update()
    {
        aipath.maxSpeed = startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0) 
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
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
