﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private HP hp;
    private bool isActive;
    public GameObject aLight;
    private int currentLifetime;
    public int maxLifetime;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<HP>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            SetLifeTime();
        }
        
        if(hp.currentHP < 0)
        {
            ActivateLight();
        }
    }

    public void SetLifeTime()
    {
        currentLifetime -= 1;
        if (currentLifetime < 0)
        {
            isActive = false;
            aLight.SetActive(false);
            animator.SetBool("is_activate", false);
            hp.currentHP = hp.maxHP;
        }
    }

    public void ActivateLight()
    {
        isActive = true;
        aLight.SetActive(true);
        currentLifetime = maxLifetime;
        hp.currentHP = hp.maxHP;
        animator.SetBool("is_activate", true);
    }
}
