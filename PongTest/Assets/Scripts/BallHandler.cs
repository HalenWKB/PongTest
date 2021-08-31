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
        transform.position += m_velocity * Time.deltaTime;
    }
}
