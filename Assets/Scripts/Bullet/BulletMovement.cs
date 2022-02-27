using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float destroyTime = 2f;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        destroyTime -= Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (destroyTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _rb.velocity = transform.right * bulletSpeed;
    }
}