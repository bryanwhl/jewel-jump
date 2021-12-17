using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
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
    public Tile CenterTileScript;
    public Tile NorthEastTileScript;
    public Tile SouthEastTileScript;
    public Tile SouthWestTileScript;
    public Tile NorthWestTileScript;
    public Tile TopTileScript;
    public Tile RightTileScript;
    public Tile BottomTileScript;
    public Tile LeftTileScript;
    public GameController GameController;
    public int jewel;
    public List<PowerUp> powerUps;
    public AudioClip jumpSFX;
    public AudioClip landedSFX;

    public CharacterAnimationManager animationManager;

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
        powerUps = new List<PowerUp>();

        animationManager = GetComponentInChildren<CharacterAnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = new Vector3(0, 0, 0);
        if (GameController.areAllInputsIn == true)
        {
            // Jump Triggered
            AudioManager.instance.PlayPlayerSFX(jumpSFX, 1);
            animationManager.Jump();

            if (GameController.Player1Flag == 1)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 5 + TopTile.transform.position - transform.position, ForceMode.VelocityChange);
                TopTileScript.playersJumpingHere.Add(1);
            }
            else if (GameController.Player1Flag == 2)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 5 + NorthEastTile.transform.position - transform.position, ForceMode.VelocityChange);
                NorthEastTileScript.playersJumpingHere.Add(1);
            }
            else if (GameController.Player1Flag == 3)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 5 + CenterTile.transform.position - transform.position, ForceMode.VelocityChange);
                CenterTileScript.playersJumpingHere.Add(1);
            }
            else if (GameController.Player1Flag == 4)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 5 + NorthWestTile.transform.position - transform.position, ForceMode.VelocityChange);
                NorthWestTileScript.playersJumpingHere.Add(1);
            }
            GameController.Player1Flag = 0;
        }
    }

    public void SetReady() {
        animationManager.Ready();
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Landed");
        AudioManager.instance.PlayPlayerSFX(landedSFX, 1);
        animationManager.Land();
    }
}
