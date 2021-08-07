using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private StatsManager statsManager;
    
    void OnCollisionEnter(Collision collision)
    {
        string colliderTag = collision.gameObject.tag;
        if (colliderTag == "Bullet")
        {
            statsManager.ChangeHealth(-20);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        string triggerTag = other.gameObject.tag;
        if (triggerTag == "HazardousMaterial")
        {
            statsManager.ChangeLife(-1);
        }
    }
}
