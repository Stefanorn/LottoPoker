using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClickAction : MonoBehaviour
{

    Transform result;

    Text endGameTextBox;

    void Awake()
    {
        result = transform.FindChild("Result");
        endGameTextBox = GameObject.FindGameObjectWithTag("EndGameTextBox").GetComponent<Text>();
    }

    public void IWasClicked()
    {
        GameObject[] winCheck = GameObject.FindGameObjectsWithTag("Result"); //Óþarflega þungur kóði

        if (winCheck.Length != 3)
        {
            result.gameObject.SetActive(true);
        }

        if (winCheck.Length == 2)
        {
            CountScore();
        }
    }

    int[] SortArray(int[] array) //Bubble sort
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            for (int u = 0; u < i; u++)
            {
                if (array[u] > array[u + 1])
                {
                    int temp = array[u];
                    array[u] = array[u + 1];
                    array[u + 1] = temp;
                }
            }
        }
        return array;
    }

    void CountScore()
    {
        GameObject[] selectedIcons = GameObject.FindGameObjectsWithTag("Result");
        int[] score = new int[selectedIcons.Length];
        string scoreString = "";
        int totalScore = 0;
        for (int i = 0; i < selectedIcons.Length; i++)
        {
            string textOnIcon = selectedIcons[i].GetComponentInChildren<Text>().text;
            score[i] = int.Parse(textOnIcon);
            totalScore += score[i];
        }

        if (score[0] % 2 == 0 &&
               score[1] % 2 == 0 &&
               score[2] % 2 == 0)
        {
            scoreString += "þú fékkst bara séttar tölur sem gilda 20 stigum ";
            totalScore += 20;
        }
        else if (score[0] % 2 == 1 &&
                score[1] % 2 == 1 &&
                score[2] % 2 == 1)
        {
            scoreString += "þú fékkst bara odda tölur sem gilda 20 stigum ";
            totalScore += 20;
        }
        score = lottoPoker.SortArray(score);

        if ((score[0] +1) == score[1] && (score[0] + 2) == score[2])
        {
            scoreString += "Þú fékkst röð sem gildir 30 stigum ";
            totalScore += 30;
        }

        scoreString += " helidar stig eru " + totalScore;
        endGameTextBox.text = scoreString;
    }


}
