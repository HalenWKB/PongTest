using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PaddleHandler))]
public class AIPaddleInput : MonoBehaviour
{
    private PaddleHandler m_paddle;

    [SerializeField] private float m_aiReactionTimeMin = 0.2f;
    [SerializeField] private float m_aiReactionTimeMax = 0.6f;

    [SerializeField] private float m_aiReadInaccuracy = 2f;

    private bool m_currentInputIsLeft = true;
    
    void Start()
    {
        m_paddle = GetComponent<PaddleHandler>();
        StartCoroutine(MakeMoveDecision());
    }
    
    IEnumerator MakeMoveDecision()
    {
        Vector3 aiReadOfBallPos = Managers.Gameplay.GetBallPos() + (transform.up * Random.Range(-m_aiReadInaccuracy, m_aiReadInaccuracy));
        m_currentInputIsLeft = HelperFunctions.IsLeftOfOrOnRay2D(aiReadOfBallPos, transform.position, transform.right);
        
        float waitTime = Random.Range(m_aiReactionTimeMin, m_aiReactionTimeMax);
        yield return new WaitForSeconds(waitTime);
        
        StartCoroutine(MakeMoveDecision());
    }
    
    void Update()
    {
        m_paddle.MoveInput(m_currentInputIsLeft);
    }
}
