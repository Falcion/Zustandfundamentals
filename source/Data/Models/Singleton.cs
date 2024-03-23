namespace Zustandf.Data.Models;

public class Singleton : Singleton<Object>
{
    /* Auto-implemented. */
}

public class Singleton<T> : IEquatable<Singleton<T>>, IEqualityComparer<Singleton<T>>,
                            IData
{
    public T? Param { get; set; } = default;

    public object?[] Params => new object?[] { Param };

    public Singleton() {}

    public Singleton(T? param)
    {
        Param = param;
    }

    public Singleton(Tuple<T> tuple)
    {
        Param = tuple.Item1;
    }

    public Singleton(Singleton<T> other)
    {
        Param = other.Param;
    }


    [Obsolete(DATA_MODELS_EVEN_EXCEPTION, true)]
    public void Swap()
    {
        throw new NotSupportedException(DATA_MODELS_EVEN_EXCEPTION);
    }

    [Obsolete(DATA_MODELS_EVEN_EXCEPTION, true)]
    public void Move()
    {
        throw new NotSupportedException(DATA_MODELS_EVEN_EXCEPTION);
    }

    public void Nullify()
    {
        Param = default;
    }

    public static implicit operator Singleton<T>(
                                              T value)
    {
        return new Singleton<T>(value);
    }

    public static implicit operator Singleton<T>(
                                        Tuple<T> tuple)
    {
        return new Singleton<T>(tuple.Item1);
    }

    public static bool operator ==(Singleton<T>? singleton1,
                                   Singleton<T>? singleton2)
    {
        if(ReferenceEquals(singleton1,
                           singleton2))
            return true;

        if(singleton1 is null && singleton2 is null)
            return true;
        if(singleton1 is null || singleton2 is null)
            return false;

        return EqualityComparer<T>.Default.Equals(singleton1.Param,
                                                  singleton2.Param);
    }

    public static bool operator !=(Singleton<T>? singleton1,
                                   Singleton<T>? singleton2)
    {
        return !(singleton1 == singleton2);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Singleton<T> another)
        {
            return this == another;
        }

        return false;
    }

    public bool Equals(Singleton<T>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    public bool Equals(Singleton<T>? singleton1,
                       Singleton<T>? singleton2)
    {
        if(singleton1 == null && singleton2 == null)
            return true;
        if(singleton1 == null || singleton2 == null)
            return false;

        return singleton1 == singleton2;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param?.GetHashCode() ?? 0);

            return hash;
        }
    }

    public int GetHashCode(Singleton<T>? other)
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (other?.Param?.GetHashCode() ?? 0);

            return hash;
        }
    }
}
