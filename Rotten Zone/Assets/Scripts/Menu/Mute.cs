using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    public GameObject button;
    public void MuteAudio()
    {
        if(button != null)
        {
            AudioListener.pause = !AudioListener.pause;
            if(AudioListener.pause){
                button.SetActive(false);
            }
            else{
                button.SetActive(true);
            }
        }
    }
}
