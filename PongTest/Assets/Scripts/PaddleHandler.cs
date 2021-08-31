using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleHandler : MonoBehaviour
{
    [SerializeField] private float m_paddleSpeed = 10;
    
    public void MoveInput(bool isLeftInput)
    {
        transform.position += transform.up * m_paddleSpeed * Time.deltaTime * (isLeftInput ? -1 : 1);
    }
}
