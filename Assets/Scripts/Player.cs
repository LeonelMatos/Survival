using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Title("PlayerStats")]

    [SerializeField]
    int playerHealth = 100;

    public int playerTeste = 13;

    public int getHealth() {
        return playerHealth;
    }
    public void setHealth(int health) {
        playerHealth = health;
    }
}
