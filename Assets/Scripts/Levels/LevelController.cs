using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int numOfBricks;
    private bool gameOver;
    [SerializeField] private bool levelComplete;
    [SerializeField] GameObject brickGrid;

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
    public void MoveBricks()
    {
        Vector3 temp = brickGrid.transform.position;
        temp.y -= 1;
        brickGrid.transform.position = temp;
    }

}
