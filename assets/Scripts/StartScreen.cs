using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
	private RawImage curtain;
    bool fading = false;

	void Start()
    {
        curtain = GameObject.Find("FadeImage").GetComponent<RawImage>();
        curtain.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        GetComponentInChildren <Button>().onClick.AddListener (OnClick);

        Begin();
    }

    public void Begin()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }
	
	void OnClick()
    {
        StopAllCoroutines();
        fading = false;
		StartCoroutine (FadeOut());
	}

    public IEnumerator FadeIn()
    {
        Debug.Log("StartButton.FadeIn()");
        fading = true;

        Color c = curtain.color;
        
        for (float f = c.a; f >= 0f; f -= 0.05f)
        {
            yield return new WaitForSeconds(0.1f);
            c.a = f;
            curtain.color = c;
            yield return null;
        }

        c.a = 0.0f;
        curtain.color = c;
        fading = false;
    }

    IEnumerator FadeOut()
    {
        Debug.Log("StartButton.FadeOut()");
        while (fading)
        {
            yield return null;
        }

        Color c = curtain.color;

		for (float f = c.a; f <= 1.2f; f += 0.1f)
        {
            yield return new WaitForSeconds(0.2f);
            c.a = f;
			curtain.color = c;
			yield return null;
		}

        GameObject.Find("GameController").GetComponent<GameController>().BeginGame();
        gameObject.SetActive(false);
	}
}