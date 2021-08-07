using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBrain : MonoBehaviour
{
    [SerializeField] public GameObject TargetGmObj;
    [SerializeField] private Transform barrelTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletParent;
    [SerializeField] public float MaxBulletTravelDistance = 100.0f;

    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;

    Animator animator;
    private int distanceHash;

    public GameObject GetTargetGmObj()
    {
        if (TargetGmObj == null)
        {
            TargetGmObj = GameObject.Find("Player");
        }
        return TargetGmObj;
    }

    void Fire()
    {
        RaycastHit hit;
        GameObject bullet = GameObject.Instantiate(bulletPrefab, barrelTransform.position, barrelTransform.rotation, bulletParent);
        audioSource.PlayOneShot(audioSource.clip);

        BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
        if (Physics.Raycast(barrelTransform.position, barrelTransform.forward, out hit, Mathf.Infinity))
        {
            bulletBehavior.bulletTarget = hit.point;
            bulletBehavior.HasHitAnything = true;
        }
        else
        {
            bulletBehavior.bulletTarget = barrelTransform.position + barrelTransform.forward * MaxBulletTravelDistance;
            bulletBehavior.HasHitAnything = false;
        }
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, Random.Range(1.0f, 3.0f));
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    void Awake()
    {
        if (TargetGmObj == null)
        {
            TargetGmObj = GameObject.Find("Player");
        }

        animator = GetComponent<Animator>();
        distanceHash = Animator.StringToHash("distance");

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[0];
    }

    void Start()
    {

    }

    
    void Update()
    {
        animator.SetFloat(distanceHash, Vector3.Distance(transform.position, TargetGmObj.transform.position));
    }
}
