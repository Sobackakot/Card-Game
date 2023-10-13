using UnityEngine;

public class CostOfSwords : MonoBehaviour
{
    public int numberOfSwords = 5;   // ����� ����� ������ 5 �����
    public float costOfOneSword = 10.0f;  // ��������� ������ ���� � 10 ������ ������.
    private float totalPurchasePrice; // ��������� ���������

    void Start()
    {
        // ������������ ����� ��������� �������
        totalPurchasePrice = numberOfSwords * costOfOneSword;

        // ������� ����� ��������� ������� �� �������
        Debug.Log("����� ��������� �������: " + totalPurchasePrice);
    }
}
