using System;
public interface IState
{
    void Handle();
}

public class OnState : IState
{
    public void Handle()
    {
        Console.WriteLine("Lights are on");
    }
}

public class OffState : IState
{
    public void Handle()
    {
        Console.WriteLine("Lights are off");
    }
}

public class Context
{
    private IState state;

    public IState State
    {
        get { return state; }
        set { state = value; }
    }

    public Context(IState state)
    {
        this.state = state;
    }

    public void Request()
    {
        state.Handle();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Context context = new Context(new OffState());
        context.Request(); 

        context.State = new OnState();
        context.Request();
    }
}
