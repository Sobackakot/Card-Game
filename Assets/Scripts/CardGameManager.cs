 
using UnityEngine;
using UnityEngine.UI;

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
        if(isCardHeld && heldCard!=null)
        EventBus.ReturnCard();
        heldCard = cardTransform;
        isCardHeld = true;
    }

    public void DropCardIsHold(Transform targetField)
    {
        if(isCardHeld && heldCard != null)
        {   
            heldCard.localScale = Vector3.one *10; 
            heldCard.SetParent(targetField);
            heldCard.localPosition = Vector3.zero;
            heldCard = null;
            isCardHeld=false;
        }
    }
}
