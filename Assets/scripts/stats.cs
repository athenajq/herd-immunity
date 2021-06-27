using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
public class stats : MonoBehaviour
{

    [SerializeField] TMP_Text rVaccinated, rDead, bVaccinated, bDead, yVaccinated, yDead, totalDead, totalVaccinated;
    private void Start()
    {
        gameOver instance = gameOver.instance;
        rVaccinated.text = instance.vaccinatedRCows.Count + " cows | " + instance.vaccinatedRCows.Count / instance.maxCows + "% total population | " + instance.vaccinatedRCows.Count / instance.rPopulation + "% red population";
        bVaccinated.text = instance.vaccinatedBCows.Count + " cows | " + instance.vaccinatedBCows.Count / instance.maxCows + "% total population | " + instance.vaccinatedBCows.Count / instance.bPopulation + "% blue population";
        yVaccinated.text = instance.vaccinatedYCows.Count + " cows | " + instance.vaccinatedYCows.Count / instance.maxCows + "% total population | " + instance.vaccinatedYCows.Count / instance.yPopulation + "% yellow population";

        rDead.text = instance.deadRCows.Count + " cows | " + instance.deadRCows.Count / instance.maxCows + "% total population | " + instance.deadRCows.Count / instance.rPopulation + "% red population";
        bDead.text = instance.deadBCows.Count + " cows | " + instance.deadBCows.Count / instance.maxCows + "% total population | " + instance.deadBCows.Count / instance.bPopulation + "% blue population";
        yDead.text = instance.deadYCows.Count + " cows | " + instance.deadYCows.Count / instance.maxCows + "% total population | " + instance.deadYCows.Count / instance.yPopulation + "% yellow population";

        totalVaccinated.text = instance.vaccinatedRCows.Count + instance.vaccinatedBCows.Count + instance.vaccinatedYCows.Count + " cows";
        totalDead.text = instance.deadRCows.Count + instance.deadBCows.Count + instance.deadYCows.Count + " cows";

        Destroy(instance.gameObject);
    }

    public void replay()
    {
        SceneManager.LoadScene(0);
    }
}