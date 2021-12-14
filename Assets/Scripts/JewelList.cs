using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelList : MonoBehaviour
{
    List<Jewel> jewelList;
    [SerializeField] Jewel jewelPrefab;
    private int numJewels;

    void Start()
    {
        InitJewels();
        SetNumber(9);
    }

    public void InitJewels()
    {
        jewelList = new List<Jewel>();
        float[] posArray = { -0.25f, 0f, 0.25f };
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                float newX = transform.position.x + posArray[i];
                float newY = transform.position.y + 0.25f;
                float newZ = transform.position.z + posArray[j];
                Jewel newJewel = Instantiate(jewelPrefab, new Vector3(newX, newY, newZ), transform.rotation);
                jewelList.Add(newJewel);
            }
        }
    }

    public void DestroyAllJewels()
    {
        SetNumber(0);
    }

    //Sets the number of active jewels on the tile
    public void SetNumber(int num)
    {
        numJewels = num;
        Debug.Log("inside set number");
        for (int i = 0; i < 9; i++)
        {
            jewelList[i].gameObject.SetActive(false);
        }
        if (num > 0)
        {
            jewelList[4].gameObject.SetActive(true);
        }
        if (num > 1)
        {
            jewelList[5].gameObject.SetActive(true);
        }
        if (num > 2)
        {
            jewelList[3].gameObject.SetActive(true);
        }
        if (num > 3)
        {
            jewelList[1].gameObject.SetActive(true);
        }
        if (num > 4)
        {
            jewelList[7].gameObject.SetActive(true);
        }
        if (num > 5)
        {
            jewelList[0].gameObject.SetActive(true);
        }
        if (num > 6)
        {
            jewelList[2].gameObject.SetActive(true);
        }
        if (num > 7)
        {
            jewelList[8].gameObject.SetActive(true);
        }
        if (num > 8)
        {
            jewelList[6].gameObject.SetActive(true);
        }
    }

    public int NumJewels
    {
        get { return numJewels; }
    }
}
