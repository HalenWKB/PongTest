using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaddleHandler : MonoBehaviour
{
    [SerializeField] private float m_paddleSpeed = 10;

    [SerializeField] private TextMeshProUGUI m_scoreDisplay;
    private int m_score;

    public void GivePoint()
    {
        m_score++;
        m_scoreDisplay.text = m_score.ToString("N0");
    }
    
    public void MoveInput(bool isLeftInput)
    {
        transform.position += transform.up * m_paddleSpeed * Time.deltaTime * (isLeftInput ? -1 : 1);
    }
}
