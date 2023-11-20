using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsBoardManager : MonoBehaviour
{
    public TMP_Text dartPointsText;
    public TMP_Text molePointsText;
    public TMP_Text totalPointsText;
    public TMP_Text pointsToEvolutionText;

    public static int totalPoints;
    public static int pointsToNextEvolution;
    public static int dartPointsToNextEvolution;
    public static int molePointsToNextEvolution;
    public int pointsLeft;
    public int lastEvolutionDartPointsLeft;
    public int lastEvolutionMolePointsLeft;

    // Start is called before the first frame update
    void Start()
    {
        totalPoints = dartSpawner.points + moleSpawner.points;
        dartPointsToNextEvolution = 30;
        molePointsToNextEvolution = 50;
    }

    // Update is called once per frame
    void Update()
    {
        dartPointsText.text = "Dart MiniGame Points: " + dartSpawner.points.ToString();
        molePointsText.text = "Mole MiniGame Points: " + moleSpawner.points.ToString();
        totalPoints = dartSpawner.points + moleSpawner.points;
        totalPointsText.text = "Total Points: " + totalPoints.ToString();
        pointsLeft = pointsToNextEvolution - totalPoints;
        lastEvolutionDartPointsLeft = dartPointsToNextEvolution - dartSpawner.points;
        lastEvolutionMolePointsLeft = molePointsToNextEvolution - moleSpawner.points;

        pointsToEvolutionText.text = "Points to Next San Pau Evolution: " + pointsLeft.ToString();


        if (!evolutionPetScript.evolution1bool && !evolutionPetScript.evolution2bool && !evolutionPetScript.evolution3bool)
        {
            pointsToNextEvolution = 20;
        }
        else if (evolutionPetScript.evolution1bool && !evolutionPetScript.evolution2bool && !evolutionPetScript.evolution3bool)
        {
            pointsToNextEvolution = 30;
        }
        else if (!evolutionPetScript.evolution1bool && evolutionPetScript.evolution2bool && !evolutionPetScript.evolution3bool)
        {
            pointsToNextEvolution = 50;
            pointsToEvolutionText.text = "Points to Next San Pau Evolution: " + "Dart Points: " + lastEvolutionDartPointsLeft.ToString() + " Mole Points: " + lastEvolutionMolePointsLeft.ToString();
        }
        else if (!evolutionPetScript.evolution1bool && !evolutionPetScript.evolution2bool && evolutionPetScript.evolution3bool)
        {
            pointsToEvolutionText.text = "Last evolution of San Pau achieved! Congratulations!";
        }
    }
}
