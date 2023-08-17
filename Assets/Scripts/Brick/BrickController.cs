using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion1;
    [SerializeField] private ParticleSystem explosion2;
    [SerializeField] private int brickNumber;
    [SerializeField] private GameObject overlay;
    [SerializeField] TextMesh text;
    [SerializeField] BrickType type;
    [SerializeField] private LevelController levelController;

    [SerializeField] private float amp;

    private Vector3 initialPos;

    private void Start()
    {
        text.text = brickNumber.ToString();
        initialPos = transform.position;
    }
    private void FixedUpdate()
    {
        if(type == BrickType.Moving)
        {
            transform.position = new Vector3(initialPos.x, Mathf.Sin(Time.time) * amp + initialPos.y, initialPos.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<BallController>() != null)
        {
            SoundManager.Instance.PlayFX(SoundType.Brick_1_Hit);
            brickNumber--;
            text.text = brickNumber.ToString();
            overlay.SetActive(true);
            Invoke("RemoveOverlay", 0.25f);
            if (brickNumber == 0)
            {
                GameObject temp = null;
                levelController.DecreaseBricks();
                if(type == BrickType.Stationary)
                {
                    temp = Instantiate(explosion1.gameObject, transform.position, Quaternion.identity);
                }
                else if(type == BrickType.Moving)
                {
                    temp = Instantiate(explosion2.gameObject, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
                Destroy(temp, 2.5f);
            }
        }
    }
    private void RemoveOverlay()
    {
        overlay.SetActive(false);
    }

    public enum BrickType
    {
        Stationary,
        Moving
    }
}
