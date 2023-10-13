using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttack : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private const string ATTACK_PARAM = "isAttacking";
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            animator.SetBool(ATTACK_PARAM, true);
        }
    }
}
