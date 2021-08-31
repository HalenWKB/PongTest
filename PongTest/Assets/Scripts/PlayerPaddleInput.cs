using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PaddleHandler))]
public class PlayerPaddleInput : MonoBehaviour
{
    [SerializeField] private KeyCode m_leftKey = KeyCode.W;
    [SerializeField] private KeyCode m_rightKey = KeyCode.S;

    private PaddleHandler m_paddle;

    void Start()
    {
        m_paddle = GetComponent<PaddleHandler>();
    }
    
    void Update()
    {
        bool lInput = Input.GetKey(m_leftKey);
        bool rInput = Input.GetKey(m_rightKey);
        
        if ((lInput || rInput) && !(lInput && rInput)) m_paddle.MoveInput(lInput);
    }
}
