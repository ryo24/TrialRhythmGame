using UnityEngine;
using DG.Tweening;

public class Beat2D : MonoBehaviour, IBeat
{
    public float TimeSpan { get; set; }
    public bool IsFinished { get; private set; }

    private Vector3 startScale = new Vector3(0f, 0f, 0f);
    private Vector3 endScale = new Vector3(1.2f, 1.2f, 1.2f);

    void Start()
    {
        this.transform.localScale = startScale;
        this.IsFinished = false;
        this.transform.position = new Vector3((Random.value - 0.5f) * 5, (Random.value - 0.5f) * 5, 0);
    }

    //public void Move()
    //{
    //    float journeyTime = (float)TimeSpan.TotalSeconds;
    //    transform.DOScale(1.2f, journeyTime)
    //        .SetEase(Ease.Linear)
    //        .OnComplete(() => Destroy(gameObject));
    //}

    public void Move()
    {
        transform.DOScale(endScale, TimeSpan).OnComplete(() =>
        {
            this.IsFinished = true;
            Destroy(gameObject);
        } );
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked!");
        this.IsFinished = true;
    }
}
