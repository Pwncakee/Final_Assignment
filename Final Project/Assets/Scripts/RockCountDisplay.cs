using UnityEngine;
using TMPro; // Add this line

public class RockCountDisplay : MonoBehaviour
{
    public PlayerController player;
    private TextMeshProUGUI text; // Change this line

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>(); // And this line
    }

    void Update()
    {
        text.text = "Rock count: " + player.rockCount;
    }
}


