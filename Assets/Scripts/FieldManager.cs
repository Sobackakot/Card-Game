 
using UnityEngine;
using UnityEngine.UI;

public class FieldManager : MonoBehaviour
{
    [Header("Player 1 Fields")]
    public Image player1SwordField;
    public Image player1LongRangeField;
    public Image player1OnagrField;

    [Header("Player 2 Fields")]
    public Image player2SwordField;
    public Image player2LongRangeField;
    public Image player2OnagrField;

    public void EnableField(string fieldType, int playerNumber)
    {
        // Disable all fields by default
        DisableAllFields(playerNumber);

        // Enable the specified field based on the card type
        Image field = GetField(fieldType, playerNumber);
        if (field != null)
        {
            field.raycastTarget = true;
        }
    }

    public void DisableAllFields(int playerNumber)
    {    
        Image[] playerFields = GetPlayerFields(playerNumber);
        foreach (Image field in playerFields)
        {
            field.raycastTarget = false;
        }
    }

    private Image GetField(string fieldType, int playerNumber)
    {
        switch (fieldType)
        {
            case "Sword":
                return playerNumber == 1 ? player1SwordField : player2SwordField;
            case "Long-range":
                return playerNumber == 1 ? player1LongRangeField : player2LongRangeField;
            case "Onagr":
                return playerNumber == 1 ? player1OnagrField : player2OnagrField;
            default:
                return null;
        }
    }

    private Image[] GetPlayerFields(int playerNumber)
    {
        return playerNumber == 1
            ? new Image[] { player1SwordField, player1LongRangeField, player1OnagrField }
            : new Image[] { player2SwordField, player2LongRangeField, player2OnagrField };
    }
}
