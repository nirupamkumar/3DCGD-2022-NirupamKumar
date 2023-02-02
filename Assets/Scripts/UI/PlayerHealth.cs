using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    //private int maxHealth = 100;
    public TextMeshProUGUI healthTextUI;

    private int zombieDamage = 20;

    private int sceneIndex = 1;

    public GameObject damageBlood;
    public GameObject deathScreen;

    private void Start()
    {
        health = 100;
        damageBlood.SetActive(false); 
        deathScreen.SetActive(false);
    }

    private void Update()
    {
        healthTextUI.text = health.ToString();
        
        if(health <= 0)
        {
            StartCoroutine(WaitRestart());
            damageBlood.SetActive(false);
            deathScreen.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            health -= zombieDamage;
            AudioManager.SingletonManager.PlaySfx(SfxClip.DamageTaken);
            damageBlood.SetActive(true);
            StartCoroutine(DamageBloodDelay());
        }
    }

    IEnumerator DamageBloodDelay()
    {
        yield return new WaitForSeconds(0.5f);
        damageBlood.SetActive(false);
    }

    private void PlayerDestroy()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator WaitRestart()
    {
        yield return new WaitForSeconds(1);
        PlayerDestroy();
    }

}
