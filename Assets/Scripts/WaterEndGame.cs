using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class WaterEndGame : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onGameEnd;

    [SerializeField]
    private GameObject canvas;
    public void Setup()
    {
        canvas.SetActive(true);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);

    }

    public void Menu()
    {
        SceneManager.LoadScene(0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        OnCollide();
    }

    protected void OnCollide()
    {
        Setup();
        onGameEnd?.Invoke();
    }

}
