using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    Stats stats;
    CharacterController characterController;
    Vector3 idleVector;
    GameObject isFollowing;
    void Start()
    {
        stats = GetComponent<Stats>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void IdleMovement()
    {
        if (Random.Range(1, 100) > 50)
        {
            idleVector = RandomVector3(-stats.movementSpeed / 2, stats.movementSpeed / 2, false);
            characterController.Move(idleVector * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(idleVector);
        }
        else
        {
            idleVector = Vector3.zero;
        }
    }
    void FollowGameObject()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
 Quaternion.LookRotation(isFollowing.transform.position - transform.position), 3 * Time.deltaTime);
        characterController.Move(transform.forward * stats.movementSpeed * Time.deltaTime);
    }
    Vector3 RandomVector3(float min, float max, bool useY)
    {
        var x = Random.Range(min, max);
        if (useY)
        {
            var y = Random.Range(min, max);
        }

        var z = Random.Range(min, max);
        return new Vector3(x, 0, z);
    }
}
