 
using UnityEngine;
using UnityEngine.UI;

public class CardGameManager : MonoBehaviour
{ 
    public static CardGameManager instanceManager;
    private Card _card;
    

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
    
    public void HoldCard(Transform cardTransform, Card card = null)
    {   
        if(isCardHeld && heldCard!=null)
        GameEventListener.ReturnCard();
        heldCard = cardTransform;
        isCardHeld = true;
        _card = card; 
    }

    public void DropCardIsHold(Transform targetField )
    {
        if(isCardHeld && heldCard != null)
        { 
            heldCard.localScale = Vector3.one *10; 
            heldCard.SetParent(targetField);
            heldCard.localPosition = Vector3.zero;
            GameEventListener.ScoreField(_card);
            heldCard = null;
            isCardHeld=false; 
        }
    } 
}
