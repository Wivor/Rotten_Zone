using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupOpener : MonoBehaviour
{
    public GameObject popup;
    public GameObject popupToClose;

    public void openPopup(){
        if(popup != null)
        {
            popup.SetActive(true);
            if(popupToClose != null){
                popupToClose.SetActive(false);
            }
            
        }
    }

    public void closePopup(){
        if(popup != null)
        {
            popup.SetActive(false);
        }
    }

    public void togglePopup(){
        if(popup != null)
        {
            if(popup.activeInHierarchy){
                popup.SetActive(false);
            }
            else{
                popup.SetActive(true);
            }
        }
    }
}

