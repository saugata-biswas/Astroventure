using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bulletDecal;
    [SerializeField] private float bulletSpeed = 50.0f;
    [SerializeField] private float bulletLifetime = 3.0f;
    [SerializeField] private float bulletDecalLifetime = 3.0f;
    public Vector3 bulletTarget { get; set; } 
    public bool HasHitAnything { get; set; }


    private void OnEnable()
    {
        Destroy(gameObject, bulletLifetime);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, bulletTarget, bulletSpeed * Time.deltaTime);
        if (!HasHitAnything && Vector3.Distance(transform.position, bulletTarget) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contactPoint = collision.GetContact(0);
        //Debug.DrawRay(contactPoint.point, contactPoint.normal, Color.white);
        GameObject bulletDecalGmObj = GameObject.Instantiate(bulletDecal, contactPoint.point + contactPoint.normal * 0.01f , Quaternion.LookRotation(contactPoint.normal));
        Destroy(bulletDecalGmObj, bulletDecalLifetime);
        Destroy(gameObject);
    }
}
