using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManagerSc : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreUI;
    [SerializeField] TMP_Text ColinUI;
    [SerializeField] TMP_Text LifesUI;
    [SerializeField] Image GameOverImage;
    [SerializeField] GameObject GameOverUI;

    [SerializeField] float scoreFactor;

    float score = 0;
    int coins = 0;
    int lifes = 3;

    private void Update()
    {
        score = Time.time * scoreFactor;
        ScoreUI.text = ((int)score).ToString();
        if (lifes <= 0)
        {
            // deathhh
            GameOverUI.SetActive(true);
        }
    }
    public void ChangeCoin(int amount)
    {
        coins += amount;
        ColinUI.text = coins.ToString();
    }
    public void ChangeLifes(int amount)
    {
        lifes += amount;
        LifesUI.text = lifes.ToString();
    }
}
