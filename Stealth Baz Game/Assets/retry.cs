using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
  public void reload()
  {
    SceneManager.LoadScene("Erins Scene");
  }

  public void Ending()
  {
    Application.Quit();
  }
}
