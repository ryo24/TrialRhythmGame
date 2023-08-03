using UnityEngine;
using TMPro;
using System.Collections;

public class CountDownView : MonoBehaviour
{
    public TextMeshProUGUI countDownText;

    public delegate void CountDownFinished();
    public event CountDownFinished CountDownFinishedEvent;

    void Start()
    {
        this.transform.parent = GameObject.Find("Canvas").transform;
        StartCoroutine(StartCountDown());
    }

    IEnumerator StartCountDown()
    {
        countDownText.text = "3";
        yield return new WaitForSeconds(1);
        countDownText.text = "2";
        yield return new WaitForSeconds(1);
        countDownText.text = "1";
        yield return new WaitForSeconds(1);

        // When countdown finished, invoke the event and destroy this game object.
        CountDownFinishedEvent?.Invoke();
        Destroy(this.gameObject);
    }
}
