using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
  public void reload()
  {
    SceneManager.LoadScene("Final Build");
  }

  public void Ending()
  {
    Application.Quit();
  }
}
