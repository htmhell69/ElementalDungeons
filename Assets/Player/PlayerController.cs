
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float gravity = 9.8f;
    public float jumpHeight = 10.0f;
    public Transform cameraTransform;
    public Slider hpSlider;

    private float velocity = 0;
    private Stats stats;

    void Start()
    {
        stats = GetComponent<Stats>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (stats.iFrameTimer > 0)
        {
            stats.iFrameTimer -= Time.deltaTime;
        }
        if (stats.hp == 0)
        {
            Destroy(gameObject);
        }
        float horizontal = Input.GetAxis("Horizontal") * stats.movementSpeed;
        float vertical = Input.GetAxis("Vertical") * stats.movementSpeed;

        characterController.Move((cameraTransform.right * horizontal + cameraTransform.forward * vertical) * Time.deltaTime);

        if (characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }

        hpSlider.value = stats.hp;
        stats.maxHp = 100 + (stats.level * stats.levelMultipliers.maxHp);
        hpSlider.maxValue = stats.maxHp;
    }
}



