using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public TextMeshProUGUI healthTextUI;

    public int loadSceneIndex;

    public int zombieDamage = 5;

    private void Start()
    {
        health = 100;
    }

    private void Update()
    {
        healthTextUI.text = health.ToString();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= zombieDamage;
        }
    }

    private void PlayerDestroy()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(loadSceneIndex);
    }
}
