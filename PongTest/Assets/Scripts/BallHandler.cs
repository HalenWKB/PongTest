using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private Vector3 m_startVelo = new Vector3();
    
    private Vector3 m_velocity;
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_velocity = m_startVelo;
    }

    // Update is called once per frame
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
            
            m_velocity = m_velocity - 2 * (Vector3.Dot(m_velocity, hitInfo.normal)) * hitInfo.normal;
        }
            
        transform.position += m_velocity * Time.deltaTime;
    }
}
