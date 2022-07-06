
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
    public Ui ui;

    private float velocity = 0;
    private Stats stats;
    public bool canLevelUp;

    void Start()
    {
        stats = GetComponent<Stats>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (ui.currentMenu == Menus.None)
            {
                ui.SwitchMenus(Menus.MainMenu);
            }
            else if (ui.currentMenu == Menus.MainMenu)
            {
                ui.SwitchMenus(Menus.None);
            }
            else if (ui.currentMenu == Menus.Inventory)
            {
                ui.SwitchMenus(Menus.None);
            }
        }


        if (stats.iFrameTimer > 0)
        {
            stats.iFrameTimer -= Time.deltaTime;
        }
        if (stats.hp <= 0)
        {
            Destroy(gameObject);
        }
        hpSlider.value = stats.hp;
        hpSlider.maxValue = stats.maxHp;
    }

    void FixedUpdate()
    {
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
    }
}



