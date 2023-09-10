using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWithTail : MonoBehaviour
{
    [SerializeField] private CharacterData playerData;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.CompareTag("Wolf"))
        {
            HealthManager otherHealth = other.GetComponent<HealthManager>();
            if (otherHealth != null)
            {
                otherHealth.TakeDamage(playerData.DamageAmount);
                Debug.Log(playerData.DamageAmount);
            }
        }
        else if (other.CompareTag("Tree"))
        {
            TreeDrop treeDrop = other.GetComponent<TreeDrop>();
            treeDrop.DropItems();
        }
    }
}
