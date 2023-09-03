using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Collider attackCollider;
    public void EnableCollider()
    {
        attackCollider.enabled = true;
    }
    public void DisableCollider()
    {
        attackCollider.enabled = false;
    }
}
