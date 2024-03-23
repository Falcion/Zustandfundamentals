namespace Zustandf.Data.Models;

public class Quadra : Quadra<Object>
{
    /* Auto-implemented. */
}

public class Quadra<T> : IEquatable<Quadra<T>>, IEqualityComparer<Quadra<T>>,
                         IData
{
    public T? Param1 { get; set; } = default;
    public T? Param2 { get; set; } = default;
    public T? Param3 { get; set; } = default;
    public T? Param4 { get; set; } = default;

    public object?[] Params => new object?[] { Param1, Param2, Param3, Param4 };

    public Quadra() {}

    public Quadra(T? param1,
                  T? param2,
                  T? param3,
                  T? param4)
    {
        Param1 = param1;
        Param2 = param2;
        Param3 = param3;
        Param4 = param4;
    }

    public Quadra(Singleton<T> singleton1,
                  Singleton<T> singleton2,
                  Singleton<T> singleton3,
                  Singleton<T> singleton4)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
        Param3 = singleton3.Param;
        Param4 = singleton4.Param;
    }

    public Quadra(Pair<T> pair1,
                  Pair<T> pair2)
    {
        Param1 = pair1.Param1;
        Param2 = pair1.Param2;
        Param3 = pair2.Param1;
        Param4 = pair2.Param2;
    }

    public Quadra(Triad<T> triad, T? param)
    {
        Param1 = triad.Param1;
        Param2 = triad.Param2;
        Param3 = triad.Param3;
        Param4 = param;
    }

    public Quadra(Quadra<T> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
        Param4 = other.Param4;
    }

    public Quadra((T, T, T, T) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    public Quadra(Tuple<T, T, T, T> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    public void Swap()
    {
        (Param1, Param2, Param3, Param4) = (Param3, Param4, Param1, Param2);
    }

    public void Move()
    {
        (Param1, Param2, Param3, Param4) = (Param4, Param1, Param2, Param3);
    }

    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
        Param4 = default;
    }

    public static implicit operator Quadra<T>(
                                          (T, T, T, T) value)
    {
        return new Quadra<T>(value);
    }

    public static implicit operator Quadra<T>(
                                     Tuple<T, T, T, T> value)
    {
        return new Quadra<T>(value);
    }

    public static bool operator ==(Quadra<T>? quadra1,
                                   Quadra<T>? quadra2)
    {
        if(ReferenceEquals(quadra1,
                           quadra2))
            return true;

        if(quadra1 is null && quadra2 is null)
            return true;
        if(quadra1 is null || quadra2 is null)
            return false;

        return EqualityComparer<T>.Default.Equals(quadra1.Param1, quadra2.Param1) &&
               EqualityComparer<T>.Default.Equals(quadra1.Param2, quadra2.Param2) &&
               EqualityComparer<T>.Default.Equals(quadra1.Param3, quadra2.Param3) &&
               EqualityComparer<T>.Default.Equals(quadra1.Param4, quadra2.Param4);
    }

    public static bool operator !=(Quadra<T>? quadra1,
                                   Quadra<T>? quadra2)
    {
        return !(quadra1 == quadra2);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Quadra<T> another)
        {
            return this == another;
        }

        return false;
    }

    public bool Equals(Quadra<T>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    public bool Equals(Quadra<T>? quadra1,
                       Quadra<T>? quadra2)
    {
        if(quadra1 == null && quadra2 == null)
            return true;
        if(quadra1 == null || quadra2 == null)
            return false;

        return quadra1 == quadra2;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param4?.GetHashCode() ?? 0);

            return hash;
        }
    }

    public int GetHashCode(Quadra<T>? other)
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param4?.GetHashCode() ?? 0);

            return hash;
        }
    }
}

public class Quadra<T1, T2> : IEquatable<Quadra<T1, T2>>, IEqualityComparer<Quadra<T1, T2>>,
                              IData
{
    public T1? Param1 { get; set; } = default;
    public T1? Param2 { get; set; } = default;
    public T2? Param3 { get; set; } = default;
    public T2? Param4 { get; set; } = default;

    public object?[] Params => new object?[] { Param1, Param2, Param3, Param4 };

    public Quadra() {}

    public Quadra(T1? param1,
                  T1? param2,
                  T2? param3,
                  T2? param4)
    {
        Param1 = param1;
        Param2 = param2;
        Param3 = param3;
        Param4 = param4;
    }

    public Quadra(Singleton<T1> singleton1,
                  Singleton<T1> singleton2,
                  Singleton<T2> singleton3,
                  Singleton<T2> singleton4)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
        Param3 = singleton3.Param;
        Param4 = singleton4.Param;
    }

    public Quadra(Pair<T1> pair1,
                  Pair<T2> pair2)
    {
        Param1 = pair1.Param1;
        Param2 = pair1.Param2;
        Param3 = pair2.Param1;
        Param4 = pair2.Param2;
    }

    public Quadra(Triad<T1, T2> triad, T1? param)
    {
        Param1 = triad.Param1;
        Param2 = param;
        Param3 = triad.Param3;
        Param4 = triad.Param2;
    }

    public Quadra(Quadra<T1, T2> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
        Param4 = other.Param4;
    }

    public Quadra((T1, T1, T2, T2) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    public Quadra(Tuple<T1, T1, T2, T2> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    public void Swap()
    {
        var tmp_converted_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
        var tmp_converted_param2 = (T2?)Convert.ChangeType(Param2, typeof(T2));
        var tmp_converted_param3 = (T1?)Convert.ChangeType(Param3, typeof(T1));
        var tmp_converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));

        (Param1, Param2, Param3, Param4) = (tmp_converted_param3, tmp_converted_param4, tmp_converted_param1, tmp_converted_param2);
    }

    public void Move()
    {
        var tmp_converted_param2 = (T2?)Convert.ChangeType(Param2, typeof(T2));
        var tmp_converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));

        (Param1, Param2, Param3, Param4) = (tmp_converted_param4, Param1, tmp_converted_param2, Param3);
    }

    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
        Param4 = default;
    }

    public static implicit operator Quadra<T1, T2>(
                                          (T1, T1, T2, T2) value)
    {
        return new Quadra<T1, T2>(value);
    }

    public static implicit operator Quadra<T1, T2>(
                                     Tuple<T1, T1, T2, T2> value)
    {
        return new Quadra<T1, T2>(value);
    }

    public static bool operator ==(Quadra<T1, T2>? quadra1,
                                   Quadra<T1, T2>? quadra2)
    {
        if(ReferenceEquals(quadra1,
                           quadra2))
            return true;

        if(quadra1 is null && quadra2 is null)
            return true;
        if(quadra1 is null || quadra2 is null)
            return false;

        return EqualityComparer<T1>.Default.Equals(quadra1.Param1, quadra2.Param1) &&
               EqualityComparer<T1>.Default.Equals(quadra1.Param2, quadra2.Param2) &&
               EqualityComparer<T2>.Default.Equals(quadra1.Param3, quadra2.Param3) &&
               EqualityComparer<T2>.Default.Equals(quadra1.Param4, quadra2.Param4);
    }

    public static bool operator !=(Quadra<T1, T2>? quadra1,
                                   Quadra<T1, T2>? quadra2)
    {
        return !(quadra1 == quadra2);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Quadra<T1, T2> another)
        {
            return this == another;
        }

        return false;
    }

    public bool Equals(Quadra<T1, T2>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    public bool Equals(Quadra<T1, T2>? quadra1,
                       Quadra<T1, T2>? quadra2)
    {
        if(quadra1 == null && quadra2 == null)
            return true;
        if(quadra1 == null || quadra2 == null)
            return false;

        return quadra1 == quadra2;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param4?.GetHashCode() ?? 0);

            return hash;
        }
    }

    public int GetHashCode(Quadra<T1, T2>? other)
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param4?.GetHashCode() ?? 0);

            return hash;
        }
    }
}

public class Quadra<T1, T2, T3> : IEquatable<Quadra<T1, T2, T3>>, IEqualityComparer<Quadra<T1, T2, T3>>,
                                  IData
{
    public T1? Param1 { get; set; } = default;
    public T1? Param2 { get; set; } = default;
    public T2? Param3 { get; set; } = default;
    public T3? Param4 { get; set; } = default;

    public object?[] Params => new object?[] { Param1, Param2, Param3, Param4 };

    public Quadra() {}

    public Quadra(T1? param1,
                  T1? param2,
                  T2? param3,
                  T3? param4)
    {
        Param1 = param1;
        Param2 = param2;
        Param3 = param3;
        Param4 = param4;
    }

    public Quadra(Singleton<T1> singleton1,
                  Singleton<T1> singleton2,
                  Singleton<T2> singleton3,
                  Singleton<T3> singleton4)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
        Param3 = singleton3.Param;
        Param4 = singleton4.Param;
    }

    public Quadra(Pair<T1> pair1,
                  Pair<T2, T3> pair2)
    {
        Param1 = pair1.Param1;
        Param2 = pair1.Param2;
        Param3 = pair2.Param1;
        Param4 = pair2.Param2;
    }

    public Quadra(Triad<T1, T2, T3> triad, T1? param)
    {
        Param1 = triad.Param1;
        Param2 = param;
        Param3 = triad.Param2;
        Param4 = triad.Param3;
    }

    public Quadra(Quadra<T1, T2, T3> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
        Param4 = other.Param4;
    }

    public Quadra((T1, T1, T2, T3) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    public Quadra(Tuple<T1, T1, T2, T3> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    public void Swap()
    {
        var tmp_converted_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
        var tmp_converted_param2 = (T3?)Convert.ChangeType(Param2, typeof(T3));
        var tmp_converted_param3 = (T1?)Convert.ChangeType(Param3, typeof(T1));
        var tmp_converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));

        (Param1, Param2, Param3, Param4) = (tmp_converted_param3, tmp_converted_param4, tmp_converted_param1, tmp_converted_param2);
    }

    public void Move()
    {
        var tmp_converted_param2 = (T2?)Convert.ChangeType(Param2, typeof(T2));
        var tmp_converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));
        var tmp_converted_param3 = (T3?)Convert.ChangeType(Param3, typeof(T3));

        (Param1, Param2, Param3, Param4) = (tmp_converted_param4, Param1, tmp_converted_param2, tmp_converted_param3);
    }

    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
        Param4 = default;
    }

    public static implicit operator Quadra<T1, T2, T3>(
                                          (T1, T1, T2, T3) value)
    {
        return new Quadra<T1, T2, T3>(value);
    }

    public static implicit operator Quadra<T1, T2, T3>(
                                     Tuple<T1, T1, T2, T3> value)
    {
        return new Quadra<T1, T2, T3>(value);
    }

    public static bool operator ==(Quadra<T1, T2, T3>? quadra1,
                                   Quadra<T1, T2, T3>? quadra2)
    {
        if(ReferenceEquals(quadra1,
                           quadra2))
            return true;

        if(quadra1 is null && quadra2 is null)
            return true;
        if(quadra1 is null || quadra2 is null)
            return false;

        return EqualityComparer<T1>.Default.Equals(quadra1.Param1, quadra2.Param1) &&
               EqualityComparer<T1>.Default.Equals(quadra1.Param2, quadra2.Param2) &&
               EqualityComparer<T2>.Default.Equals(quadra1.Param3, quadra2.Param3) &&
               EqualityComparer<T3>.Default.Equals(quadra1.Param4, quadra2.Param4);
    }

    public static bool operator !=(Quadra<T1, T2, T3>? quadra1,
                                   Quadra<T1, T2, T3>? quadra2)
    {
        return !(quadra1 == quadra2);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Quadra<T1, T2, T3> another)
        {
            return this == another;
        }

        return false;
    }

    public bool Equals(Quadra<T1, T2, T3>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    public bool Equals(Quadra<T1, T2, T3>? quadra1,
                       Quadra<T1, T2, T3>? quadra2)
    {
        if(quadra1 == null && quadra2 == null)
            return true;
        if(quadra1 == null || quadra2 == null)
            return false;

        return quadra1 == quadra2;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param4?.GetHashCode() ?? 0);

            return hash;
        }
    }

    public int GetHashCode(Quadra<T1, T2, T3>? other)
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param4?.GetHashCode() ?? 0);

            return hash;
        }
    }
}

public class Quadra<T1, T2, T3, T4> : IEquatable<Quadra<T1, T2, T3, T4>>, IEqualityComparer<Quadra<T1, T2, T3, T4>>,
                                      IData
{
    public T1? Param1 { get; set; } = default;
    public T2? Param2 { get; set; } = default;
    public T3? Param3 { get; set; } = default;
    public T4? Param4 { get; set; } = default;

    public object?[] Params => new object?[] { Param1, Param2, Param3, Param4 };

    public Quadra() {}

    public Quadra(T1? param1,
                  T2? param2,
                  T3? param3,
                  T4? param4)
    {
        Param1 = param1;
        Param2 = param2;
        Param3 = param3;
        Param4 = param4;
    }

    public Quadra(Singleton<T1> singleton1,
                  Singleton<T2> singleton2,
                  Singleton<T3> singleton3,
                  Singleton<T4> singleton4)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
        Param3 = singleton3.Param;
        Param4 = singleton4.Param;
    }

    public Quadra(Pair<T1, T2> pair1,
                  Pair<T3, T4> pair2)
    {
        Param1 = pair1.Param1;
        Param2 = pair1.Param2;
        Param3 = pair2.Param1;
        Param4 = pair2.Param2;
    }

    public Quadra(Triad<T1, T2, T3> triad, T4? param)
    {
        Param1 = triad.Param1;
        Param2 = triad.Param2;
        Param3 = triad.Param3;
        Param4 = param;
    }

    public Quadra(Quadra<T1, T2, T3, T4> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
        Param4 = other.Param4;
    }

    public Quadra((T1, T2, T3, T4) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    public Quadra(Tuple<T1, T2, T3, T4> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    public void Swap()
    {
        var tmp_converted_param1 = (T3?)Convert.ChangeType(Param1, typeof(T3));
        var tmp_converted_param2 = (T4?)Convert.ChangeType(Param2, typeof(T4));
        var tmp_converted_param3 = (T1?)Convert.ChangeType(Param3, typeof(T1));
        var tmp_converted_param4 = (T2?)Convert.ChangeType(Param4, typeof(T2));

        (Param1, Param2, Param3, Param4) = (tmp_converted_param3, tmp_converted_param4, tmp_converted_param1, tmp_converted_param2);
    }

    public void Move()
    {
        var tmp_converted_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
        var tmp_converted_param2 = (T3?)Convert.ChangeType(Param2, typeof(T3));
        var tmp_converted_param3 = (T4?)Convert.ChangeType(Param3, typeof(T4));
        var tmp_converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));

        (Param1, Param2, Param3, Param4) = (tmp_converted_param4, tmp_converted_param1, tmp_converted_param2, tmp_converted_param3);
    }

    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
        Param4 = default;
    }

    public static implicit operator Quadra<T1, T2, T3, T4>(
                                          (T1, T2, T3, T4) value)
    {
        return new Quadra<T1, T2, T3, T4>(value);
    }

    public static implicit operator Quadra<T1, T2, T3, T4>(
                                     Tuple<T1, T2, T3, T4> value)
    {
        return new Quadra<T1, T2, T3, T4>(value);
    }

    public static bool operator ==(Quadra<T1, T2, T3, T4>? quadra1,
                                   Quadra<T1, T2, T3, T4>? quadra2)
    {
        if(ReferenceEquals(quadra1,
                           quadra2))
            return true;

        if(quadra1 is null && quadra2 is null)
            return true;
        if(quadra1 is null || quadra2 is null)
            return false;

        return EqualityComparer<T1>.Default.Equals(quadra1.Param1, quadra2.Param1) &&
               EqualityComparer<T2>.Default.Equals(quadra1.Param2, quadra2.Param2) &&
               EqualityComparer<T3>.Default.Equals(quadra1.Param3, quadra2.Param3) &&
               EqualityComparer<T4>.Default.Equals(quadra1.Param4, quadra2.Param4);
    }

    public static bool operator !=(Quadra<T1, T2, T3, T4>? quadra1,
                                   Quadra<T1, T2, T3, T4>? quadra2)
    {
        return !(quadra1 == quadra2);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Quadra<T1, T2, T3, T4> another)
        {
            return this == another;
        }

        return false;
    }

    public bool Equals(Quadra<T1, T2, T3, T4>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    public bool Equals(Quadra<T1, T2, T3, T4>? quadra1,
                       Quadra<T1, T2, T3, T4>? quadra2)
    {
        if(quadra1 == null && quadra2 == null)
            return true;
        if(quadra1 == null || quadra2 == null)
            return false;

        return quadra1 == quadra2;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param4?.GetHashCode() ?? 0);

            return hash;
        }
    }

    public int GetHashCode(Quadra<T1, T2, T3, T4>? other)
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
            hash = hash * 23 + (Param4?.GetHashCode() ?? 0);

            return hash;
        }
    }
}
