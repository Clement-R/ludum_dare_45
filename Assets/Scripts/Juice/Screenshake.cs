using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    public static Screenshake Instance;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	[SerializeField] private float m_shakeAmount = 0.7f;
	[SerializeField] private float m_decreaseFactor = 1.0f;
	
	private Vector3 m_originalPos;
	
	void Awake()
	{
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
	}
	
	void OnEnable()
	{
		m_originalPos = transform.localPosition;
	}

    public void Shake(float p_shakeDuration)
    {
        StartCoroutine(_Shake(p_shakeDuration));
    }

    private IEnumerator _Shake(float p_shakeDuration)
    {
        while(p_shakeDuration > 0)
        {
			transform.localPosition = m_originalPos + Random.insideUnitSphere * m_shakeAmount;
			p_shakeDuration -= Time.deltaTime * m_decreaseFactor;
            yield return null;
        }

        transform.localPosition = m_originalPos;
    }
}
