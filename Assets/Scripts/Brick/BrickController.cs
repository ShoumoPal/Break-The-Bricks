using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion1;
    [SerializeField] private int brickNumber;
    [SerializeField] private GameObject overlay;
    [SerializeField] TextMesh text;

    [SerializeField] private LevelController levelController;

    private void Start()
    {
        text.text = brickNumber.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<BallController>() != null)
        {
            //SoundManager.Instance.PlayFX(SoundType.Brick_1_Hit);
            brickNumber--;
            text.text = brickNumber.ToString();
            overlay.SetActive(true);
            Invoke("RemoveOverlay", 0.25f);
            if (brickNumber == 0)
            {
                levelController.DecreaseBricks();
                GameObject temp = Instantiate(explosion1.gameObject, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(temp, 2.5f);
            }
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            levelController.GameOver();
        }
    }
    private void RemoveOverlay()
    {
        overlay.SetActive(false);
    }
}
