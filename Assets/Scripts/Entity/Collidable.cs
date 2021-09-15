using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    public Vector2 bounds;

    protected virtual void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 1));
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            OnCollide(hits[i]);

            hits[i] = null;
        }

        ScreenPos();
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        //Debug.Log(coll.name);
    }

    protected virtual void ScreenPos()
    {
        Vector3 screenPos = transform.position;
        if (-bounds.x>transform.position.x)
            screenPos.x=bounds.x;
        if (bounds.x < transform.position.x)
            screenPos.x = -bounds.x;
        if (-bounds.y > transform.position.y)
            screenPos.y = bounds.y;
        if (bounds.y < transform.position.y)
            screenPos.y = -bounds.y;
        transform.position = screenPos;
    }
}