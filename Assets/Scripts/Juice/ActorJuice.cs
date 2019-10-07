using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorJuice : MonoBehaviour
{
    [SerializeField] private AnimationCurve m_blinkAnimation;
    private HealthBehaviour m_health;
    private Material m_blinkMaterial;

    void Start()
    {
        m_health = GetComponent<HealthBehaviour>();
        m_health.OnHitTaken += HitTaken;
        m_blinkMaterial = GetComponent<SpriteRenderer>().materials[0];
    }

    protected virtual void HitTaken()
    {
        StartCoroutine(_Blink());
    }

    private IEnumerator _Blink()
    {
        float t = 0;
        
        Keyframe lastframe = m_blinkAnimation.keys[m_blinkAnimation.length - 1];
        float duration = lastframe.time;
        float intensity = 0f;

        while(t < duration)
        {
            t += Time.deltaTime;
            intensity = m_blinkAnimation.Evaluate(t);
            m_blinkMaterial.SetFloat("_Intensity", intensity);

            yield return null;
        }
    }
}
