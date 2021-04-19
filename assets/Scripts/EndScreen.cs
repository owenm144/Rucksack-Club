using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    RawImage curtain;
    Text quote;
    Text source;
    public List<string> quotes;
    public GameObject startScreen;
    Button campfireButton;
    Button startScreenButton;

	void Start()
    {
        curtain = GameObject.Find("FadeImage").GetComponent<RawImage>();
        quote = transform.Find("Quote").GetComponent<Text>();
        source = transform.Find("Source").GetComponent<Text>();

        Random.InitState(System.DateTime.Now.Millisecond);
        int page = Random.Range(0, quotes.Count);
        quote.text = quotes[page];
        source.text = "-bothy songbook pg " + (page + 1);

        campfireButton = transform.Find("CampfireButton").GetComponent<Button>();
        startScreenButton = transform.Find("StartScreenButton").GetComponent<Button>();

        campfireButton.onClick.AddListener(Campfire);
        startScreenButton.onClick.AddListener(StartScreen);
	}
	
	void Campfire()
    {
        StartCoroutine(FadeToCampfire());
    }

    void StartScreen()
    {
        StartCoroutine(FadeToStartScreen());
    }

    IEnumerator FadeToCampfire()
    {
        Debug.Log("EndScreen.FadeOut()");

        Color c = curtain.color;

        for (float f = c.a; f <= 1.2f; f += 0.1f)
        {
            yield return new WaitForSeconds(0.2f);
            c.a = f;
            curtain.color = c;
            yield return null;
        }

        c.a = 0.0f;
        curtain.color = c;

        GameObject.Find("GameController").GetComponent<GameController>().BeginGame();
        gameObject.SetActive(false);
    }

    IEnumerator FadeToStartScreen()
    {
        Debug.Log("EndScreen.FadeOut()");

        Color c = curtain.color;

        for (float f = c.a; f <= 1.2f; f += 0.1f)
        {
            yield return new WaitForSeconds(0.2f);
            c.a = f;
            curtain.color = c;
            yield return null;
        }

        c.a = 0.0f;
        curtain.color = c;

        startScreen.GetComponent<StartScreen>().Begin();
        gameObject.SetActive(false);
    }
}