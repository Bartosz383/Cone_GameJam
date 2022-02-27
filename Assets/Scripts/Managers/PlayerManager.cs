using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using TMPro.Examples;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    
    public static PlayerManager Instance;
    
    [SerializeField]
    private UI ui;
    [SerializeField]
    private bool isRespawning = true;
    [SerializeField]
    private int deltaHP = 5;
    [SerializeField]
    private int maxHp = 100;
    [SerializeField]
    private float healDropTimer = 2;
    
    private int hp = 0;
    private float currentHealDropTimer = 0;

    private void Awake() //Singleton
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        hp = maxHp;
        currentHealDropTimer = healDropTimer;
    }

    private void FixedUpdate()
    {
        if (currentHealDropTimer >= 0)
            currentHealDropTimer -= Time.fixedDeltaTime;
        else
            MinusHPOnTime();
    }

    private void Update()
    {
        Debug.Log(hp);
        if(hp <= 0 && isRespawning)
        {
            Respawn();
        }
    }

    private void MinusHPOnTime()
    {
        ChangeHP(-deltaHP);
        currentHealDropTimer = healDropTimer;
    }

    public void ChangeHP(int value)
    {
        hp += value;
        hp = Mathf.Clamp(hp, 0, maxHp);
        ui.UpdateHPBar(hp);
        
    }

    public int GetMaxHP()
    {
        return maxHp;
    }
    private void Respawn()
    {
        hp = maxHp;
        SceneManager.LoadScene("GameLevel");
    }

    public void SetDeltaHPtoZero() => deltaHP = 0; 
}
