
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropCard : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private GameObject parentObject;
    [SerializeField] private CardController card;

    private Image cardInField; 

    private void Start()
    { 
    }
    public void OnPointerClick(PointerEventData eventData) //IPointerClickHandler - listens to the click
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            LeftMouseClick();
        else
            RightMouseClick();
    }

    public void OnPointerEnter(PointerEventData eventData) // IPointerEnterHandler - Show name item in slot and color slot
    {
         
    }

    public void OnPointerExit(PointerEventData eventData) // IPointerExitHandler - Break show name and color slot
    {
         
    }
    
    public virtual void LeftMouseClick()
    {
        card.childObject.transform.SetParent(parentObject.transform);
        cardInField = card.childObject.GetComponent<Image>();
        cardInField.raycastTarget = false;
    }
    public virtual void RightMouseClick()
    {
         
    }


    //private IEnumerable<Vector3> EvaluateSlerpPoints(Vector3 start, Vector3 end, float centerOffset)
    //{
    //    var centerPivot = (start + end) * 0.5f;
    //    centerPivot -= new Vector3(0, -centerOffset);
    //    var startRelativeCenter = start - centerPivot;
    //    var endRelativeCenter = end - centerPivot;
    //    var f = 1f / 10;
    //    for (var i = 0f; i < 1 + f; i += f)
    //    {
    //        yield return Vector3.Slerp(startRelativeCenter, endRelativeCenter, i) + centerPivot;
    //    }
    //}

}
