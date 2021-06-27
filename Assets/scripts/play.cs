using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{

    [SerializeField] GameObject home, helpp;
    public void start()
    {
        SceneManager.LoadScene(1);
    }

    public void help()
    {
        home.SetActive(false);
        helpp.SetActive(true);
    }

    public void back()
    {
        home.SetActive(true);
        helpp.SetActive(false);
    }

}
