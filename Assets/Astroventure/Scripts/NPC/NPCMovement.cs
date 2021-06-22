using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float rotationSpeed;    // degrees per second
    [SerializeField] private float moveSpeed;        // meters per second
    [SerializeField] private float meanDistance;
    [SerializeField] private float stdDevPosition;
    private Vector3 direction;
    private Vector3 position;
    


    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        keepDistance();
        rotateGradually();
    }

    void keepDistance()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance > (meanDistance + stdDevPosition) || distance < (meanDistance - stdDevPosition))
        {
            // direction to look at: from player towards NPC
            Vector3 direction = (this.transform.position - player.transform.position).normalized;
            Vector3 randomness = new Vector3(Random.Range(-stdDevPosition, stdDevPosition),
                0.0f, Random.Range(-stdDevPosition, stdDevPosition));
            position = direction * meanDistance + randomness + player.transform.position;
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, position, moveSpeed * Time.deltaTime);
    }

    void rotateGradually()
    {
        // direction to look at: from NPC towards player
        Vector3 direction = (player.transform.position - this.transform.position).normalized;
        
        // rotation for that direction
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        
        // rotate over time
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, 
            rotationSpeed * Mathf.Deg2Rad * Time.deltaTime);
    }

    void followPlayer()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance > (meanDistance + stdDevPosition) || distance < (meanDistance - stdDevPosition))
        {
            // direction to look at: from NPC towards player
            Vector3 direction = (player.transform.position - this.transform.position).normalized;
            Vector3 randomness = new Vector3(Random.Range(-stdDevPosition, stdDevPosition),
                0.0f, Random.Range(-stdDevPosition, stdDevPosition));
            position = direction * meanDistance + randomness + player.transform.position;
        }
        this.transform.Translate((position - this.transform.position) * moveSpeed * Time.deltaTime);
    }
}
