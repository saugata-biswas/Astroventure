using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionBrain : MonoBehaviour
{
    [SerializeField] public GameObject TargetGmObj;
    [SerializeField] public GameObject TargetEnemyGmObj;

    [SerializeField] private Transform barrelTransform;

    Animator animator;
    private int distanceHash;
    private int enemyFoundHash;

    public GameObject GetTargetGmObj()
    {
        if (TargetGmObj == null)
        {
            TargetGmObj = GameObject.Find("Player");
        }
        return TargetGmObj;
    }


    void Awake()
    {
        if (TargetGmObj == null)
        {
            TargetGmObj = GameObject.Find("Player");
        }

        animator = GetComponent<Animator>();
        distanceHash = Animator.StringToHash("distanceWithPlayer");
        enemyFoundHash = Animator.StringToHash("EnemyFound");

        //audioSource = GetComponent<AudioSource>();
        //audioSource.clip = audioClips[0];
    }

    public void StartHunting()
    {
        InvokeRepeating("Hunt", 0.5f, Random.Range(1.0f, 0.5f));
    }

    public void StopHunting()
    {
        CancelInvoke("Hunt");
    }

    void Hunt()
    {
        if (TargetEnemyGmObj != null)
            return;

        RaycastHit hit;

        if (Physics.Raycast(barrelTransform.position, barrelTransform.forward, out hit, 8.0f))
        {
            Debug.DrawRay(barrelTransform.position, barrelTransform.forward * 8.0f, Color.red);
            if (hit.collider.tag == "EnemyNPC")
            {
                TargetEnemyGmObj = hit.collider.gameObject;
                animator.SetBool(enemyFoundHash, true);
            }
        }
    }
    
    void Update()
    {
        animator.SetFloat(distanceHash, Vector3.Distance(transform.position, TargetGmObj.transform.position));
        //if (TargetEnemyGmObj == null)
        //{
        //    GetComponent<BoxCollider>().enabled = true;
        //}
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "EnemyNPC")
    //    {
    //        TargetEnemyGmObj = other.gameObject;
    //        GetComponent<BoxCollider>().enabled = false;
    //        animator.SetBool(enemyFoundHash, true);
    //    }
    //}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyNPC")
        {
            Destroy(collision.gameObject);
            TargetEnemyGmObj = null;
            animator.SetBool(enemyFoundHash, false);
        }
    }
}
