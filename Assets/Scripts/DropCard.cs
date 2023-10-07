 
using UnityEngine;
using UnityEngine.EventSystems; 

public class DropCard : MonoBehaviour,  IPointerClickHandler
{
    [SerializeField] private CardController cardController;
    [SerializeField] private RectTransform targetFieldRectTransform;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        EventBus.StopCoroutines();
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (CardGameManager.instanceManager.IsCardHeld())
            { 
                CardGameManager.instanceManager.DropCardIsHold(targetFieldRectTransform); 
                EventBus.DropCardisField();
            }
        }
    }   
}
