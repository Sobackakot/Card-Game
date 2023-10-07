using System; 
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public  static event Action OnClick;
    public static event Action OnChange;
    public static event Action OnDropCard;

    public static void StopCoroutines()
    {
        OnClick?.Invoke();
    }
    public static void ReturnCard()
    {
        OnChange?.Invoke();
    }
    public static void DropCardisField()
    {
        OnDropCard?.Invoke();
    }
}
