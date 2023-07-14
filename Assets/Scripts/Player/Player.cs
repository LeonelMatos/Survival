using Sirenix.OdinInspector;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Title("PlayerStats")]
    [SerializeField]
    int playerHealth = 100;

    public int getHealth() { return playerHealth; }
    public void setHealth(int health) { playerHealth = health; }


}
