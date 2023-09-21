
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropCard : MonoBehaviour,  IPointerClickHandler
{
    [SerializeField] private RectTransform targetFieldRectTransform;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Check if the card is held by the player (you can use a game manager or other logic to track this)
            bool isCardHeld = CardGameManager.instanceManager.IsCardHeld(); // Example logic, replace with your own

            if (isCardHeld)
            {
                // Drop the held card into this field
                CardGameManager.instanceManager.DropCardIsHold(targetFieldRectTransform);
            }
        }
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
