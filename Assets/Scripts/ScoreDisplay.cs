using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text redScoreText;
    public Text blueScoreText;

    private int redScore;
    private int blueScore;

    private void Start()
    {
        // Assuming you have references to your Red and Blue score variables
        // You can set them here or elsewhere in your game logic

        // Example initialization
        redScore = 0;
        blueScore = 0;
    }

    private void Update()
    {
        // Assuming you update your Red and Blue score variables elsewhere in your game logic
        // You can update the text here to reflect the current scores

        // Example update
        redScoreText.text = "Red Score: " + redScore.ToString();
        blueScoreText.text = "Blue Score: " + blueScore.ToString();
    }
}
