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

            Invoke("BackToLobby", 3f);

            return;
        }
    }

    [ClientRpc]
    void RpcDied()
    {
        informationText = GameObject.FindObjectOfType<Text>();

        if (isLocalPlayer)
            informationText.text = "Game Over";
    }

    void BackToLobby()
    {
        FindObjectOfType<NetworkLobbyManager>().ServerReturnToLobby();
    }
}
