using System; 
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public  static event Action OnClick;

    public static void StopCoroutines()
    {
        OnClick?.Invoke();
    }
}
