using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    public TextMeshProUGUI healthTextUI;


    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
