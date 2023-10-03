using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class HealthManager : MonoBehaviour
 {
    [SerializeField] private CharacterData characterData;
    private float maxHealth;
    [HideInInspector]
    public float currentHealth = 0f;
    public float recoveryRate = 5f;
    public bool isDead = false;

    public bool isPlayer;

    private void Start()
    {
        maxHealth = characterData.MaxHealth;
        currentHealth = maxHealth;
    }
    private void Update()
    {
        //if (currentHealth < maxHealth)
        //{
        //    currentHealth += Mathf.CeilToInt(recoveryRate * Time.deltaTime);
        //    currentHealth = Mathf.Min(currentHealth, maxHealth); // Clamp health to the maximum value.
        //}
        //UIManager.Instance.wolfHealthText.text = currentHealth.ToString();

    }
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Clamp health to the maximum value.
    }

    public bool IsDead()
    {
        return isDead;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth <= 0)
        {
            Die();
        }
       UIManager.Instance.wolfHealthText.text = currentHealth.ToString();
    }

    private void Die()
    {
        if (isDead) return;
    }
    public void UpdateHealthLevel(float newHealthLevel)
    {
        maxHealth = newHealthLevel;
        maxHealth = Mathf.Clamp(maxHealth, 0, currentHealth);
            //healthBar.value = maxHealth;
    }
 }

