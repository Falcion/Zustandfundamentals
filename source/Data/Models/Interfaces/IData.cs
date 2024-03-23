namespace Zustandf.Data.Models;

public interface IData
{
    public object?[] Params { get; }

    public void Swap();

    public void Move();

    public void Nullify();
}
