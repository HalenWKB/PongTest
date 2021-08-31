using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PaddleHandler))]
public class AIPaddleInput : MonoBehaviour
{
    private PaddleHandler m_paddle;

    void Start()
    {
        m_paddle = GetComponent<PaddleHandler>();
    }
    
    void Update()
    {
        bool lInput = HelperFunctions.IsLeftOfOrOnRay2D(Managers.Gameplay.GetBallPos(), transform.position, transform.right);
        bool rInput = !lInput;
        
        if (lInput || rInput) m_paddle.MoveInput(lInput);
    }
}
