using UnityEngine;

public class CostOfSwords : MonoBehaviour
{
    public int numberOfSwords = 5;   // игрок хочет купить 5 мечей
    public float costOfOneSword = 10.0f;  // Стоимость одного меча — 10 единиц валюты.
    private float totalPurchasePrice; // результат умножения

    void Start()
    {
        // Рассчитываем общую стоимость покупки
        totalPurchasePrice = numberOfSwords * costOfOneSword;

        // Выводим общую стоимость покупки на консоль
        Debug.Log("Общая стоимость покупки: " + totalPurchasePrice);
    }
}
