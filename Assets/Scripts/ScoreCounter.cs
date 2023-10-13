 
using UnityEngine;
using UnityEngine.Events;
using System;
using TMPro;
 
public class ScoreCounter : MonoBehaviour
{    
    [SerializeField] private TextMeshProUGUI _sumScores;
    [SerializeField] private TextMeshProUGUI _sumScoreSword;
    [SerializeField] private TextMeshProUGUI _sumScoreRange;
    [SerializeField] private TextMeshProUGUI _sumScoreOnagr;

    private int totalScoreSword = 0;
    private int totalScoreRange = 0;
    private int totalScoreOnagr = 0;

    private void OnEnable()
    {
        GameEventListener.OnScore += SetScore;
    }
    public void OnDisable()
    {
        GameEventListener.OnScore -= SetScore;
    }
    public void SetScore(Card card)
    {
        string typeCard = card.cardType;
        switch (typeCard)
        {
            case "Sword": totalScoreSword = card.force;
                break;
            case "Long-range": totalScoreRange = card.force;
                break;
            case "Onagr": totalScoreOnagr = card.force;
                break;
            default: break;
        } 
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Update UI text elements with the calculated scores
        _sumScoreSword.text =  totalScoreSword.ToString();
        _sumScoreRange.text =  totalScoreRange.ToString();
        _sumScoreOnagr.text =  totalScoreOnagr.ToString();

        // Calculate total score across all fields
        int totalScore = totalScoreSword + totalScoreRange + totalScoreOnagr;
        _sumScores.text =  totalScore.ToString();

    }
} 
 

