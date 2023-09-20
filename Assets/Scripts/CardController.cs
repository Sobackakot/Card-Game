
using System.Collections; 
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform cardRectTransform;
    [SerializeField] private RectTransform targetPosition;
    [SerializeField] private float spidTransform =5;
    
    private Image selectedCard;

    private Vector3 originalAnchoredPosition;
    private Vector3 finalAnchoredPosition; 

    private Vector3 originalScale;
    private Coroutine _coroutineScale; 
    private float scaleSpeed = 3f;

    public GameObject childObject;

    private void Start()
    {   
        originalAnchoredPosition = cardRectTransform.position;
        finalAnchoredPosition = targetPosition.position; 
        originalScale = transform.localScale;
        selectedCard = GetComponent<Image>(); 
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
        StartCoroutine(ScaleElement(originalScale * 3f)); 
        selectedCard.raycastTarget = false;
        childObject = GetComponent<GameObject>();
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
            cardRectTransform.position = Vector3.Lerp(originalAnchoredPosition, finalAnchoredPosition, elapsedTime);
            elapsedTime += Time.deltaTime * spidTransform;
            yield return null;
        } 
        cardRectTransform.position = finalAnchoredPosition;
    }
     
}

