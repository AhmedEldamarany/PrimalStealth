using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Create data",menuName ="new character data")]
public class CharacterData : ScriptableObject
{
    public int MaxHealth;
    public float DamageAmount;
}
