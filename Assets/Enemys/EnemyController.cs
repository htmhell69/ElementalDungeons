using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public int maxTimeIdleMoving = 3;
    public float followDistance = 10;
    public float gravity;
    float velocity;
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
        if (stats.hp == 0)
        {
            Destroy(gameObject);
        }
        if (characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
        if (stats.freezeTimer > 0)
        {
            stats.freezeTimer -= Time.deltaTime;
        }
        else
        {
            Move();
        }

    }


    void Move()
    {
        if (isFollowing == null && Vector3.Distance(player.position, transform.position) <= followDistance)
        {
            isFollowing = player.gameObject;
        }

        if (isFollowing != null && Vector3.Distance(player.position, transform.position) >= followDistance)
        {
            isFollowing = null;
        }

        if (isFollowing == null && characterController.isGrounded)
        {
            if (!IsInvoking("IdleMovement"))
            {
                Invoke("IdleMovement", Random.Range(1, maxTimeIdleMoving));
            }
            else
            {
                if (idleVector != Vector3.zero)
                {
                    characterController.Move(idleVector * Time.deltaTime);
                    transform.rotation = Quaternion.LookRotation(idleVector);
                }
            }
        }

        if (isFollowing != null && characterController.isGrounded)
        {
            FollowGameObject();
        }
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == isFollowing)
        {
            Stats otherStats = other.gameObject.GetComponent<Stats>();
            stats.freezeTimer = 1.5f;
            if (otherStats.iFrameTimer <= 0)
            {
                otherStats.hp -= stats.baseDamage;
                otherStats.iFrameTimer = 2;
            }
        }
    }
}
