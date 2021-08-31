using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Serialization;

public class PaddleHandler : MonoBehaviour
{
    [SerializeField] private float m_paddleSpeed = 10;
    [SerializeField] private float m_paddleSkewBallMod = 0.5f;
    
    public void MoveInput(bool isLeftInput)
    {
        transform.position += transform.up * m_paddleSpeed * Time.deltaTime * (isLeftInput ? -1 : 1);
    }


    bool IsBallHittingFrontOfPaddle(Vector3 ballHitNorm)
    {
        return HelperFunctions.IsLeftOfOrOnRay2D(transform.position + (ballHitNorm * 100),
            transform.position - transform.right, -transform.up) ;
    }
    
    public Vector3 GetBallBounceVectorFromHit(RaycastHit hit, Vector3 currentVect)
    {
        if (IsBallHittingFrontOfPaddle(hit.normal))
        {
            Vector3 resultVectOnPaddleNorm = Vector3.Project(-currentVect, hit.normal);
            resultVectOnPaddleNorm -= transform.up 
                                      * HelperFunctions.HowLeftOfRayIsPoint2D(hit.point, transform.position, -transform.right)
                                      * m_paddleSkewBallMod;
            return resultVectOnPaddleNorm;
        }
        else return HelperFunctions.ReflectVectorOnNormal(currentVect, hit.normal);
    }
}
