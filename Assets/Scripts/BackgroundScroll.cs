using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float startY;
    public float scrollSpeed;
    public float endY;
    
    void Update()
    {
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);
        if(transform.position.y <= endY)
        {
            transform.position = new Vector3(transform.position.x, startY, 2);
        }

    }
}
