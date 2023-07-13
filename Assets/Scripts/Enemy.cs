using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    AIDestinationSetter destination;
    [SerializeField] string tagTarget;
    [SerializeField] int health = 100;
    [SerializeField] int cashGain = 100;
    void Start()
    {
        destination = GetComponent<AIDestinationSetter>();
        destination.target = GameObject.FindGameObjectWithTag(tagTarget).transform;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) 
        {
            Die();
        }
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
