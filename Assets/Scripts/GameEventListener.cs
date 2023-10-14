using System; 
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener: MonoBehaviour
{
    public  static event Action OnClick;
    public static event Action OnChange;
    public static event Action  OnDropCard;
    public static event Action<Card> OnScore;
    public static event Action<string,int> onEnableField;



    public static void StopCoroutines() => OnClick?.Invoke();
    public static void ReturnCard() => OnChange?.Invoke();
    public static void DropCardisField() => OnDropCard?.Invoke();  
    public static void ScoreField(Card card) => OnScore?.Invoke(card);
    public static void EnableField(string field, int playr)=> onEnableField?.Invoke(field,playr);
}

 
