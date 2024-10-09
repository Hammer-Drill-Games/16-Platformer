using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 3f;
    public AnimationCurve shakeCurve;
    public float magnitude = 0.7f;
    public bool isShaking = false;

    public IEnumerator Shake(){
        isShaking = true;
        Vector3 originalPos = transform.position;
        float elapsed = 0.0f;

        while(elapsed < shakeDuration){
            elapsed += Time.deltaTime;
            float curveValue = shakeCurve.Evaluate(elapsed / shakeDuration);
            transform.position = originalPos + curveValue * magnitude * Random.insideUnitSphere;
            yield return null;    
        }

        transform.position = originalPos;
        isShaking = false;
    }
}
