using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static void ResetTransform(this Transform _transform)
    {
        _transform.localPosition = Vector3.zero;
        _transform.localEulerAngles = Vector3.zero;
        _transform.localScale = Vector3.one;
    }
}
