namespace Zustandf.Data.Models;

public class Pair : Pair<Object>
{
    /* Auto-implemented. */
}

public class Pair<T> : IEquatable<Pair<T>>, IEqualityComparer<Pair<T>>,
                       IData
{
    public T? Param1 { get; set; } = default;
    public T? Param2 { get; set; } = default;

    public object?[] Params => new object?[] { Param1, Param2 };

    public Pair() {}

    public Pair(T? param1,
                T? param2)
    {
        Param1 = param1;
        Param2 = param2;
    }

    public Pair(Singleton<T> singleton1,
                Singleton<T> singleton2)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
    }

    public Pair(Pair<T> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
    }

    public Pair((T, T) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
    }

    public Pair(Tuple<T, T> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
    }

    public void Swap()
    {
        (Param1, Param2) = (Param2, Param1);
    }

    public void Move()
    {
        Swap();
    }

    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
    }

    public static implicit operator Pair<T>(
                                        (T, T) value)
    {
        return new Pair<T>(value);
    }

    public static implicit operator Pair<T>(
                                   Tuple<T, T> tuple)
    {
        return new Pair<T>(tuple);
    }

    public static bool operator ==(Pair<T>? pair1,
                                   Pair<T>? pair2)
    {
        if(ReferenceEquals(pair1,
                           pair2))
            return true;

        if(pair1 is null && pair2 is null)
            return true;
        if(pair1 is null || pair2 is null)
            return false;

        return EqualityComparer<T>.Default.Equals(pair1.Param1, pair2.Param1) &&
               EqualityComparer<T>.Default.Equals(pair1.Param2, pair2.Param2);
    }

    public static bool operator !=(Pair<T>? pair1,
                                   Pair<T>? pair2)
    {
        return !(pair1 == pair2);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Pair<T> another)
        {
            return this == another;
        }

        return false;
    }

    public bool Equals(Pair<T>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    public bool Equals(Pair<T>? pair1,
                       Pair<T>? pair2)
    {
        if(pair1 == null && pair2 == null)
            return true;
        if(pair1 == null || pair2 == null)
            return false;

        return pair1 == pair2;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);

            return hash;
        }
    }

    public int GetHashCode(Pair<T>? other)
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (other?.Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (other?.Param2?.GetHashCode() ?? 0);

            return hash;
        }
    }
}

public class Pair<T1, T2> : IEquatable<Pair<T1, T2>>, IEqualityComparer<Pair<T1, T2>>,
                            IData
{
    public T1? Param1 { get; set; } = default;
    public T2? Param2 { get; set; } = default;

    public object?[] Params => new object?[] { Param1, Param2 };

    public Pair() {}

    public Pair(T1? param1,
                T2? param2)
    {
        Param1 = param1;
        Param2 = param2;
    }

    public Pair(Singleton<T1> singleton1,
                Singleton<T2> singleton2)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
    }

    public Pair(Pair<T1, T2> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
    }

    public Pair((T1, T2) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
    }

    public Pair(Tuple<T1, T2> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
    }

    public void Swap()
    {
        var tmp_convert_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
        var tmp_convert_param2 = (T1?)Convert.ChangeType(Param2, typeof(T1));

        (Param1, Param2) = (tmp_convert_param2, tmp_convert_param1);
    }

    public void Move()
    {
        Swap();
    }

    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
    }

    public static implicit operator Pair<T1, T2>(
                                        (T1, T2) value)
    {
        return new Pair<T1, T2>(value);
    }

    public static implicit operator Pair<T1, T2>(
                                   Tuple<T1, T2> tuple)
    {
        return new Pair<T1, T2>(tuple);
    }

    public static bool operator ==(Pair<T1, T2>? pair1,
                                   Pair<T1, T2>? pair2)
    {
        if(ReferenceEquals(pair1,
                           pair2))
            return true;

        if(pair1 is null && pair2 is null)
            return true;
        if(pair1 is null || pair2 is null)
            return false;

        return EqualityComparer<T1>.Default.Equals(pair1.Param1, pair2.Param1) &&
               EqualityComparer<T2>.Default.Equals(pair1.Param2, pair2.Param2);
    }

    public static bool operator !=(Pair<T1, T2>? pair1,
                                   Pair<T1, T2>? pair2)
    {
        return !(pair1 == pair2);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Pair<T1, T2> another)
        {
            return this == another;
        }

        return false;
    }

    public bool Equals(Pair<T1, T2> other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    public bool Equals(Pair<T1, T2>? pair1,
                       Pair<T1, T2>? pair2)
    {
        if(pair1 == null && pair2 == null)
            return true;
        if(pair1 == null || pair2 == null)
            return false;

        return pair1 == pair2;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);

            return hash;
        }
    }

    public int GetHashCode(Pair<T1, T2>? other)
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (other?.Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (other?.Param2?.GetHashCode() ?? 0);

            return hash;
        }
    }
}
