using System.Collections;
using UnityEngine;

public class BeatIndicator : MonoBehaviour {

    public bool IsColored = false;

    public void Hit()
    {
        StartCoroutine(HitAnimation());
    }

    private IEnumerator HitAnimation()
    {
        transform.position = new Vector2(0, 1);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        var originalScale = transform.GetChild(0).localScale;
        var targetScale = originalScale * 4;
        var timer = 0f;
        while (timer < Timer.TimePerBeat / 3)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                var lerpProgress = timer/Timer.TimePerBeat;
                child.localScale = Vector3.Lerp(originalScale, targetScale, lerpProgress);
                child.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.clear, lerpProgress);
            }

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
