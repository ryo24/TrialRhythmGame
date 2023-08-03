using UnityEngine;

public class Beat3D : MonoBehaviour, IBeat
{
    public float TimeSpan { get; set; }
    public bool IsFinished { get; private set; }

    private Vector3 targetPosition;

    void Start()
    {
        this.IsFinished = false;
        targetPosition = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, TimeSpan * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            this.IsFinished = true;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked!");
        this.IsFinished = true;
    }
}
