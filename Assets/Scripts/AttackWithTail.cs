using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWithTail : MonoBehaviour
{
    [SerializeField] private CharacterData playerData;
    private void OnTriggerEnter(Collider other)
    {
        HealthManager otherHealth = other.GetComponent<HealthManager>();
        if (otherHealth != null && other.CompareTag("Wolf"))
        {
            otherHealth.TakeDamage(playerData.DamageAmount);
            Debug.Log(playerData.DamageAmount);
            Debug.Log("hereeeeeeeeeeeeeeeeeee");
        }
    }
}
