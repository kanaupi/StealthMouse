﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject jump;

    
    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;
    Animator animator;
    AudioSource audioSource;

    float moveSpeed = 3f;
    bool isJump;
    bool isWalking;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator=GetComponent<Animator>();
        audioSource = jump.GetComponent<AudioSource>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        if (isWalking)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            isWalking = true;
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        else
        {
            isWalking = false;
        }

        //jumpスクリプト
        if (Input.GetKeyDown(KeyCode.Space)&&!isJump)
        {
            isJump = true;
            rb.velocity += new Vector3(0, 5, 0);
            audioSource.Play();
        }
    }

    //床と接しているかを判定
    private void OnCollisionEnter(Collision collision)
    {
        isJump = false;
    }

}
