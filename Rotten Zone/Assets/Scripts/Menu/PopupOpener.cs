using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupOpener : MonoBehaviour
{
    public GameObject popup;

    public void openPopup(){
        if(popup != null)
        {
            popup.SetActive(true);
        }
    }

    public void closePopup(){
        if(popup != null)
        {
            popup.SetActive(false);
        }
    }
}

