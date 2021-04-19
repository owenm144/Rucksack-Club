using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clickable : MonoBehaviour
{
	int buttonNumber;
	private GameController controller;
	private RawImage curtain;
	bool fading = false;

	void Start()
	{
		controller = GameObject.Find("GameController").GetComponent <GameController>();
		curtain = GameObject.Find ("FadeImage").GetComponent<RawImage> ();

		GetComponent <Button>().onClick.AddListener (OnClick);
		buttonNumber = transform.GetSiblingIndex ();
	}

	void OnClick()
	{
		StopAllCoroutines ();
		controller.StopAllCoroutines ();
		StartCoroutine (FadeUp());
		StartCoroutine (FadeDown());
	}

	IEnumerator FadeUp()
	{
        Debug.Log("Clickable.FadeUp()");
        
		fading = true;

		Color c = curtain.color;
		for (float f = c.a; f <= 1f; f += 0.2f)
		{
			c.a = f;
			curtain.color = c;
            yield return new WaitForSeconds(0.1f);
        }

        c.a = 1.0f;
        curtain.color = c;

        controller.setScene (buttonNumber);
		fading = false;
	}

	IEnumerator FadeDown()
	{
        Debug.Log("Clickable.FadeDown()");

        while (fading)
		{
			yield return null;
		}

		Color c = curtain.color;
		for (float f = c.a; f >= 0f; f -= 0.2f)
		{
			c.a = f;
			curtain.color = c;
            yield return new WaitForSeconds(0.1f);
        }
	}
}