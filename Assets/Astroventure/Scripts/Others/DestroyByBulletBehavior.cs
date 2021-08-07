using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBulletBehavior : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private GameObject gmObjToBeDestroyed;

    void Start()
    {
        if (gmObjToBeDestroyed == null)
            gmObjToBeDestroyed = this.gameObject;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            if (health <= 0)
            {
                Destroy(gmObjToBeDestroyed);
            }
        }
    }
}
