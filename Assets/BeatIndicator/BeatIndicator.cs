using System.Collections;
using UnityEngine;

public class BeatIndicator : MonoBehaviour {

    public void Hit()
    {
        StartCoroutine(HitAnimation());
    }

    public void Miss()
    {
        StartCoroutine(MissAnimation());
    }

    private IEnumerator HitAnimation()
    {
        transform.position = new Vector2(0, 1);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        var originalScale = transform.GetChild(0).localScale;
        var targetScale = originalScale * 5;
        var timer = 0f;
        while (timer < Timer.TimePerBeat)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.localScale = Vector3.Lerp(originalScale, targetScale, timer / Timer.TimePerBeat);
            }

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }

    private IEnumerator MissAnimation()
    {
        var rotationSpeed = 180;
        var timer = 0f;
        while (timer < Timer.TimePerBeat)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.eulerAngles += new Vector3(0, rotationSpeed * Time.deltaTime, 0);
            }

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
