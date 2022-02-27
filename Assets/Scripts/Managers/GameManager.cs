using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerInputHandler))]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private PlayerInputHandler playerInputHandler;

    [SerializeField] private WeaponController weaponController;
    

    private Statue[] statues;
    private PlayerController playerController;
    private EnemyController[] enemies;
    
    private void Awake()
    {
        #region References

        statues = FindObjectsOfType<Statue>();
        enemies = FindObjectsOfType<EnemyController>();
        playerInputHandler = GetComponent<PlayerInputHandler>();
        playerController = player.GetComponent<PlayerController>();

        #endregion

        #region Events subscription

        playerInputHandler.OnJumpButtonDown += OnJumpDownHandler;
        playerInputHandler.OnJumpButtonUp += OnJumpUpHandler;
        playerInputHandler.OnEKeyDown += OnEKeyHandler;
        playerInputHandler.OnLBMPressed += OnLBMHandler;

        #endregion
    }

    private void OnJumpDownHandler()
    {
        playerController.StartJump();
    }
    private void OnJumpUpHandler()
    {
        playerController.EndJump();
    }
    private void OnEKeyHandler()
    {
        foreach (var statue in statues)
        {
            statue.Pray();
        }
    }

    private void OnLBMHandler()
    {
        StartCoroutine(weaponController.Shoot());
    }
    public void DisableEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.SetSpeed(0);
        }
    }
}