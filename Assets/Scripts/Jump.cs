using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject CenterTile;
    public GameObject NorthEastTile;
    public GameObject SouthEastTile;
    public GameObject SouthWestTile;
    public GameObject NorthWestTile;
    public GameObject TopTile;
    public GameObject RightTile;
    public GameObject BottomTile;
    public GameObject LeftTile;

    void Start()  
    {
        CenterTile = GameObject.Find("CenterTile");
        NorthEastTile = GameObject.Find("NorthEastTile");
        SouthEastTile = GameObject.Find("SouthEastTile");
        SouthWestTile = GameObject.Find("SouthWestTile");
        NorthWestTile = GameObject.Find("NorthWestTile");
        TopTile = GameObject.Find("TopTile");
        RightTile = GameObject.Find("RightTile");
        BottomTile = GameObject.Find("BottomTile");
        LeftTile = GameObject.Find("LeftTile");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log(transform.position);
            Debug.Log(CenterTile.transform.position);
            // transform.position = Vector3.MoveTowards(transform.position, center, 0.01f);
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5 + NorthEastTile.transform.position - transform.position, ForceMode.VelocityChange);
        }
    }
}
