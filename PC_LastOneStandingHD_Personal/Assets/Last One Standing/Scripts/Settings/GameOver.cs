using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void CallGameOver()
    {
        //Settings Game Over
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.modeGame = ModeGame.gameOver;
        }
    }
}
