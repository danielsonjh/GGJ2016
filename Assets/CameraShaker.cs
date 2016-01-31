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

	    Timer.OnPreciseBeat += ResetShakeAmount;
	}

    void Update()
    {
        transform.localPosition = _originalPos + Random.insideUnitSphere * _shakeAmount;

        _shakeAmount *= DecreaseFactor;
    }

    private void ResetShakeAmount()
    {
        if (Timer.CurrentBeat >= Timer.BeatsPerMeasure/2)
        {
            _shakeAmount = ShakeAmountInit;
        }
        else
        {
            _shakeAmount = ShakeAmountInit / 2;
        }
    }
}
