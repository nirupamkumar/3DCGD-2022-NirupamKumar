using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    //private int maxHealth = 100;
    public TextMeshProUGUI healthTextUI;

    private int zombieDamage = 20;

    private int sceneIndex = 1;

    public GameObject damageBlood;
    public GameObject deathScreen;

    //PostProcessing
    public PostProcessVolume processVolume;
    Vignette vignette;
    private float vignetterIntensity;
    ColorGrading colorGrading;


    private void Start()
    {
        health = 100;
        damageBlood.SetActive(false); 
        deathScreen.SetActive(false);
        processVolume.profile.TryGetSettings(out vignette);
        processVolume.profile.TryGetSettings(out colorGrading);
        
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

        if (health <= 20)
        {
            colorGrading.active = true;
        }
        else
        {
            colorGrading.active = false;
        }

        vignette.intensity.value = vignetterIntensity;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            health -= zombieDamage;
            vignetterIntensity += .2f;
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
