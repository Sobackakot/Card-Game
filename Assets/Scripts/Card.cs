using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Card", menuName = "Cards/Ghouls")]
public class Card : ScriptableObject
{
    public new string name;

    public Sprite image_1;
    public Sprite image_2;

    public bool hero;

    public string cardType;

    public int force;

    public string ability;

    public string description;
}
