using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour {
    [Title("Player", "Show Player Stats", TitleAlignments.Centered)]
    [Required]
    public Player player;

    public TextMeshProUGUI healthText;
    [ColorUsage(false), LabelWidth(300)]
    public Color healthColor;


    private void Update () {
        healthText.color = healthColor;

        healthText.SetText("" + player.getHealth());

    }
}
