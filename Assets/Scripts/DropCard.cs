 
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.EventSystems;
 
public class DropCard : MonoBehaviour,  IPointerClickHandler
{ 
    [SerializeField] private RectTransform targetFieldRectTransform;

    List<string> dropCards = new List<string>()
    {
        "asdf", "asdsdf", "asvdfg", "llskkd"
    };
    public void Start()
    {
        IEnumerator<string> str = dropCards.GetEnumerator();
        while(str.MoveNext())
        {
            string text = str.Current;
            Debug.Log(text);
        }
        str.Reset();
    }
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
