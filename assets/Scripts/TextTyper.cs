using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Audio;
 
public class TextTyper : MonoBehaviour
{
	public float letterPause = 0.0f;
	public AudioClip typeSound1;
	public AudioClip typeSound2;

	Text m_text;
	[TextArea]public string message;

	// Use this for initialization
	void Start()
	{
		m_text = GetComponent <Text>();
	}

	public void StartTyping(string msg)
	{
		m_text.text = "";
		StopAllCoroutines ();
		StartCoroutine (TypeText (msg));
	}

	IEnumerator TypeText(string message)
	{
		foreach (char letter in message.ToCharArray())
		{
			m_text.text += letter;
	
			//if (typeSound1 && typeSound2)
			//	SoundManager.instance.RandomizeSfx (typeSound1, typeSound2);
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}
	}
}