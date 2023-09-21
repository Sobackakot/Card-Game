using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    public static CardGameManager instanceManager;
    public void Start()
    {
        if (instanceManager == null)
        {
            instanceManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
            return;
        }
    }
    private bool isCardHeld =false;
    private Transform heldCard = null;  

    public bool IsCardHeld()
    {
        return isCardHeld;
    }
    
    public void HoldCard(Transform cardTransform)
    {
        heldCard = cardTransform;
        isCardHeld = true;
    }

    public void DropCardIsHold(Transform targetField)
    {
        if(isCardHeld && heldCard != null)
        {   
            heldCard.localScale = Vector3.one;
            heldCard.SetParent(targetField);
            heldCard.localPosition = Vector3.zero;
            heldCard = null;
            isCardHeld=false;
        }
    }
}
