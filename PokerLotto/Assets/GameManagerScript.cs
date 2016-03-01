using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{

    void Awake()
    {
        GameObject[] rows = GameObject.FindGameObjectsWithTag("ButtonEliment");
        int[] randomNumbers = creatUniqueRandomNumbers(rows.Length);

        // for (int i = rows.Length-1; i > -1; i--)
        for (int i = 0; i < rows.Length; i++) // BUGGUR finnur bara eh random button eliment
        {
            Text textOnButton = rows[i].transform.Find("Button").GetComponentInChildren<Text>();
            Text textOnHidden = rows[i].transform.Find("HiddenNumber").GetComponentInChildren<Text>();
            GameObject result = rows[i].transform.Find("Result").gameObject;

            result.GetComponentInChildren<Text>().text = randomNumbers[i].ToString();
            result.gameObject.SetActive(false);

           // textOnButton.text = (i + 1).ToString();

            textOnHidden.text = randomNumbers[i].ToString();
            textOnHidden.color = new Color(0, 0, 0, 0);
        }
    }
    int[] creatUniqueRandomNumbers(int arrayLengt)
    {
        int[] randomNumbers = new int[arrayLengt];

        for (int i = 0; i < randomNumbers.Length; i++)
        {
            randomNumbers[i] = Random.Range(1, arrayLengt + 1);

            for (int u = 0; u < i; u++)
            {
                while (randomNumbers[u] == randomNumbers[i])
                {
                    randomNumbers[i] = Random.Range(1, arrayLengt + 1);
                    u = 0;
                }
            }
        }

        return randomNumbers;
    }

    public void ResetButton()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
