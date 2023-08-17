using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int numOfBricks;
    private bool gameOver;
    [SerializeField] private bool levelComplete;
    [SerializeField] GameObject brickGrid;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject levelCompleteMenu;

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
        if(brickGrid.transform.position.y < -4f)
        {
            gameOver = true;
        }  

        if (gameOver)
        {
            Debug.Log("GameOver");
            Time.timeScale = 0.0f;
            gameOverMenu.SetActive(true);

        }
        if (levelComplete)
        {
            Debug.Log("LevelComplete!");
            Time.timeScale = 0.0f;
            levelCompleteMenu.SetActive(true);
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
    public void MoveBricks()
    {
        Vector3 temp = brickGrid.transform.position;
        temp.y -= 1;
        brickGrid.transform.position = temp;
    }

}
