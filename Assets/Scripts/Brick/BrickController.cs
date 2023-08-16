using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private int brickNumber;
    [SerializeField] private GameObject overlay;
    [SerializeField] TextMesh text;
    private void Start()
    {
        text.text = brickNumber.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        brickNumber--;
        text.text = brickNumber.ToString();
        overlay.SetActive(true);
        Invoke("RemoveOverlay", 0.25f);
        if(brickNumber == 0)
            Destroy(gameObject);
    }
    private void RemoveOverlay()
    {
        overlay.SetActive(false);
    }
}
