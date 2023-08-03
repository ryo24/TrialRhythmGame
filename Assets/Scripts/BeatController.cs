using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatController : MonoBehaviour
{
    public GameObject BeatPrefab;
    public Transform ParentTransform;

    private IBeat[] beats;
    private int beatIndex = 0;
    private bool shouldStartBeats = false;

    public static BeatController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize beats array with dummy data
        beats = new IBeat[20];
        for (int i = 0; i < beats.Length; i++)
        {
            var beatObj = Instantiate(BeatPrefab, ParentTransform);
            var beat = beatObj.GetComponent<IBeat>();
            beat.TimeSpan = 3.0f * (i + 1);  // 3 second intervals
            beats[i] = beat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldStartBeats && beatIndex < beats.Length)
        {
            IBeat currentBeat = beats[beatIndex];
            if (!currentBeat.IsFinished)
            {
                currentBeat.Move();
            }
            else
            {
                beatIndex++;
            }
        }
    }

    public void StartBeats()
    {
        shouldStartBeats = true;
        Debug.Log("beatstart");
    }
}


/*
public class BeatController : MonoBehaviour
{
    public GameObject BeatPrefab;
    public Transform BeatParent; // to organize beats in Unity's hierarchy
    public float IntervalSeconds = 3f;
    public int TotalBeats = 20; // for 60 seconds

    private List<Beat> activeBeats = new List<Beat>();
    private float timer;

    void Start()
    {
        timer = IntervalSeconds;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f && activeBeats.Count < TotalBeats)
        {
            CreateBeat();
            timer = IntervalSeconds;
        }

        // remove finished beats
        activeBeats.RemoveAll(beat => beat.IsFinished);
    }

    void CreateBeat()
    {
        GameObject beatObject = Instantiate(BeatPrefab, BeatParent);
        Beat beat = beatObject.GetComponent<Beat>();
        activeBeats.Add(beat);
    }
}
*/