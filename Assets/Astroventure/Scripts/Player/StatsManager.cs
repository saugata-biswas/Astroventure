using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    [SerializeField] public int Health = 100;
    [SerializeField] public int Life = 2;

    private int maxHealth = 100;

    [SerializeField] private TMP_Text healthTxt;
    [SerializeField] private TMP_Text lifeTxt;

    [SerializeField] private GameObject gameOverCanvas;

    public void ChangeHealth(int changeInHealth)
    {
        Health = Health + changeInHealth;

        int residualHealth = Health % maxHealth;
        if (Health >= maxHealth)
        {
            Life = Life + 1;
            Health = Health % maxHealth;
        }
        else if(Health < 0)
        {
            Life = Life - 1;
            Health = maxHealth + Health;
        }
    }

    public void ChangeLife(int changeInLife)
    {
        Life = Life + changeInLife;
    }

    void Update()
    {
        healthTxt.text = Health.ToString();
        lifeTxt.text = Life.ToString();

        if (Life < 0)
        {
            gameOverCanvas.SetActive(true);
            Health = 0;
            Life = 0;
        }
    }
}
