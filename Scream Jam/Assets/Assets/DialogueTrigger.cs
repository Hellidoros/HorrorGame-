using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	[SerializeField] private PlayableDirector playableDirector;

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		playableDirector.Pause();
	}
}
