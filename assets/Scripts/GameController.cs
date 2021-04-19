using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
	private Room m_scene;
	private GameObject m_options;
	private Image m_background;
	private RawImage curtain;
	private TextTyper typer;
    public Room campfire;
    public GameObject endScreen;

	void Start()
	{
		m_options = GameObject.Find ("Options");
		m_background = GameObject.Find ("SceneImage").GetComponent <Image> ();
		curtain = GameObject.Find ("FadeImage").GetComponent<RawImage> ();
		typer = GameObject.Find ("NarrativeDisplay").GetComponent <TextTyper> ();
	}

	public void BeginGame()
	{
		setScene (campfire);
		StartCoroutine (FadeIn());
	}

	public void setScene(int n)
	{
        // If this is the end, turn on the end screen
        if (m_scene.options[n].nextScene.roomName == "End")
		{
            endScreen.SetActive(true);
            return;
        }

        // Change the scene
        m_scene = m_scene.options[n].nextScene;

        // Update the animator
        if (m_scene.sceneAnim)
            m_background.GetComponent<Animator>().runtimeAnimatorController = m_scene.sceneAnim;
        else
            m_background.GetComponent<Animator>().runtimeAnimatorController = null;

        // Update the scene description and image
        typer.StartTyping (m_scene.description);
		m_background.sprite = m_scene.sceneImg;

        // Decide which buttons to display
        Clickable[] buttons = m_options.GetComponentsInChildren<Clickable>(true);
        for (int i = 0; i < 4; i++){

			if (i < m_scene.options.Count)
			{
				buttons[i].GetComponent <Button> ().interactable = true;
				buttons[i].GetComponentInChildren<Text>().text = m_scene.options[i].pathDescription;
			}
			else
			{
				buttons[i].GetComponent <Button> ().interactable = false;
				buttons[i].GetComponentInChildren <Text>().text = "";
			}
		}
	}

	public void setScene(Room r)
	{
        // Change the scene
        m_scene = r;

        // Update the animator
        if (m_scene.sceneAnim)
            m_background.GetComponent<Animator>().runtimeAnimatorController = m_scene.sceneAnim;
        else
            m_background.GetComponent<Animator>().runtimeAnimatorController = null;

        // Update the scene description and image
        typer.StartTyping(m_scene.description);
        m_background.sprite = m_scene.sceneImg;

        // Decide which buttons to display
        Clickable[] buttons = m_options.GetComponentsInChildren<Clickable>();
        for (int i = 0; i < 4; i++)
		{
			if (i < m_scene.options.Count)
			{
				buttons[i].GetComponent <Button> ().interactable = true;
				buttons[i].GetComponentInChildren<Text>().text = r.options[i].pathDescription;
			}
			else
			{
				buttons[i].GetComponent <Button> ().interactable = false;
				buttons[i].GetComponentInChildren <Text>().text = "";
			}
		}
	}

	public IEnumerator FadeIn()
	{
		Debug.Log ("GameController.FadeIn()");

		Color c = curtain.color;

		for (float f = c.a; f >= 0f; f -= 0.2f)
		{
			yield return new WaitForSeconds (0.2f);
			c.a = f;
			curtain.color = c;
			yield return null;
		}
	}
}