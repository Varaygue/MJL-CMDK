using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public float maxHP = 5000;
    public float currentHP = 5000f;
    public float attackDamage = 100f;

    public Image healthBar;

    private float swingTimer = 0f;
    private float baseSwingTimer = 2f;

    private void Start()
    {
        UpdateHealthBar();
        ResetSwingTimer();
    }

    private void Update()
    {
        if (swingTimer <= 0f)
        {
            Attack();
            ResetSwingTimer();
        }
        else
        {
            swingTimer -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        //A RAJOUTER : ROGUE ET WARRIOR
        GameObject tank = GameObject.FindGameObjectWithTag("Tank");
        if (tank != null)
        {
            TankScript tankScript = tank.GetComponent<TankScript>();
            if (tankScript != null)
            {
                tankScript.TakeDamage(attackDamage);
            }
        }
    }

    private void ResetSwingTimer()
    {
        swingTimer = baseSwingTimer;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0f)
        {
            currentHP = 0f;
            //LOGIQUE DE MORT A RAJOUTER
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            float fillAmount = currentHP / maxHP;
            healthBar.fillAmount = fillAmount;
        }
    }
}
