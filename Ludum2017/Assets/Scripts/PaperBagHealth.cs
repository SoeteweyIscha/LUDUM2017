using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class PaperBagHealth : NetworkBehaviour
{
    public const int MaxHealth = 3; //Player max health

    private int _currentHealth = MaxHealth;
    Text informationText;  // Set the player's health

    private void Start()
    {
        //Set current health;
        _currentHealth = MaxHealth;
        // If this is the server, tell the deathmatchplayer that this player spawned
        if (isServer)
            DeathManager.AddPaperBag (this);
    }

    public void TakeDamage(int amount)
    {
        if (!isServer || _currentHealth < 0)
        {
            return;
        }

        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Debug.Log("Dead!");
            RpcDied();
            if (DeathManager.RemovePaperBagAndCheckWinner(this))
            {
                PaperBagHealth PaperBag = DeathManager.GetWinner();
                PaperBag.RpcWon();

                Invoke("BackToLobby", 3f);
            }

            return;
        }

    }

    [ClientRpc]
    void RpcDied()
    {
        if (isLocalPlayer)
        {
            informationText = GameObject.FindObjectOfType<Text>();
            informationText.text = "Game Over";

            //disablefunctions
            GetComponent<Char_ctrl>().enabled = false;
            GetComponent<PaperBagShooting_Net>().enabled = false;
        }
    }

    [ClientRpc]
    public void RpcWon()
    {
        if (isLocalPlayer)
        {
            informationText = GameObject.FindObjectOfType<Text>();
            informationText.text = "YouWon";
        }
    }
    void BackToLobby()
    {
        FindObjectOfType<NetworkLobbyManager>().ServerReturnToLobby();
    }

}
