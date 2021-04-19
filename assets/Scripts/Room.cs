using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject
{			
	[TextArea]
	public string description;
	public string roomName;
	public Sprite sceneImg;
	public RuntimeAnimatorController sceneAnim;

	public List<PathOptions> options;
}