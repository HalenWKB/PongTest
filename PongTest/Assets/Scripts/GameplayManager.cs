using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private List<PaddleHandler> m_players;
    [SerializeField] private GameObject m_ballPrefab;
    
    void Start()
    {
        Managers.Instance.GameplaySignIn(this);
    }

    public void SomebodiesEndzoneWasHit(PaddleHandler paddleHit)
    {
        for (int i = 0; i < m_players.Count; i++)
        {
            if (m_players[i] != paddleHit)
            {
                m_players[i].GivePoint();
            }
        }
    }
}
