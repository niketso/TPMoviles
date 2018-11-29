

public class Timer{

    private float duration = 0.0f;
    private float accumulator = 0.0f;
    private bool running = false;

    public Timer(float duration)
    {
        this.duration = duration;
    }

    public void Start()
    {
        running = true;

    }
    public void Reset()
    {
        accumulator = 0.0f;
    }

    public bool IsRunning
    {
        get { return running; }
    }

    public bool Update(float dt)
    {
        if (running)
        {
            accumulator += dt;
        }
        if (accumulator >= duration)
        {
            running = false;
            Reset();
            return true;
        }
        return false;

    }
}
