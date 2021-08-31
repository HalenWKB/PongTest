using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private List<PaddleHandler> m_players = null;
    [SerializeField] private GameObject m_ballPrefab = null;
    [SerializeField] private Transform m_ballSpawn = null;
    [SerializeField] private int m_scoreToWin = 11;
    [SerializeField] private TextMeshProUGUI m_announcementText = null;
    
    void Start()
    {
        Managers.Instance.GameplaySignIn(this);
        StartCoroutine( WaitWithTextBeforeAction("Get Ready!",SpawnBall));
    }

    
    public void SomebodiesEndzoneWasHit(PaddleHandler paddleHit)
    {
        string whoScored = "";
        int topScore = 0;
        string leadingPlayer;
        // Give a point to all players who didn't stuff up (Left like this for expandable 1v1v1v1 modes!
        for (int i = 0; i < m_players.Count; i++)
        {
            if (m_players[i] != paddleHit)
            {
                m_players[i].GivePoint();
                int score = m_players[i].GetScore();
                if (score > topScore)
                {
                    topScore = score;
                    leadingPlayer = m_players[i].m_name;
                }
                whoScored = m_players[i].m_name;
            }
        }

        if (topScore >= m_scoreToWin) 
            StartCoroutine( WaitWithTextBeforeAction(whoScored + " wins the match!",EndGame, 5));
        else 
            StartCoroutine( WaitWithTextBeforeAction(whoScored + " scored a point!",SpawnBall));
    }

    void SpawnBall()
    {
        Instantiate(m_ballPrefab, m_ballSpawn.position, m_ballSpawn.rotation);
    }

    void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    IEnumerator WaitWithTextBeforeAction(string text, UnityAction action, float waitTime = 2)
    {
        m_announcementText.text = text;
        yield return new WaitForSeconds(waitTime);
        m_announcementText.text = "";
        action.Invoke();
    }
}
