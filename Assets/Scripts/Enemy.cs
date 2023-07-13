using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    AIDestinationSetter destination;
    [SerializeField] string tagTarget;
   
    void Start()
    {
        destination = GetComponent<AIDestinationSetter>();
        destination.target = GameObject.FindGameObjectWithTag(tagTarget).transform;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagTarget)
        {
            Destroy(gameObject);
        }
    }
}
