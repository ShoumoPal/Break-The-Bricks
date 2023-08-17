using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int numOfBricks;
    private bool gameOver;
    [SerializeField] private bool levelComplete;

    private void Awake()
    {
        gameOver = false;
        levelComplete = false;
        numOfBricks = LevelManager.Instance.GetNumberOfBricks(1);
    }
    private void Update()
    {
        if (numOfBricks == 0)
        {
            levelComplete = true;
        }

        if (gameOver)
        {
            Debug.Log("GameOver");
        }
        if (levelComplete)
        {
            Debug.Log("LevelComplete!");
        }
    }
    public void GameOver()
    {
        gameOver = true;
    }
    public void LevelComplete() 
    { 
        levelComplete = true; 
    }
    public void DecreaseBricks()
    {
        numOfBricks--;
    }
    

}
