using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/CharacterData", fileName = "CharacterData")]
public class CharacterData : ScriptableObject
{
    public int maxHealth;
    public int attack;
    public float attackRange;
    public float moveSpeed;
}