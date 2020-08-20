using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilityFunctions
{
    public static Quaternion FlatLookAt(Vector2 targetPos, Vector2 thisPos)
    {
        targetPos = (targetPos - thisPos).normalized;
        float rot_z = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, rot_z);
    }
}
