 
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
 
public class DropCard : MonoBehaviour,  IPointerClickHandler
{ 
    [SerializeField] private RectTransform targetFieldRectTransform;
     
    public void OnPointerClick(PointerEventData eventData)
    {
        GameEventListener.StopCoroutines();
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (CardGameManager.instanceManager.IsCardHeld())
            {
                CardGameManager.instanceManager.DropCardIsHold(targetFieldRectTransform);
                GameEventListener.DropCardisField();
            }
        }
    }   
}
