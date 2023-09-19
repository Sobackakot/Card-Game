
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform cardRectTransform;
    [SerializeField] private RectTransform targetAnchoredPosition;
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 originalAnchoredPosition;
    private Vector2 finalAnchoredPosition;

    [SerializeField] private Image _showCurrentCard;
    [SerializeField] private Image _cardPrefab;

    private Vector3 originalScale;
    private Coroutine _coroutineScale; 
    private float scaleSpeed = 5f;

    private void Start()
    {
        originalAnchoredPosition = cardRectTransform.anchoredPosition;
        finalAnchoredPosition = targetAnchoredPosition.anchoredPosition;
        originalScale = transform.localScale;
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
        _coroutineScale = StartCoroutine(ScaleElement(originalScale * 1.5f));
    }

    public void OnPointerExit(PointerEventData eventData) // IPointerExitHandler - Break show name and color slot
    { 
        if (_coroutineScale != null)
        {
            StopCoroutine(_coroutineScale);
            _coroutineScale = null;
            transform.localScale = originalScale;
        }
    }

    public virtual void LeftMouseClick()
    { 
        StartCoroutine(MoveCardToTarget());
        _showCurrentCard.sprite = _cardPrefab.sprite; 
        Destroy(gameObject);
    }

    public virtual void RightMouseClick()
    {

    }

    private IEnumerator ScaleElement(Vector3 targetScale)
    {
        float elapsedTime = 0f;
        Vector3 startingScale = transform.localScale;

        while (elapsedTime < (1f / scaleSpeed))
        {
            transform.localScale = Vector3.Lerp(startingScale, targetScale, elapsedTime * scaleSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }

    private IEnumerator MoveCardToTarget()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            cardRectTransform.anchoredPosition = Vector2.Lerp(originalAnchoredPosition, finalAnchoredPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;  
            yield return null;
        }
        // Ensure the card reaches the exact destination
        cardRectTransform.anchoredPosition = finalAnchoredPosition;
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

