using UnityEngine;

public class CameraShaker : MonoBehaviour
{

    private const float ShakeAmountInit = 0.25f;
    private const float DecreaseFactor = 0.9f;
    private Vector3 _originalPos;
    private float _shakeAmount;

	void Start ()
	{
	    _originalPos = transform.position;
	}

    void Update()
    {
        if (Timer.ChangedBeat)
        {
            _shakeAmount = ShakeAmountInit;
        }

        if (_shakeAmount > 0)
        {
            transform.localPosition = _originalPos + Random.insideUnitSphere * _shakeAmount;

            _shakeAmount *= DecreaseFactor;
        }
        else
        {
            _shakeAmount = 0f;
            transform.localPosition = _originalPos;
        }
    }
}
