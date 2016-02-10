﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DoorLock))]
public class BasicDoor : IDoor
{


    //Door opening and closing function. Can be called upon from other scripts.
    override public void doorOpenClose()
    {
        //Check so that we're not playing an animation already.
        if (doorChild.GetComponent<Animation>().isPlaying == false)
        {
            //Check the state of the door, to determine whether to close or open.
            if (!doorOpen)
            {
                //Opening door, play Open animation and sound effect.
                doorChild.GetComponent<Animation>().Play("Open");
                audioChild.GetComponent<AudioSource>().clip = openSound;
                audioChild.GetComponent<AudioSource>().Play();
                doorOpen = true;
            }
            else
            {
                //Closing door, play Close animation and sound effect.
                doorChild.GetComponent<Animation>().Play("Close");
                audioChild.GetComponent<AudioSource>().clip = closeSound;
                audioChild.GetComponent<AudioSource>().Play();
                doorOpen = false;
            }
        }
    }



  
}
