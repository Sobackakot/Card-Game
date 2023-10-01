using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Card", menuName = "Cards/Ghouls")]
public class Card : ScriptableObject
{
    public new string name = "New Card";

    public Sprite image_1 = null;
    public Sprite image_2 = null;

    public bool hero =false;

    public string cardType = "Type";

    public int force = 0;

    public string ability = "None";

    public string description = "None";
}
