using UnityEngine;
using System.Collections;

public class DoubleAutoDoor : MonoBehaviour {
	//Welcome to the included double auto door script! This is a variation of the basic door script, for automatic double doors.
	//The script is set up in such a way that you can call upon the Open/Close function from a custom script,
	//meaning that you can change how you interact with the doors, if you know your way around basic scripting.
	//As a sample, this script includes behaviour for opening and closing, when a character controller is intersecting the trigger of the door.
	//Note that this might not be the most optimal script, but it does the trick!
	//Happy developing! /Marcus S.
	
	public GameObject doorChild; //The door body child of the door prefab.
	public GameObject doorChild2; //The second door body.
	public GameObject audioChild; //The prefab's audio source GameObject, from which the sounds are played.
	
	public AudioClip openSound; //The door opening sound effect (3D sound.)
	public AudioClip closeSound; //The door closing sound effect (3D sound.)
	
	private bool inTrigger = false; //Bool to check if CharacterController is in the trigger.
	private bool doorOpen = false; //Bool used to check the state of the door, if it's open or not.
	
	//Door opening and closing function. Can be called upon from other scripts.
	public void doorOpenClose() {
		//Check so that we're not playing an animation already.
		if (doorChild.GetComponent<Animation>().isPlaying == false) {
			//Check the state of the door, to determine whether to close or open.
			if (doorOpen == false) {
				//Opening door, play Open animation and sound effect.
				doorChild.GetComponent<Animation>().Play("Open");
				doorChild2.GetComponent<Animation>().Play("Open");
				audioChild.GetComponent<AudioSource>().clip = openSound;
				audioChild.GetComponent<AudioSource>().Play();
				doorOpen = true;
			}
			else {
				//Closing door, play Close animation and sound effect.
				doorChild.GetComponent<Animation>().Play("Close");
				doorChild2.GetComponent<Animation>().Play("Close");
				audioChild.GetComponent<AudioSource>().clip = closeSound;
				audioChild.GetComponent<AudioSource>().Play();
				doorOpen = false;
			}
		}
	}
	
	
	
	//The rest is for the interaction with the door. This can be removed or altered if you'd like to control the doors in a different way.
	//Set the inTrigger to true when CharacterController is intersecting, which in turn means routine in Update will check if doors should open.
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag("Player"))
			inTrigger = true;
	}
	//Set the inTrigger to false when CharacterController is out of trigger, which in turn means routine in Update will if doors should close.
	void OnTriggerExit(Collider collider) {
		if (collider.GetComponent<CharacterController>())
			inTrigger = false;
	}
	
	void Update() {
		if (inTrigger == true && doorOpen == false) {
            if (Input.GetButtonDown("Interact"))
		    {
		        doorOpenClose();
		    }
			//If inTrigger is true and doors are closed, open doors.
			
		}
		else if (inTrigger == false && doorOpen == true) {
			//If inTrigger is false and doors are open, close doors.
            if (Input.GetButtonDown("Interact"))
            {
                doorOpenClose();
            }
		}
	}
}
