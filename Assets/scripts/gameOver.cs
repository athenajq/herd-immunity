using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public static gameOver instance;
    public List<GameObject> deadRCows = new List<GameObject>();
    public List<GameObject> deadBCows = new List<GameObject>();
    public List<GameObject> deadYCows = new List<GameObject>();

    public List<GameObject> vaccinatedRCows = new List<GameObject>();
    public List<GameObject> vaccinatedBCows = new List<GameObject>();
    public List<GameObject> vaccinatedYCows = new List<GameObject>();

    public int maxCows = 20;
    public int rPopulation = 2;
    public int bPopulation = 5;
    public int yPopulation = 13;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void addDeadCow(GameObject cow, string tag)
    {
        switch (tag)
        {
            case "cow 1":
                deadYCows.Add(cow);
                Debug.Log("added dead cow");
                break;
            case "cow 2":
                deadBCows.Add(cow);
                Debug.Log("added dead cow");
                break;
            case "cow 3":
                deadRCows.Add(cow);
                Debug.Log("added dead cow");
                break;
            default:
                break;
        }
    }

    public void addVaccinatedCow(GameObject cow, string tag)
    {
        switch (tag)
        {
            case "cow 1":
                vaccinatedYCows.Add(cow);
                Debug.Log("added vaxxed cow");
                break;
            case "cow 2":
                vaccinatedBCows.Add(cow);
                Debug.Log("added vaxxed cow");
                break;
            case "cow 3":
                vaccinatedRCows.Add(cow);
                Debug.Log("added vaxxed cow");
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        int counts = deadBCows.Count + deadYCows.Count + deadRCows.Count + vaccinatedRCows.Count + vaccinatedBCows.Count + vaccinatedYCows.Count;
        Debug.Log(counts + " total cows");
        if (counts >= maxCows)
        {
            //game over
            SceneManager.LoadScene(5); //game over scene
            Debug.Log("game over");
        }
    }
}
