using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject sweets;
    [SerializeField] private GameObject heart_top;
    [SerializeField] private Text messageTxt;

    private int amountSelectedSweets;
    private bool isGameOver;

    public void UpdateCountOfSweets()
    {
        amountSelectedSweets++;
        if (amountSelectedSweets == sweets.transform.childCount && !isGameOver)
        {
            isGameOver = true;
            heart_top.SetActive(true);

            messageTxt.text = "DONE!";
        }
    }
}
