using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasFader : MonoBehaviour {

	public float fadeTime = 0.25f;
	public bool willFadeIn = false;
	public bool willFadeOut = false;
	CanvasGroup canvasGroup;
	
	bool isFadingIn = false;
	bool isFadingOut = false;


	// Use this for initialization
	void Start () {
		canvasGroup = GetComponent<CanvasGroup>();

		if (willFadeIn) {
			FadeIn ();
		}
		else if (willFadeOut) {
			FadeOut ();
		}
	}
	
	public void FadeOut() {
		StartCoroutine("FadeOutCo");
	}
	
	public void FadeIn() {
		StartCoroutine("FadeInCo");
	}
	
	IEnumerator FadeOutCo() {
		isFadingOut = true;
		yield return new WaitForEndOfFrame();	// Wait for Start() to finish
		for (float f = 0.99f; f >= 0; f -= Time.fixedDeltaTime/fadeTime) {
			canvasGroup.alpha = f;
			yield return new WaitForFixedUpdate();
		}
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
		isFadingOut = false;
	}
	
	IEnumerator FadeInCo() {
		isFadingIn = true;
		yield return new WaitForEndOfFrame();	// Wait for Start() to finish
		for (float f = 0.01f; f <= 1; f += Time.fixedDeltaTime/fadeTime) {
			canvasGroup.alpha = f;
			yield return new WaitForFixedUpdate();
		}
		canvasGroup.alpha = 1f;
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
		isFadingIn = false;
	}


	public bool IsDoneFadeOut() {
		return canvasGroup.alpha <= 0 && !isFadingOut;
	}

	public bool IsDoneFadeIn() {
		return canvasGroup.alpha >= 1 && !isFadingIn;
	}


}
