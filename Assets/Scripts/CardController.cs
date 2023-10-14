
using System.Collections; 
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{    
    [SerializeField] private Card card; 

    [Header("Card Transform")]
    [SerializeField] private RectTransform cardRectTransform;
    [SerializeField] private RectTransform targetPosition;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private RectTransform returnCardInFirld;

    private Image imageComponentCard;
    private SpriteRenderer spriteRendererCard; 

    private Vector3 originalAnchoredPosition;
    private Vector3 finalAnchoredPosition;

    [Header("Card Scale")]
    private Renderer cardLayer;
    private int originalSortingOrder;
    private Vector3 originalScale;
    private Coroutine _coroutineScale; 
    private Coroutine _coroutineMove; 
    private float scaleSpeed = 3f; 

    private void OnEnable()
    {
        GameEventListener.OnClick += GameEventListener_OnClick;
        GameEventListener.OnChange += GameEventListener_OnChange;
        GameEventListener.OnDropCard += GameEventListener_OnDropCard;
    } 
    private void OnDisable()
    {
        GameEventListener.OnClick -= GameEventListener_OnClick;
        GameEventListener.OnChange -= GameEventListener_OnChange;
        GameEventListener.OnDropCard -= GameEventListener_OnDropCard;
    }
    private void Start()
    {  
        originalAnchoredPosition = cardRectTransform.position; 
        finalAnchoredPosition = targetPosition.position; 
        originalScale = transform.localScale;
        spriteRendererCard = GetComponent<SpriteRenderer>();
        imageComponentCard = GetComponent<Image>();
        cardLayer =GetComponent<Renderer>();
        originalSortingOrder = cardLayer.sortingOrder; 
    }
    private void GameEventListener_OnDropCard( )
    {
        spriteRendererCard.sprite = card.image_2;
        imageComponentCard.raycastTarget = false;
    }
    private void GameEventListener_OnChange()
    {
        CardGameManager.instanceManager.DropCardIsHold(returnCardInFirld);
        imageComponentCard.raycastTarget = true;
        spriteRendererCard.sprite = card.image_2; 
    }
    private void GameEventListener_OnClick()
    {
        if (_coroutineMove != null)
        {
            StopCoroutine(_coroutineMove);
            _coroutineMove = null; 
        }
    }
    public void OnPointerClick(PointerEventData eventData)  
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            LeftMouseClick();
        else
            RightMouseClick();
    }

    public void OnPointerEnter(PointerEventData eventData)  
    {
        _coroutineScale = StartCoroutine(ScaleElement(originalScale * 2f));
        cardLayer.sortingOrder = originalSortingOrder + 1;
    }

    public void OnPointerExit(PointerEventData eventData)  
    {
        ResetScale();
    }
    private void ResetScale()
    {
        if (_coroutineScale != null)
        {
            StopCoroutine(_coroutineScale);
            _coroutineScale = null;
            transform.localScale = originalScale;
            cardLayer.sortingOrder = originalSortingOrder;
        } 
    }
    public virtual void LeftMouseClick()
    { 
        _coroutineMove = StartCoroutine(MoveCardToTarget());
         StartCoroutine(ScaleElement(originalScale * 3.5f)); 
        CardGameManager.instanceManager.HoldCard(cardRectTransform, card);
        PickUpCard(); 
        ActiveField();   
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
            elapsedTime += Time.deltaTime * moveSpeed;
            cardLayer.sortingOrder = originalSortingOrder + 2;
            yield return null;
        } 
        cardRectTransform.position = finalAnchoredPosition;
        cardLayer.sortingOrder = originalSortingOrder;
    } 
    private void ActiveField()
    {
        string cardType = card.cardType;
        int playerNumber = 1; /// 
        GameEventListener.EnableField(cardType, playerNumber);
    }
    private void PickUpCard()
    {
        if (CardGameManager.instanceManager.IsCardHeld())
        {
            imageComponentCard.raycastTarget = false;
            spriteRendererCard.sprite = card.image_1;  
        }
    }    

}

