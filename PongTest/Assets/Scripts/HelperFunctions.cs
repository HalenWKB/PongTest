using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperFunctions
{
    public static bool IsLeftOfOrOnRay2D(Vector2 point, Vector2 rayStart, Vector2 rayDir)
    {
        Vector2 b = rayStart + rayDir;
        Vector2 ab = rayDir;
        Vector2 ap = point - rayStart;

        return Mathf.Sign((b.x - rayStart.x) * (point.y - rayStart.y) - (b.y - rayStart.y) * (point.x - rayStart.x)) <= 0;
    }

    public static Vector3 ReflectVectorOnNormal(Vector3 vectToReflect, Vector3 norm)
    {
        return vectToReflect - 2 * (Vector3.Dot(vectToReflect, norm)) * norm;
    }
}
