using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    [SerializeField] private string[] Levels;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }

        for(int i = 1; i < Levels.Length; i++) {
            SetLevelStatus(Levels[i], LevelStatus.Locked);
        }      
    }

    private void SetLevelStatus(string level, LevelStatus status)
    {
        PlayerPrefs.SetInt(level, (int)status);
    }

    public LevelStatus GetLevelStatus(string level1)
    {
        LevelStatus status = (LevelStatus)PlayerPrefs.GetInt(level1);
        return status;
    }
    
    public void SetCurrentLevelComplete()
    {
        SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);

        SetLevelStatus(GetNameFromIndex(SceneManager.GetActiveScene().buildIndex + 1), LevelStatus.Completed);
    }

    private string GetNameFromIndex(int index)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(index);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }
}
