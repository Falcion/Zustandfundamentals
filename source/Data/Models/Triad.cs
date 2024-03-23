namespace Zustandf.Data.Models;

public class Triad : Triad<Object>
{
    /* Auto-implemented. */
}

public class Triad<T> : IEquatable<Triad<T>>, IEqualityComparer<Triad<T>>,
                        IData
{
    public T? Param1 { get; set; } = default;
    public T? Param2 { get; set; } = default;
    public T? Param3 { get; set; } = default;

    public object?[] Params => new object?[] { Param1, Param2, Param3 };

    public Triad() {}

    public Triad(T? param1,
                 T? param2,
                 T? param3)
    {
        Param1 = param1;
        Param2 = param2;
        Param3 = param3;
    }

    public Triad(Singleton<T> singleton1,
                 Singleton<T> singleton2,
                 Singleton<T> singleton3)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
        Param3 = singleton3.Param;
    }

    public Triad(Triad<T> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
    }

    public Triad((T, T, T) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
    }

    public Triad(Tuple<T, T, T> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
    }

    public Triad(Pair<T> pair, T param)
    {
        Param1 = pair.Param1;
        Param2 = pair.Param2;
        Param3 = param;
    }

    [Obsolete(DATA_MODELS_EVEN_EXCEPTION, true)]
    public void Swap()
    {
        throw new NotSupportedException(DATA_MODELS_EVEN_EXCEPTION);
    }

    public void Move()
    {
        (Param1, Param2, Param3) = (Param3, Param1, Param2);
    }

    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
    }

    public static implicit operator Triad<T>(
                                         (T, T, T) value)
    {
        return new Triad<T>(value);
    }

    public static implicit operator Triad<T>(
                                    Tuple<T, T, T> tuple)
    {
        return new Triad<T>(tuple);
    }

    public static bool operator ==(Triad<T>? triad1,
                                   Triad<T>? triad2)
    {
        if(ReferenceEquals(triad1,
                            triad2))
            return true;

        if(triad1 is null && triad2 is null)
            return true;
        if(triad1 is null || triad2 is null)
            return false;

        return EqualityComparer<T>.Default.Equals(triad1.Param1, triad2.Param1) &&
               EqualityComparer<T>.Default.Equals(triad1.Param2, triad2.Param2) &&
               EqualityComparer<T>.Default.Equals(triad1.Param3, triad2.Param3);
    }

    public static bool operator !=(Triad<T>? triad1,
                                   Triad<T>? triad2)
    {
        return !(triad1 == triad2);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Triad<T> another)
        {
            return this == another;
        }

        return false;
    }

    public bool Equals(Triad<T>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    public bool Equals(Triad<T>? triad1,
                       Triad<T>? triad2)
    {
        if(triad1 == null && triad2 == null)
            return true;
        if(triad1 == null || triad2 == null)
            return false;

        return triad1 == triad2;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);

            return hash;
        }
    }

    public int GetHashCode(Triad<T>? other)
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);

            return hash;
        }
    }
}

public class Triad<T1, T2> : IEquatable<Triad<T1, T2>>, IEqualityComparer<Triad<T1, T2>>,
                             IData
{
    public T1? Param1 { get; set; } = default;
    public T2? Param2 { get; set; } = default;
    public T2? Param3 { get; set; } = default;

    public object?[] Params => new object?[] { Param1, Param2, Param3 };

    public Triad() {}

    public Triad(T1? param1,
                 T2? param2,
                 T2? param3)
    {
        Param1 = param1;
        Param2 = param2;
        Param3 = param3;
    }

    public Triad(Singleton<T1> singleton1,
                 Singleton<T2> singleton2,
                 Singleton<T2> singleton3)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
        Param3 = singleton3.Param;
    }

    public Triad(Triad<T1, T2> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
    }

    public Triad((T1, T2, T2) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
    }

    public Triad(Tuple<T1, T2, T2> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
    }

    public Triad(Pair<T2> pair, T1 param)
    {
        Param1 = param;
        Param2 = pair.Param1;
        Param3 = pair.Param2;
    }

    public Triad(Pair<T1, T2> pair, T2 param)
    {
        Param1 = pair.Param1;
        Param2 = pair.Param2;
        Param3 = param;
    }

    [Obsolete(DATA_MODELS_EVEN_EXCEPTION, true)]
    public void Swap()
    {
        throw new NotSupportedException(DATA_MODELS_EVEN_EXCEPTION);
    }

    public void Move()
    {
        var tmp_convert_param1 = (T1?)Convert.ChangeType(Param2, typeof(T1));
        var tmp_convert_param3 = (T2?)Convert.ChangeType(Param1, typeof(T2));

        (Param1, Param2, Param3) = (tmp_convert_param1, Param3, tmp_convert_param3);
    }

    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
    }

    public static implicit operator Triad<T1, T2>(
                                         (T1, T2, T2) value)
    {
        return new Triad<T1, T2>(value);
    }

    public static implicit operator Triad<T1, T2>(
                                    Tuple<T1, T2, T2> tuple)
    {
        return new Triad<T1, T2>(tuple);
    }

    public static bool operator ==(Triad<T1, T2>? triad1,
                                   Triad<T1, T2>? triad2)
    {
        if(ReferenceEquals(triad1,
                           triad2))
            return true;

        if(triad1 is null && triad2 is null)
                return true;
        if(triad1 is null || triad2 is null)
            return false;

        return EqualityComparer<T1>.Default.Equals(triad1.Param1, triad2.Param1) &&
               EqualityComparer<T2>.Default.Equals(triad1.Param2, triad2.Param2) &&
               EqualityComparer<T2>.Default.Equals(triad1.Param3, triad2.Param3);
    }

    public static bool operator !=(Triad<T1, T2>? triad1,
                                   Triad<T1, T2>? triad2)
    {
        return !(triad1 == triad2);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Triad<T1, T2> another)
        {
            return this == another;
        }

        return false;
    }

    public bool Equals(Triad<T1, T2>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    public bool Equals(Triad<T1, T2>? triad1,
                       Triad<T1, T2>? triad2)
    {
        if(triad1 == null && triad2 == null)
            return true;
        if(triad1 == null || triad2 == null)
            return false;

        return triad1 == triad2;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
            return hash;
        }
    }

    public int GetHashCode(Triad<T1, T2>? other)
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
            return hash;
        }
    }
}

public class Triad<T1, T2, T3> : IEquatable<Triad<T1, T2, T3>>, IEqualityComparer<Triad<T1, T2, T3>>,
                                 IData
{
    public T1? Param1 { get; set; } = default;
    public T2? Param2 { get; set; } = default;
    public T3? Param3 { get; set; } = default;

    public object?[] Params => new object?[] { Param1, Param2, Param3 };

    public Triad() {}

    public Triad(T1? param1,
                 T2? param2,
                 T3? param3)
    {
        Param1 = param1;
        Param2 = param2;
        Param3 = param3;
    }

    public Triad(Singleton<T1> singleton1,
                 Singleton<T2> singleton2,
                 Singleton<T3> singleton3)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
        Param3 = singleton3.Param;
    }

    public Triad(Triad<T1, T2, T3> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
    }

    public Triad((T1, T2, T3) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
    }

    public Triad(Tuple<T1, T2, T3> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
    }

    [Obsolete(DATA_MODELS_EVEN_EXCEPTION, true)]
    public void Swap()
    {
        throw new NotSupportedException(DATA_MODELS_EVEN_EXCEPTION);
    }

    public void Move()
    {
        var tmp_convert_param1 = (T1?)Convert.ChangeType(Param2, typeof(T1));
        var tmp_convert_param2 = (T2?)Convert.ChangeType(Param3, typeof(T2));
        var tmp_convert_param3 = (T3?)Convert.ChangeType(Param1, typeof(T3));

        (Param1, Param2, Param3) = (tmp_convert_param1, tmp_convert_param2, tmp_convert_param3);
    }

    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
    }

    public static implicit operator Triad<T1, T2, T3>(
                                         (T1, T2, T3) value)
    {
        return new Triad<T1, T2, T3>(value);
    }

    public static implicit operator Triad<T1, T2, T3>(
                                    Tuple<T1, T2, T3> tuple)
    {
        return new Triad<T1, T2, T3>(tuple);
    }

    public static bool operator ==(Triad<T1, T2, T3>? triad1,
                                   Triad<T1, T2, T3>? triad2)
    {
        if(ReferenceEquals(triad1,
                           triad2))
            return true;

        if(triad1 is null && triad2 is null)
            return true;
        if(triad1 is null || triad2 is null)
            return false;

        return EqualityComparer<T1>.Default.Equals(triad1.Param1, triad2.Param1) &&
               EqualityComparer<T2>.Default.Equals(triad1.Param2, triad2.Param2) &&
               EqualityComparer<T3>.Default.Equals(triad1.Param3, triad2.Param3);
    }

    public static bool operator !=(Triad<T1, T2, T3>? triad1,
                                   Triad<T1, T2, T3>? triad2)
    {
        return !(triad1 == triad2);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Triad<T1, T2, T3> another)
        {
            return this == another;
        }

        return false;
    }

    public bool Equals(Triad<T1, T2, T3>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    public bool Equals(Triad<T1, T2, T3>? triad1,
                       Triad<T1, T2, T3>? triad2)
    {
        if(triad1 == null && triad2 == null)
            return true;
        if(triad1 == null || triad2 == null)
            return false;

        return triad1 == triad2;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);

            return hash;
        }
    }

    public int GetHashCode(Triad<T1, T2, T3>? other)
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);

            return hash;
        }
    }
}
