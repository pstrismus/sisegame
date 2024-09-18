using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIbot : MonoBehaviour
{
    enum Difficulty { Easy, Medium, Hard }
    [SerializeField] Difficulty CurrentDifficulty;

    public static AIbot instance = null;
    public GameObject[] rows;
    bool isTrue;
    private void Start()
    {
        rows = GameObject.FindGameObjectsWithTag("raf");
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void BotMove()
    {
        switch (CurrentDifficulty)
        {
            case Difficulty.Easy:
                EasyBot();
                break;
            case Difficulty.Medium:
                MediumBot();
                break;
            case Difficulty.Hard:
                HardBot();
                break;
        }
    }

    [System.Obsolete]
    private int CountStonesInRow(int row)
    {
        int stoneCount = 0;
        isTrue = false;
        List <GameObject> rowstone = rows[row].GetComponent<raflar>().siseObj;
        List<GameObject> indexcount = new List<GameObject>();
        List<List<GameObject>> indexList = new List<List<GameObject>>();
        
        foreach (GameObject isSise in rows[row].GetComponent<raflar>().siseObj)
        {
            isTrue = (isSise.transform.GetChildCount() == 0) ? false : true; 
            if (isTrue)
            {
                break;
            }
        }

        if (isTrue == true)
        {
            foreach (GameObject rowobje in rowstone)
            {

                if (rowobje.transform.childCount > 0)
                {
                    indexcount.Add(rowobje);
                    stoneCount++;
                }

                if ((rowobje.transform.childCount == 0 && stoneCount > 0) ||
                    (rowobje == rowstone[rowstone.Count - 1] && stoneCount > 0))
                {
                    indexList.Add(new List<GameObject>(indexcount));
                    indexcount.Clear();
                    Debug.Log(stoneCount);
                    stoneCount = 0;
                }
            }


            if (indexList.Count > 0)
            {

                int rowRow = Random.Range(0, indexList.Count);

                if (indexList[rowRow].Count > 0)
                {
                    int rowRowrow = Random.Range(1, indexList[rowRow].Count + 1);

                    for (int i = 1; i <= rowRowrow; i++)
                    {
                        int rowRowrowýndex = Random.Range(0, indexList[rowRow].Count - 1);
                        indexList[rowRow][rowRowrowýndex].transform.GetChild(0).GetComponent<PatlaSise>().Click();
                        indexList[rowRow].Remove(indexList[rowRow][rowRowrowýndex]);
                    }
                    buttonclick.instance.Click();
                }
                else
                {
                    Debug.Log("Seçilen alt liste boþ.");
                }
            }
            else
            {
                Debug.Log("indexList boþ.");
            }

            
        }
        else
        {
            EasyBot();
        }

        return stoneCount;
    }

    [System.Obsolete]
    private void EasyBot()
    {     
        int row = Random.Range(0, rows.Length); 
        int stoneCount = CountStonesInRow(row);

    }

    public void MediumBot()
    {
        Debug.Log("OrtaBot");
    }

    public void HardBot()
    {
        Debug.Log("ZorBot");
    }
}
