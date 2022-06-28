using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainManu : MonoBehaviour
{
    public GameObject gameObject;
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        gameObject.SetActive(false);
    }
}
