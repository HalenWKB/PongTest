using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endzone : MonoBehaviour
{
    [SerializeField] private PaddleHandler m_paddleRef = null;

    public void BallHit()
    {
        Managers.Gameplay.SomebodiesEndzoneWasHit(m_paddleRef);
    }
}
