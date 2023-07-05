using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cinemachine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    float speed;
    bool isRunning;

    [Required]
    public Controls controls;

    [Title("Speeds")]
    [Range(0f, 10f)]
    public float walkingSpeed = 4.0f;
    [Range(0f, 10f)]
    public float runningSpeed = 6.0f;

    CinemachineVirtualCamera cinemachineCam;

    SpriteRenderer playerTexture;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

        cinemachineCam = GameObject.FindGameObjectWithTag("CMCAM").GetComponent<CinemachineVirtualCamera>();

        playerTexture = gameObject.GetComponentInChildren<SpriteRenderer>();

        speed = walkingSpeed;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(controls.run))
        {
            if (!isRunning)
            {
                speed = runningSpeed;
                StartCoroutine(CameraFadeOut());
                isRunning = true;
            }
        }
        else
        {
            if (horizontal != 0 || vertical != 0)
            {
                if (isRunning)
                {
                    speed = walkingSpeed;
                    StartCoroutine(CameraFadeIn());
                    isRunning = false;
                }
            }
        }

        if (horizontal == -1)
            playerTexture.flipX = false;
        else if (horizontal == 1)
            playerTexture.flipX = true;
    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    IEnumerator CameraFadeOut()
    {
        for (int i = 0; i < 10; i++)
        {
            cinemachineCam.m_Lens.OrthographicSize += 0.08f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator CameraFadeIn()
    {
        for (int i = 0; i < 10; i++)
        {
            cinemachineCam.m_Lens.OrthographicSize -= 0.08f;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
