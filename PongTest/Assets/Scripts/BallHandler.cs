using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private Vector3 m_startVelo;
    
    private Vector3 m_velocity;
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_velocity = m_startVelo;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, m_velocity, out hit, m_velocity.magnitude * Time.deltaTime))
        {
            m_velocity = m_velocity - 2 * (Vector3.Dot(m_velocity, hit.normal)) * hit.normal;
        }
            
        transform.position += m_velocity * Time.deltaTime;
    }
}
