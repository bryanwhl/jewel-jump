using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] JewelList jewelListPrefab;
    JewelList jewels;

    void Start()
    {
        jewels = Instantiate(jewelListPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }

    //Use this function to handle situtation when a player lands on this tile
    void landedOn(Player player)
    {
        player.gold += jewels.NumJewels;
        jewels.DestroyAllJewels();
    }

    //Just testing DestroyAllJewels function. Change this later.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            jewels.DestroyAllJewels();
        }
    }

}
