using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
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
    public GameController GameController;
    public Tile CenterTileScript;
    public Tile NorthEastTileScript;
    public Tile SouthEastTileScript;
    public Tile SouthWestTileScript;
    public Tile NorthWestTileScript;
    public Tile TopTileScript;
    public Tile RightTileScript;
    public Tile BottomTileScript;
    public Tile LeftTileScript;
    public int jewel;

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

        CenterTileScript = CenterTile.GetComponent<Tile>();
        NorthEastTileScript = NorthEastTile.GetComponent<Tile>();
        SouthEastTileScript = SouthEastTile.GetComponent<Tile>();
        SouthWestTileScript = SouthWestTile.GetComponent<Tile>();
        NorthWestTileScript = NorthWestTile.GetComponent<Tile>();
        TopTileScript = TopTile.GetComponent<Tile>();
        RightTileScript = RightTile.GetComponent<Tile>();
        BottomTileScript = BottomTile.GetComponent<Tile>();
        LeftTileScript = LeftTile.GetComponent<Tile>();
        jewel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = new Vector3(0, 0, 0);
        if (GameController.areAllInputsIn == true) 
        {
            if (GameController.Player3Flag == 1) {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 5 + CenterTile.transform.position - transform.position, ForceMode.VelocityChange);
                CenterTileScript.playersJumpingHere.Add(3);
            } else if (GameController.Player3Flag == 2) {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 5 + SouthEastTile.transform.position - transform.position, ForceMode.VelocityChange);
                SouthEastTileScript.playersJumpingHere.Add(3);
            } else if (GameController.Player3Flag == 3) {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 5 + BottomTile.transform.position - transform.position, ForceMode.VelocityChange);
                BottomTileScript.playersJumpingHere.Add(3);
            } else if (GameController.Player3Flag == 4) {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 5 + SouthWestTile.transform.position - transform.position, ForceMode.VelocityChange);
                SouthWestTileScript.playersJumpingHere.Add(3);
            }
            GameController.Player3Flag = 0;
        }
    }
}
