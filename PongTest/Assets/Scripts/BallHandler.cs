using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private float m_serveSpeed = 2;
    [SerializeField] private float m_serveHitSpeedBoostMod = 2;
    
    [SerializeField] private float m_speedUpVal = 1.1f;
    
    private Vector3 m_velocity;
    private bool serving;
    
    public void ServeBall(Vector3 direction)
    {
        m_velocity = direction * m_serveSpeed;
        serving = true;
    }

    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.BoxCast(transform.position, transform.localScale / 2, m_velocity
            , out hitInfo, Quaternion.identity, m_velocity.magnitude * Time.deltaTime))
        {
            Endzone endZoneHit = hitInfo.collider.GetComponent<Endzone>();

            if (endZoneHit != null)
            {
                endZoneHit.BallHit();
                Destroy(gameObject);
                return;
            }
            
            PaddleHandler paddleHit = hitInfo.collider.GetComponent<PaddleHandler>();
            bool hitIsOnPaddle = paddleHit != null;
            
            m_velocity = hitIsOnPaddle
                ? paddleHit.GetBallBounceVectorFromHit(hitInfo, m_velocity) * m_speedUpVal * (serving ? m_serveHitSpeedBoostMod : 1)
                        : HelperFunctions.ReflectVectorOnNormal(m_velocity, hitInfo.normal);
            
            serving = serving && !hitIsOnPaddle;
        }
            
        transform.position += m_velocity * Time.deltaTime;
    }
}
