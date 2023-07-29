using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankScript : MonoBehaviour
{
    public float maxHP = 4000f;
    public float currentHP = 3000f;
    public float attackDamage = 40f;

    public Image healthBar;

    private float swingTimer = 0f;
    private float baseSwingTimer = 2.5f;

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
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            BossScript bossScript = boss.GetComponent<BossScript>();
            if (bossScript != null)
            {
                bossScript.TakeDamage(attackDamage);
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

    public void Heal(float amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
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
