using UnityEngine;

public class EndGame : MonoBehaviour
{
    private UIManager uiManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            uiManager.GameOver();
            return;
        }
    }

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }



}
