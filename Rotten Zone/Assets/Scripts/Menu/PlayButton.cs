using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class PlayButton : MonoBehaviour
 {
      public void handlePlayButton()
      {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }
    public void handleGoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
