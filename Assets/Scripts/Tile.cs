using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] JewelList jewelListPrefab;
    JewelList jewels;
    public ArrayList playersJumpingHere = new ArrayList();
    public GameController GameController;
    public Player1 player1;
    public Player2 player2;
    public Player3 player3;
    public Player4 player4;
    [SerializeField] List<PowerUpBase> spawnablePowerUps;
    public int tileNum;
    [SerializeField] PowerUp powerUp;

    public AudioClip collectSFX;
    public GameUI gameUI;
    public GameObject powerupPrefab;
    public Transform powerupSpawn;
    public PowerUp PowerUp
    {
        get { return powerUp; }
        set { this.powerUp = value; }
    } //remember to set this powerup every round if you want to have a powerup on this tile

    void Start()
    {
        jewels = Instantiate(jewelListPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
        powerupSpawn = transform.Find("PowerupSpawn");
        // jewels = new JewelList();
    }

    //Use this function to handle situtation when a player lands on this tile
    void landedOn(Player player)
    {
        player.gold += jewels.NumJewels;
    }

    //Just testing DestroyAllJewels function. Change this later.
    void Update()
    {
        if (tileNum == GameController.numToSpawnPowerUp) {
            jewels.isPowerUpTurn = true;
            PowerUpBase powerUpChosen = spawnablePowerUps[(int)Random.Range(0.0f, 5.99f)];
            
            // powerUp.SetPowerUp(powerUpChosen);
            // powerUp.gameObject.SetActive(true);
            GameObject newPowerup = Instantiate(powerupPrefab, powerupSpawn) as GameObject;
            powerUp = newPowerup.GetComponent<PowerUp>();
            powerUp.SetPowerUp(powerUpChosen);

            GameController.numToSpawnPowerUp = -1;
        } else {
            jewels.isPowerUpTurn = false;
        }
        if (GameController.isAnimationComplete == true)
        {
            if (playersJumpingHere.Count == 1)
            {
                // Debug.Log("Player 1 Jewel: ");
                // Debug.Log(player1.jewel);
                if ((int)playersJumpingHere[0] == 1)
                {
                    AudioManager.instance.PlayGameSFX(collectSFX);

                    if (powerUp != null)
                    {
                        ObtainPowerup1(player1, powerUp);
                    }
                    int jewelsObtained = jewels.NumJewels;
                    List<PowerUp> toBeRemoved = new List<PowerUp>();
                    foreach (var playerPowerups in player1.powerUps)
                    { // loop thru powerups that the player has alrdy obtained
                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                        if (playerPowerups.Base.EffectTarget == EffectTarget.Self)
                        { //if the powerup is meant to target self (e.g. double coins on tile)
                            jewelsObtained = effect.CoinsObtainedAfterEffect(jewelsObtained);
                            playerPowerups.TurnsLeft--; //reduce the turns this power up can be used by 1 (for now all power ups only last 1 turn)
                            if (playerPowerups.TurnsLeft <= 0)
                            {
                                toBeRemoved.Add(playerPowerups);
                            }
                        }
                    }
                    //remove powerUps that have used up their turns
                    foreach (var playerPowerUp in toBeRemoved)
                    {
                        player1.powerUps.Remove(playerPowerUp);
                    }
                    player1.jewel += jewelsObtained;

                    Debug.Log($"player1 now has {player1.jewel} golds");
                }
                else if ((int)playersJumpingHere[0] == 2)
                {
                    if (powerUp != null)
                    {
                        ObtainPowerup2(player2, powerUp);
                    }
                    int jewelsObtained = jewels.NumJewels;
                    List<PowerUp> toBeRemoved = new List<PowerUp>();
                    foreach (var playerPowerups in player2.powerUps)
                    { // loop thru powerups that the player has alrdy obtained
                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                        if (playerPowerups.Base.EffectTarget == EffectTarget.Self)
                        { //if the powerup is meant to target self (e.g. double coins on tile)
                            jewelsObtained = effect.CoinsObtainedAfterEffect(jewelsObtained);
                            playerPowerups.TurnsLeft--; //reduce the turns this power up can be used by 1 (for now all power ups only last 1 turn)
                            if (playerPowerups.TurnsLeft <= 0)
                            {
                                toBeRemoved.Add(playerPowerups);
                            }
                        }
                    }
                    //remove powerUps that have used up their turns
                    foreach (var playerPowerUp in toBeRemoved)
                    {
                        player2.powerUps.Remove(playerPowerUp);
                    }
                    player2.jewel += jewelsObtained;

                    Debug.Log($"player2 now has {player2.jewel} golds");
                }
                else if ((int)playersJumpingHere[0] == 3)
                {
                    if (powerUp != null)
                    {
                        ObtainPowerup3(player3, powerUp);
                    }
                    int jewelsObtained = jewels.NumJewels;
                    List<PowerUp> toBeRemoved = new List<PowerUp>();
                    Debug.Log(player3.powerUps.Count);
                    foreach (var playerPowerups in player3.powerUps)
                    { // loop thru powerups that the player has alrdy obtained
                        // Debug.Log(EffectsDB);
                        Debug.Log(EffectsDB.Effects);
                        Debug.Log(playerPowerups);
                        Debug.Log(playerPowerups.Base);
                        Debug.Log(playerPowerups.Base.Effect);
                        Debug.Log(playerPowerups.Base.Effect.Id);
                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                        if (playerPowerups.Base.EffectTarget == EffectTarget.Self)
                        { //if the powerup is meant to target self (e.g. double coins on tile)
                            jewelsObtained = effect.CoinsObtainedAfterEffect(jewelsObtained);
                            playerPowerups.TurnsLeft--; //reduce the turns this power up can be used by 1 (for now all power ups only last 1 turn)
                            if (playerPowerups.TurnsLeft <= 0)
                            {
                                toBeRemoved.Add(playerPowerups);
                            }
                        }
                    }
                    //remove powerUps that have used up their turns
                    foreach (var playerPowerUp in toBeRemoved)
                    {
                        player3.powerUps.Remove(playerPowerUp);
                    }
                    player3.jewel += jewelsObtained;

                    Debug.Log($"player3 now has {player3.jewel} golds");
                }
                else if ((int)playersJumpingHere[0] == 4)
                {
                    //if there is powerUp on this tile to be obtained
                    if (powerUp != null)
                    {
                        ObtainPowerup4(player4, powerUp);
                    }
                    int jewelsObtained = jewels.NumJewels;
                    List<PowerUp> toBeRemoved = new List<PowerUp>();
                    foreach (var playerPowerups in player4.powerUps)
                    { // loop thru powerups that the player has alrdy obtained
                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                        if (playerPowerups.Base.EffectTarget == EffectTarget.Self)
                        { //if the powerup is meant to target self (e.g. double coins on tile)
                            jewelsObtained = effect.CoinsObtainedAfterEffect(jewelsObtained);
                            playerPowerups.TurnsLeft--; //reduce the turns this power up can be used by 1 (for now all power ups only last 1 turn)
                            if (playerPowerups.TurnsLeft <= 0)
                            {
                                toBeRemoved.Add(playerPowerups);
                            }
                        }
                    }
                    //remove powerUps that have used up their turns
                    foreach (var playerPowerUp in toBeRemoved)
                    {
                        player4.powerUps.Remove(playerPowerUp);
                    }
                    player4.jewel += jewelsObtained;
                    Debug.Log($"player4 now has {player4.jewel} golds");
                }
                jewels.DestroyAllJewels();
                powerUp?.gameObject.SetActive(false); // "destroy" the powerUp object on screen
            }
            else
            {
                List<PowerUp> toBeRemoved1 = new List<PowerUp>();
                List<PowerUp> toBeRemoved2 = new List<PowerUp>();
                List<PowerUp> toBeRemoved3 = new List<PowerUp>();
                List<PowerUp> toBeRemoved4 = new List<PowerUp>();
                //More than one person jumping on this tile, everyone's powerup affect others
                for (int powerUpPlayer = 0; powerUpPlayer < playersJumpingHere.Count; powerUpPlayer++)
                {
                    for (int affectedPlayer = 0; affectedPlayer < playersJumpingHere.Count; affectedPlayer++)
                    {
                        if (affectedPlayer != powerUpPlayer)
                        {
                            if ((int)playersJumpingHere[powerUpPlayer] == 1)
                            {
                                //apply player 1's powerup effects (e.g. knock off) to the affectedPlayer
                                if ((int)playersJumpingHere[affectedPlayer] == 2)
                                {
                                    int updatedJewel = player2.jewel;
                                    foreach (var playerPowerups in player1.powerUps)
                                    { // loop thru powerups that the player has alrdy obtained
                                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                                        //if the powerup is meant to target opponent (e.g. knock off)
                                        if (playerPowerups.Base.EffectTarget == EffectTarget.Opponent)
                                        {
                                            updatedJewel = effect.CoinsObtainedAfterEffect(updatedJewel);
                                            //if this power up has only 1 turn left, and not yet added to the remove list
                                            if (playerPowerups.TurnsLeft <= 1 && !toBeRemoved1.Contains(playerPowerups))
                                            {
                                                toBeRemoved1.Add(playerPowerups);
                                            }
                                        }
                                    }
                                    player2.jewel = updatedJewel;
                                }
                                if ((int)playersJumpingHere[affectedPlayer] == 3)
                                {
                                    int updatedJewel = player3.jewel;
                                    foreach (var playerPowerups in player1.powerUps)
                                    { // loop thru powerups that the player has alrdy obtained
                                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                                        //if the powerup is meant to target opponent (e.g. knock off)
                                        if (playerPowerups.Base.EffectTarget == EffectTarget.Opponent)
                                        {
                                            updatedJewel = effect.CoinsObtainedAfterEffect(updatedJewel);
                                            //if this power up has only 1 turn left, and not yet added to the remove list
                                            if (playerPowerups.TurnsLeft <= 1 && !toBeRemoved1.Contains(playerPowerups))
                                            {
                                                toBeRemoved1.Add(playerPowerups);
                                            }
                                        }
                                    }
                                    player3.jewel = updatedJewel;
                                }
                                if ((int)playersJumpingHere[affectedPlayer] == 4)
                                {
                                    int updatedJewel = player4.jewel;
                                    foreach (var playerPowerups in player1.powerUps)
                                    { // loop thru powerups that the player has alrdy obtained
                                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                                        //if the powerup is meant to target opponent (e.g. knock off)
                                        if (playerPowerups.Base.EffectTarget == EffectTarget.Opponent)
                                        {
                                            updatedJewel = effect.CoinsObtainedAfterEffect(updatedJewel);
                                            //if this power up has only 1 turn left, and not yet added to the remove list
                                            if (playerPowerups.TurnsLeft <= 1 && !toBeRemoved1.Contains(playerPowerups))
                                            {
                                                toBeRemoved1.Add(playerPowerups);
                                            }
                                        }
                                    }
                                    player4.jewel = updatedJewel;
                                }
                            }
                            if ((int)playersJumpingHere[powerUpPlayer] == 2)
                            {

                                //apply player 1's powerup effects (e.g. knock off) to the affectedPlayer
                                if ((int)playersJumpingHere[affectedPlayer] == 1)
                                {
                                    int updatedJewel = player1.jewel;
                                    foreach (var playerPowerups in player2.powerUps)
                                    { // loop thru powerups that the player has alrdy obtained
                                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                                        //if the powerup is meant to target opponent (e.g. knock off)
                                        if (playerPowerups.Base.EffectTarget == EffectTarget.Opponent)
                                        {
                                            updatedJewel = effect.CoinsObtainedAfterEffect(updatedJewel);
                                            //if this power up has only 1 turn left, and not yet added to the remove list
                                            if (playerPowerups.TurnsLeft <= 1 && !toBeRemoved2.Contains(playerPowerups))
                                            {
                                                toBeRemoved2.Add(playerPowerups);
                                            }
                                        }
                                    }
                                    player1.jewel = updatedJewel;
                                }
                                if ((int)playersJumpingHere[affectedPlayer] == 3)
                                {
                                    int updatedJewel = player3.jewel;
                                    foreach (var playerPowerups in player2.powerUps)
                                    { // loop thru powerups that the player has alrdy obtained
                                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                                        //if the powerup is meant to target opponent (e.g. knock off)
                                        if (playerPowerups.Base.EffectTarget == EffectTarget.Opponent)
                                        {
                                            updatedJewel = effect.CoinsObtainedAfterEffect(updatedJewel);
                                            //if this power up has only 1 turn left, and not yet added to the remove list
                                            if (playerPowerups.TurnsLeft <= 1 && !toBeRemoved2.Contains(playerPowerups))
                                            {
                                                toBeRemoved2.Add(playerPowerups);
                                            }
                                        }
                                    }
                                    player3.jewel = updatedJewel;
                                }
                                if ((int)playersJumpingHere[affectedPlayer] == 4)
                                {
                                    int updatedJewel = player4.jewel;
                                    foreach (var playerPowerups in player2.powerUps)
                                    { // loop thru powerups that the player has alrdy obtained
                                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                                        //if the powerup is meant to target opponent (e.g. knock off)
                                        if (playerPowerups.Base.EffectTarget == EffectTarget.Opponent)
                                        {
                                            updatedJewel = effect.CoinsObtainedAfterEffect(updatedJewel);
                                            //if this power up has only 1 turn left, and not yet added to the remove list
                                            if (playerPowerups.TurnsLeft <= 1 && !toBeRemoved2.Contains(playerPowerups))
                                            {
                                                toBeRemoved2.Add(playerPowerups);
                                            }
                                        }
                                    }
                                    player4.jewel = updatedJewel;
                                }
                            }
                            if ((int)playersJumpingHere[powerUpPlayer] == 3)
                            {

                                //apply player 1's powerup effects (e.g. knock off) to the affectedPlayer
                                if ((int)playersJumpingHere[affectedPlayer] == 2)
                                {
                                    int updatedJewel = player2.jewel;
                                    foreach (var playerPowerups in player3.powerUps)
                                    { // loop thru powerups that the player has alrdy obtained
                                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                                        //if the powerup is meant to target opponent (e.g. knock off)
                                        if (playerPowerups.Base.EffectTarget == EffectTarget.Opponent)
                                        {
                                            updatedJewel = effect.CoinsObtainedAfterEffect(updatedJewel);
                                            //if this power up has only 1 turn left, and not yet added to the remove list
                                            if (playerPowerups.TurnsLeft <= 1 && !toBeRemoved3.Contains(playerPowerups))
                                            {
                                                toBeRemoved3.Add(playerPowerups);
                                            }
                                        }
                                    }
                                    player2.jewel = updatedJewel;
                                }
                                if ((int)playersJumpingHere[affectedPlayer] == 1)
                                {
                                    int updatedJewel = player1.jewel;
                                    foreach (var playerPowerups in player3.powerUps)
                                    { // loop thru powerups that the player has alrdy obtained
                                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                                        //if the powerup is meant to target opponent (e.g. knock off)
                                        if (playerPowerups.Base.EffectTarget == EffectTarget.Opponent)
                                        {
                                            updatedJewel = effect.CoinsObtainedAfterEffect(updatedJewel);
                                            //if this power up has only 1 turn left, and not yet added to the remove list
                                            if (playerPowerups.TurnsLeft <= 1 && !toBeRemoved3.Contains(playerPowerups))
                                            {
                                                toBeRemoved3.Add(playerPowerups);
                                            }
                                        }
                                    }
                                    player1.jewel = updatedJewel;
                                }
                                if ((int)playersJumpingHere[affectedPlayer] == 4)
                                {
                                    int updatedJewel = player4.jewel;
                                    foreach (var playerPowerups in player3.powerUps)
                                    { // loop thru powerups that the player has alrdy obtained
                                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                                        //if the powerup is meant to target opponent (e.g. knock off)
                                        if (playerPowerups.Base.EffectTarget == EffectTarget.Opponent)
                                        {
                                            updatedJewel = effect.CoinsObtainedAfterEffect(updatedJewel);
                                            //if this power up has only 1 turn left, and not yet added to the remove list
                                            if (playerPowerups.TurnsLeft <= 1 && !toBeRemoved3.Contains(playerPowerups))
                                            {
                                                toBeRemoved3.Add(playerPowerups);
                                            }
                                        }
                                    }
                                    player4.jewel = updatedJewel;
                                }
                            }
                            if ((int)playersJumpingHere[powerUpPlayer] == 4)
                            {

                                //apply player 1's powerup effects (e.g. knock off) to the affectedPlayer
                                if ((int)playersJumpingHere[affectedPlayer] == 2)
                                {
                                    int updatedJewel = player2.jewel;
                                    foreach (var playerPowerups in player4.powerUps)
                                    { // loop thru powerups that the player has alrdy obtained
                                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                                        //if the powerup is meant to target opponent (e.g. knock off)
                                        if (playerPowerups.Base.EffectTarget == EffectTarget.Opponent)
                                        {
                                            updatedJewel = effect.CoinsObtainedAfterEffect(updatedJewel);
                                            //if this power up has only 1 turn left, and not yet added to the remove list
                                            if (playerPowerups.TurnsLeft <= 1 && !toBeRemoved4.Contains(playerPowerups))
                                            {
                                                toBeRemoved4.Add(playerPowerups);
                                            }
                                        }
                                    }
                                    player2.jewel = updatedJewel;
                                }
                                if ((int)playersJumpingHere[affectedPlayer] == 3)
                                {
                                    int updatedJewel = player3.jewel;
                                    foreach (var playerPowerups in player4.powerUps)
                                    { // loop thru powerups that the player has alrdy obtained
                                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                                        //if the powerup is meant to target opponent (e.g. knock off)
                                        if (playerPowerups.Base.EffectTarget == EffectTarget.Opponent)
                                        {
                                            updatedJewel = effect.CoinsObtainedAfterEffect(updatedJewel);
                                            //if this power up has only 1 turn left, and not yet added to the remove list
                                            if (playerPowerups.TurnsLeft <= 1 && !toBeRemoved4.Contains(playerPowerups))
                                            {
                                                toBeRemoved4.Add(playerPowerups);
                                            }
                                        }
                                    }
                                    player3.jewel = updatedJewel;
                                }
                                if ((int)playersJumpingHere[affectedPlayer] == 1)
                                {
                                    int updatedJewel = player1.jewel;
                                    foreach (var playerPowerups in player4.powerUps)
                                    { // loop thru powerups that the player has alrdy obtained
                                        Effects effect = EffectsDB.Effects[playerPowerups.Base.Effect.Id];
                                        //if the powerup is meant to target opponent (e.g. knock off)
                                        if (playerPowerups.Base.EffectTarget == EffectTarget.Opponent)
                                        {
                                            updatedJewel = effect.CoinsObtainedAfterEffect(updatedJewel);
                                            //if this power up has only 1 turn left, and not yet added to the remove list
                                            if (playerPowerups.TurnsLeft <= 1 && !toBeRemoved4.Contains(playerPowerups))
                                            {
                                                toBeRemoved4.Add(playerPowerups);
                                            }
                                        }
                                    }
                                    player1.jewel = updatedJewel;
                                }
                            }
                        }
                    }
                }
                //remove powerUps that have used up their turns
                foreach (var playerPowerUp in toBeRemoved1)
                {
                    player1.powerUps.Remove(playerPowerUp);
                }
                foreach (var playerPowerUp in toBeRemoved2)
                {
                    player2.powerUps.Remove(playerPowerUp);
                }
                foreach (var playerPowerUp in toBeRemoved3)
                {
                    player3.powerUps.Remove(playerPowerUp);
                }
                foreach (var playerPowerUp in toBeRemoved4)
                {
                    player4.powerUps.Remove(playerPowerUp);
                }
            }
            for (int i = 0; i < playersJumpingHere.Count; i++)
            {
                if ((int)playersJumpingHere[i] == 1)
                {
                    GameController.Player1CoinSettled = true;
                }
                else if ((int)playersJumpingHere[i] == 2)
                {
                    GameController.Player2CoinSettled = true;
                }
                else if ((int)playersJumpingHere[i] == 3)
                {
                    GameController.Player3CoinSettled = true;
                }
                else if ((int)playersJumpingHere[i] == 4)
                {
                    GameController.Player4CoinSettled = true;
                }
            }
            playersJumpingHere = new ArrayList();
        }
    }

    // This function originally was intended to take in one player and apply all it's power up on the
    // player it knocks with.
    // This function was intended to be used in the update function when more than 1 player lands on this tile
    // For example, if player 2,3,4 all jump on this tile. I will call the below using for loop
    // ApplyPowerupEffects(Player1, player2) (apply power up of player 1, say knock off 2 coins, on player 2)
    // ApplyPowerupEffects(Player1, player3) (apply power up of player 1, say knock off 2 coins from player 3)
    // ApplyPowerupEffects(Player2, player1) (apply power up of player 2, say knock off 4 coins from player 1)
    // ApplyPowerupEffects(Player2, player3) (you get what I mean from the above)
    // ApplyPowerupEffects(Player3, player1)
    // ApplyPowerupEffects(Player3, player2)
    // However, problem now is that your Player1, Player2 etc class is not a Player,
    // therefore I cannot write this function and use loop, probably need to hard code it 6 times 
    // in the update function
    public void ApplyPowerupEffects(Player playerWithPowerUp, Player target)
    {

    }

    //Suggestion: Why dont you make all Player1, 2, 3, 4 etc inherit Player? 
    //Altenratively you can have 1 player script and attach to all different players, dunnid 4 scripts
    //By doing so, writing one function ObtainPowerUp(Player player...) is enuf, instead of writing one
    //function for each player.
    void ObtainPowerup1(Player1 player, PowerUp powerUp)
    {
        // Effects must be applied now (e.g. double all coins, half all coins)

        if (powerUp.Base.WhenToApply == WhenToApplyEffect.StartingNow)
        {
            Effects effect = EffectsDB.Effects[powerUp.Base.Effect.Id]; //get effect of this powerup
            int newPlayerJewel = effect.CoinsObtainedAfterEffect(player.jewel);
            player.jewel = newPlayerJewel;   //set the player's jewel (e.g. to two times it's original jewel)
        }
        else if (powerUp.Base.WhenToApply == WhenToApplyEffect.StartingNextRound)
        {
            player.powerUps.Add(powerUp);
        }
    }
    void ObtainPowerup2(Player2 player, PowerUp powerUp)
    {
        // Effects must be applied now (e.g. double all coins, half all coins)

        if (powerUp.Base.WhenToApply == WhenToApplyEffect.StartingNow)
        {
            Effects effect = EffectsDB.Effects[powerUp.Base.Effect.Id]; //get effect of this powerup
            int newPlayerJewel = effect.CoinsObtainedAfterEffect(player.jewel);
            player.jewel = newPlayerJewel;   //set the player's jewel (e.g. to two times it's original jewel)
        }
        else if (powerUp.Base.WhenToApply == WhenToApplyEffect.StartingNextRound)
        {
            player.powerUps.Add(powerUp);
        }
    }
    void ObtainPowerup3(Player3 player, PowerUp powerUp)
    {
        // Effects must be applied now (e.g. double all coins, half all coins)

        if (powerUp.Base.WhenToApply == WhenToApplyEffect.StartingNow)
        {
            Effects effect = EffectsDB.Effects[powerUp.Base.Effect.Id]; //get effect of this powerup
            int newPlayerJewel = effect.CoinsObtainedAfterEffect(player.jewel);
            player.jewel = newPlayerJewel;   //set the player's jewel (e.g. to two times it's original jewel)
        }
        else if (powerUp.Base.WhenToApply == WhenToApplyEffect.StartingNextRound)
        {
            player.powerUps.Add(powerUp);
        }
    }
    void ObtainPowerup4(Player4 player, PowerUp powerUp)
    {
        // Effects must be applied now (e.g. double all coins, half all coins)

        if (powerUp.Base.WhenToApply == WhenToApplyEffect.StartingNow)
        {
            Effects effect = EffectsDB.Effects[powerUp.Base.Effect.Id]; //get effect of this powerup
            int newPlayerJewel = effect.CoinsObtainedAfterEffect(player.jewel);
            player.jewel = newPlayerJewel;   //set the player's jewel (e.g. to two times it's original jewel)
        }
        else if (powerUp.Base.WhenToApply == WhenToApplyEffect.StartingNextRound)
        {
            player.powerUps.Add(powerUp);
        }
    }

    private void OnMouseEnter() {
        if(powerUp != null) {
            gameUI.ShowPowerUpTooltip(powerUp.Base);
        }
    }

    private void OnMouseExit() {
        if(powerUp != null) {
            gameUI.HidePowerUpTooltip();
        }
    }

}
