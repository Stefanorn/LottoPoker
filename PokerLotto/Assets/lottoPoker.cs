using UnityEngine;
using System.Collections;

public class lottoPoker : MonoBehaviour
{


    public static int[] SortArray(int[] array) //Bubble sort
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
}
