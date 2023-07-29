using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxMana = 100f;
    public float currentMana = 100f;
    public float manaCostForSpell1 = 20f;
    public float spell1HealingAmount = 30f;
    public float spell1Cooldown = 5f; 

    public Image manaBar;
    public Image spell1Icon; 
    public Color cooldownColor = Color.gray;

    private bool canCastSpell1 = true;

    private void Start()
    {
        UpdateManaBar();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            CastSpell1();
        }
    }

    private void CastSpell1()
    {
        if (!canCastSpell1)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // RAJOUTER AUTRES CLASSES
            TankScript tank = hit.collider.GetComponent<TankScript>();
            if (tank != null)
            {
                if (currentMana >= manaCostForSpell1)
                {
                    tank.Heal(spell1HealingAmount);

                    currentMana -= manaCostForSpell1;
                    UpdateManaBar();

                    StartSpell1Cooldown();
                }
            }
            else
            {
                // RAJOUTER AUTRES CLASSES
            }
        }
    }

    private void UpdateManaBar()
    {
        if (manaBar != null)
        {
            float fillAmount = currentMana / maxMana;
            manaBar.fillAmount = fillAmount;
        }
    }

    private void StartSpell1Cooldown()
    {
        canCastSpell1 = false;
        spell1Icon.color = cooldownColor;
        Invoke("ResetSpell1Cooldown", spell1Cooldown);
    }

    private void ResetSpell1Cooldown()
    {
        canCastSpell1 = true;
        spell1Icon.color = Color.white;
        spell1Icon.enabled = true;
    }
}
