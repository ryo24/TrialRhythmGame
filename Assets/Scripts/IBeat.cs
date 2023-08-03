public interface IBeat
{
    bool IsFinished { get; }
    float TimeSpan { get; set; }
    void Move();
}
