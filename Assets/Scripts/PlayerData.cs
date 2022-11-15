using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int numberOfControllerActicated;

    public PlayerData(PlayerMovement playerMovement)
    {
        numberOfControllerActicated = playerMovement.numberOfControllerActivated;
    }
}
