/*
 * MIT License
 *
 * Copyright (c) 2023-2024 Falcion
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 * - https://choosealicense.com/licenses/mit
 * - https://spdx.org/licenses/MIT
 */

namespace Zustandf.Data.Models;

/// <summary>
/// A non-generic dynamic representation of <see cref="Triad{T}"/> which holds <see cref="object"/> as it's primary type
/// </summary>
public sealed class Triad : Triad<object> { }

/// <summary>
/// A class which represents a non-static container for three values
/// </summary>
/// <typeparam name="T">
/// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
/// </typeparam>
public class Triad<T> : IEquatable<Triad<T>>, IEqualityComparer<Triad<T>>,
                        IData
{
    /// <summary>
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </summary>
    public T? Param1 { get; set; } = default;
    /// <summary>
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </summary>
    public T? Param2 { get; set; } = default;
    /// <summary>
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </summary>
    public T? Param3 { get; set; } = default;

    /// <summary>
    /// <inheritdoc cref="IData.Params"/>
    /// </summary>
    public object?[] Params => new object?[] { Param1, Param2, Param3 };

    /// <summary>
    /// Instance init of the class constructor
    /// </summary>
    public Triad() {}

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="param1">
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param2">
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param3">
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </param>
    public Triad(T? param1,
                 T? param2,
                 T? param3)
    {
        Param1 = param1;
        Param2 = param2;
        Param3 = param3;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="singleton1">
    /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="singleton2">
    /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="singleton3">
    /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </param>
    public Triad(Singleton<T> singleton1,
                 Singleton<T> singleton2,
                 Singleton<T> singleton3)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
        Param3 = singleton3.Param;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="pair">
    /// An instance of <see cref="Pair{T}"/> which contains generic type <typeparamref name="T"/> values representing three of parameters in the data type
    /// </param>
    /// <param name="param">
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </param>
    public Triad(Pair<T> pair, T param)
    {
        Param1 = pair.Param1;
        Param2 = pair.Param2;
        Param3 = param;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Triad{T}"/> which from current one will be constructed
    /// </param>
    public Triad(Triad<T> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3}"/> which represents static tuple with four value
    /// </param>
    public Triad((T, T, T) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3}"/> which represents static tuple with four value
    /// </param>
    public Triad(Tuple<T, T, T> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
    }

    /// <summary>
    /// <inheritdoc cref="IData.Swap()"/>
    /// </summary>
    /// <exception cref="NotSupportedException">
    /// Thrown whenever this method is called
    /// </exception>
    [Obsolete(EXCEPTION_MESSAGE_DATA_EVEN, true)]
    public void Swap()
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_DATA_EVEN);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Move()"/>
    /// </summary>
    public void Move()
    {
        (Param1, Param2, Param3) = (Param3, Param1, Param2);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Nullify()"/>
    /// </summary>
    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
    }

    /// <summary>
    /// Operator for <see cref="Triad{T}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Triad<T>(
                                         (T, T, T) value)
    {
        return new Triad<T>(value);
    }

    /// <summary>
    /// Operator for <see cref="Triad{T}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Triad<T>(
                                    Tuple<T, T, T> value)
    {
        return new Triad<T>(value);
    }

    /// <summary>
    /// Operator for <see cref="Triad{T}"/> for EQUALS operand
    /// </summary>
    /// <param name="triad1">
    /// An instance of <see cref="Triad{T}"/> which represents other one instance of <see cref="Triad{T}"/>
    /// </param>
    /// <param name="triad2">
    /// An instance of <see cref="Triad{T}"/> which represents other one instance of <see cref="Triad{T}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
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

    /// <summary>
    /// Operator for <see cref="Triad{T}"/> for NOT EQUALS operand
    /// </summary>
    /// <param name="triad1">
    /// An instance of <see cref="Triad{T}"/> which represents other one instance of <see cref="Triad{T}"/>
    /// </param>
    /// <param name="triad2">
    /// An instance of <see cref="Triad{T}"/> which represents other one instance of <see cref="Triad{T}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are not equal
    /// </returns>
    public static bool operator !=(Triad<T>? triad1,
                                   Triad<T>? triad2)
    {
        return !(triad1 == triad2);
    }

    /// <summary>
    /// Function override which checks on equality of current instance and given object
    /// </summary>
    /// <param name="obj">
    /// An object which representes any other instance
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether current instance and given object are equal
    /// </returns>
    public override bool Equals(object? obj)
    {
        if(obj is Triad<T> another)
        {
            return this == another;
        }

        return false;
    }

    /// <summary>
    /// Function which checks on equality of current instance and given instance of <see cref="Triad{T}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Triad{T}"/> which represents other one instance of <see cref="Triad{T}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether current instance and given one are equal
    /// </returns>
    public bool Equals(Triad<T>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    /// <summary>
    /// Function which checks on equality two different instances of <see cref="Triad{T}"/>
    /// </summary>
    /// <param name="triad1">
    /// An instance of <see cref="Triad{T}"/> which represents other one instance of <see cref="Triad{T}"/>
    /// </param>
    /// <param name="triad2">
    /// An instance of <see cref="Triad{T}"/> which represents other one instance of <see cref="Triad{T}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
    public bool Equals(Triad<T>? triad1,
                       Triad<T>? triad2)
    {
        if(triad1 == null && triad2 == null)
            return true;
        if(triad1 == null || triad2 == null)
            return false;

        return triad1 == triad2;
    }

    /// <summary>
    /// Function override which calcs hash code of current instance
    /// </summary>
    /// <returns>
    /// A signed 32-bit integer value which represents hash code of current instance
    /// </returns>
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

    /// <summary>
    /// Function which calcs hash code of given instance of <see cref="Triad{T}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Triad{T}"/> which represents other one instance of <see cref="Triad{T}"/>
    /// </param>
    /// <returns>
    /// A signed 32-bit integer value which represents hash code of given instance of <see cref="Triad{T}"/>
    /// </returns>
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

/// <summary>
/// A class which represents a non-static container for three values
/// </summary>
/// <typeparam name="T1">
/// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
/// </typeparam>
/// <typeparam name="T2">
/// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
/// </typeparam>
public class Triad<T1, T2> : IEquatable<Triad<T1, T2>>, IEqualityComparer<Triad<T1, T2>>,
                             IData
{
    /// <summary>
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </summary>
    public T1? Param1 { get; set; } = default;
    /// <summary>
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </summary>
    public T2? Param2 { get; set; } = default;
    /// <summary>
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </summary>
    public T2? Param3 { get; set; } = default;

    /// <summary>
    /// <inheritdoc cref="IData.Params"/>
    /// </summary>
    public object?[] Params => new object?[] { Param1, Param2, Param3 };

    /// <summary>
    /// Instance init of the class constructor
    /// </summary>
    public Triad() {}

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="param1">
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param2">
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param3">
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
    public Triad(T1? param1,
                 T2? param2,
                 T2? param3)
    {
        Param1 = param1;
        Param2 = param2;
        Param3 = param3;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="singleton1">
    /// An instance of <see cref="Singleton{T1}"/> which contains generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="singleton2">
    /// An instance of <see cref="Singleton{T2}"/> which contains generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="singleton3">
    /// An instance of <see cref="Singleton{T2}"/> which contains generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
    public Triad(Singleton<T1> singleton1,
                 Singleton<T2> singleton2,
                 Singleton<T2> singleton3)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
        Param3 = singleton3.Param;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="pair">
    /// An instance of <see cref="Pair{T1, T2}"/> which contains generic type <typeparamref name="T1"/> and <typeparamref name="T2"/> values representing three of parameters in the data type
    /// </param>
    /// <param name="param">
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
    public Triad(Pair<T1, T2> pair, T2 param)
    {
        Param1 = pair.Param1;
        Param2 = pair.Param2;
        Param3 = param;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Triad{T1, T2}"/> which from current one will be constructed
    /// </param>
    public Triad(Triad<T1, T2> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3}"/> which represents static tuple with four value
    /// </param>
    public Triad((T1, T2, T2) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3}"/> which represents static tuple with four value
    /// </param>
    public Triad(Tuple<T1, T2, T2> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
    }

    /// <summary>
    /// <inheritdoc cref="IData.Swap()"/>
    /// </summary>
    /// <exception cref="NotSupportedException">
    /// Thrown whenever this method is called
    /// </exception>
    [Obsolete(EXCEPTION_MESSAGE_DATA_EVEN, true)]
    public void Swap()
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_DATA_EVEN);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Move()"/>
    /// </summary>
    public void Move()
    {
        var tmp_convert_param1 = (T1?)Convert.ChangeType(Param2, typeof(T1));
        var tmp_convert_param3 = (T2?)Convert.ChangeType(Param1, typeof(T2));

        (Param1, Param2, Param3) = (tmp_convert_param1, Param3, tmp_convert_param3);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Nullify()"/>
    /// </summary>
    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
    }

    /// <summary>
    /// Operator for <see cref="Triad{T1, T2}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Triad<T1, T2>(
                                         (T1, T2, T2) value)
    {
        return new Triad<T1, T2>(value);
    }

    /// <summary>
    /// Operator for <see cref="Triad{T1, T2}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Triad<T1, T2>(
                                    Tuple<T1, T2, T2> value)
    {
        return new Triad<T1, T2>(value);
    }

    /// <summary>
    /// Operator for <see cref="Triad{T1, T2}"/> for EQUALS operand
    /// </summary>
    /// <param name="triad1">
    /// An instance of <see cref="Triad{T1, T2}"/> which represents other one instance of <see cref="Triad{T1, T2}"/>
    /// </param>
    /// <param name="triad2">
    /// An instance of <see cref="Triad{T1, T2}"/> which represents other one instance of <see cref="Triad{T1, T2}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
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

    /// <summary>
    /// Operator for <see cref="Triad{T1, T2}"/> for NOT EQUALS operand
    /// </summary>
    /// <param name="triad1">
    /// An instance of <see cref="Triad{T1, T2}"/> which represents other one instance of <see cref="Triad{T1, T2}"/>
    /// </param>
    /// <param name="triad2">
    /// An instance of <see cref="Triad{T1, T2}"/> which represents other one instance of <see cref="Triad{T1, T2}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are not equal
    /// </returns>
    public static bool operator !=(Triad<T1, T2>? triad1,
                                   Triad<T1, T2>? triad2)
    {
        return !(triad1 == triad2);
    }

    /// <summary>
    /// Function override which checks on equality of current instance and given object
    /// </summary>
    /// <param name="obj">
    /// An object which representes any other instance
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether current instance and given object are equal
    /// </returns>
    public override bool Equals(object? obj)
    {
        if(obj is Triad<T1, T2> another)
        {
            return this == another;
        }

        return false;
    }

    /// <summary>
    /// Function which checks on equality of current instance and given instance of <see cref="Triad{T1, T2}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Triad{T1, T2}"/> which represents other one instance of <see cref="Triad{T1, T2}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether current instance and given one are equal
    /// </returns>
    public bool Equals(Triad<T1, T2>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    /// <summary>
    /// Function which checks on equality two different instances of <see cref="Triad{T1, T2}"/>
    /// </summary>
    /// <param name="triad1">
    /// An instance of <see cref="Triad{T1, T2}"/> which represents other one instance of <see cref="Triad{T1, T2}"/>
    /// </param>
    /// <param name="triad2">
    /// An instance of <see cref="Triad{T1, T2}"/> which represents other one instance of <see cref="Triad{T1, T2}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
    public bool Equals(Triad<T1, T2>? triad1,
                       Triad<T1, T2>? triad2)
    {
        if(triad1 == null && triad2 == null)
            return true;
        if(triad1 == null || triad2 == null)
            return false;

        return triad1 == triad2;
    }

    /// <summary>
    /// Function override which calcs hash code of current instance
    /// </summary>
    /// <returns>
    /// A signed 32-bit integer value which represents hash code of current instance
    /// </returns>
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

    /// <summary>
    /// Function which calcs hash code of given instance of <see cref="Triad{T1, T2}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Triad{T1, T2}"/> which represents other one instance of <see cref="Triad{T1, T2}"/>
    /// </param>
    /// <returns>
    /// A signed 32-bit integer value which represents hash code of given instance of <see cref="Triad{T1, T2}"/>
    /// </returns>
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

/// <summary>
/// A class which represents a non-static container for three values
/// </summary>
/// <typeparam name="T1">
/// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
/// </typeparam>
/// <typeparam name="T2">
/// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
/// </typeparam>
/// <typeparam name="T3">
/// A generic type <typeparamref name="T3"/> value representing one of parameters in the data type
/// </typeparam>
public class Triad<T1, T2, T3> : IEquatable<Triad<T1, T2, T3>>, IEqualityComparer<Triad<T1, T2, T3>>,
                                 IData
{
    /// <summary>
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </summary>
    public T1? Param1 { get; set; } = default;
    /// <summary>
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </summary>
    public T2? Param2 { get; set; } = default;
    /// <summary>
    /// A generic type <typeparamref name="T3"/> value representing one of parameters in the data type
    /// </summary>
    public T3? Param3 { get; set; } = default;

    /// <summary>
    /// <inheritdoc cref="IData.Params"/>
    /// </summary>
    public object?[] Params => new object?[] { Param1, Param2, Param3 };

    /// <summary>
    /// Instance init of the class constructor
    /// </summary>
    public Triad() {}

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="param1">
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param2">
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param3">
    /// A generic type <typeparamref name="T3"/> value representing one of parameters in the data type
    /// </param>
    public Triad(T1? param1,
                 T2? param2,
                 T3? param3)
    {
        Param1 = param1;
        Param2 = param2;
        Param3 = param3;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="singleton1">
    /// An instance of <see cref="Singleton{T1}"/> which contains generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="singleton2">
    /// An instance of <see cref="Singleton{T2}"/> which contains generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="singleton3">
    /// An instance of <see cref="Singleton{T3}"/> which contains generic type <typeparamref name="T3"/> value representing one of parameters in the data type
    /// </param>
    public Triad(Singleton<T1> singleton1,
                 Singleton<T2> singleton2,
                 Singleton<T3> singleton3)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
        Param3 = singleton3.Param;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="pair">
    /// An instance of <see cref="Pair{T1, T2}"/> which contains generic type <typeparamref name="T1"/> and <typeparamref name="T2"/> values representing three of parameters in the data type
    /// </param>
    /// <param name="param">
    /// A generic type <typeparamref name="T3"/> value representing one of parameters in the data type
    /// </param>
    public Triad(Pair<T1, T2> pair, T3? param)
    {
        Param1 = pair.Param1;
        Param2 = pair.Param2;
        Param3 = param;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Triad{T1, T2, T3}"/> which from current one will be constructed
    /// </param>
    public Triad(Triad<T1, T2, T3> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3}"/> which represents static tuple with four value
    /// </param>
    public Triad((T1, T2, T3) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3}"/> which represents static tuple with four value
    /// </param>
    public Triad(Tuple<T1, T2, T3> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
    }

    /// <summary>
    /// <inheritdoc cref="IData.Swap()"/>
    /// </summary>
    /// <exception cref="NotSupportedException">
    /// Thrown whenever this method is called
    /// </exception>
    [Obsolete(EXCEPTION_MESSAGE_DATA_EVEN, true)]
    public void Swap()
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_DATA_EVEN);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Move()"/>
    /// </summary>
    public void Move()
    {
        var tmp_convert_param1 = (T1?)Convert.ChangeType(Param2, typeof(T1));
        var tmp_convert_param2 = (T2?)Convert.ChangeType(Param3, typeof(T2));
        var tmp_convert_param3 = (T3?)Convert.ChangeType(Param1, typeof(T3));

        (Param1, Param2, Param3) = (tmp_convert_param1, tmp_convert_param2, tmp_convert_param3);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Nullify()"/>
    /// </summary>
    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
    }

    /// <summary>
    /// Operator for <see cref="Triad{T1, T2, T3}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Triad<T1, T2, T3>(
                                         (T1, T2, T3) value)
    {
        return new Triad<T1, T2, T3>(value);
    }

    /// <summary>
    /// Operator for <see cref="Triad{T1, T2, T3}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Triad<T1, T2, T3>(
                                    Tuple<T1, T2, T3> value)
    {
        return new Triad<T1, T2, T3>(value);
    }

    /// <summary>
    /// Operator for <see cref="Triad{T1, T2, T3}"/> for EQUALS operand
    /// </summary>
    /// <param name="triad1">
    /// An instance of <see cref="Triad{T1, T2, T3}"/> which represents other one instance of <see cref="Triad{T1, T2, T3}"/>
    /// </param>
    /// <param name="triad2">
    /// An instance of <see cref="Triad{T1, T2, T3}"/> which represents other one instance of <see cref="Triad{T1, T2, T3}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
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

    /// <summary>
    /// Operator for <see cref="Triad{T1, T2, T3}"/> for NOT EQUALS operand
    /// </summary>
    /// <param name="triad1">
    /// An instance of <see cref="Triad{T1, T2, T3}"/> which represents other one instance of <see cref="Triad{T1, T2, T3}"/>
    /// </param>
    /// <param name="triad2">
    /// An instance of <see cref="Triad{T1, T2, T3}"/> which represents other one instance of <see cref="Triad{T1, T2, T3}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are not equal
    /// </returns>
    public static bool operator !=(Triad<T1, T2, T3>? triad1,
                                   Triad<T1, T2, T3>? triad2)
    {
        return !(triad1 == triad2);
    }

    /// <summary>
    /// Function override which checks on equality of current instance and given object
    /// </summary>
    /// <param name="obj">
    /// An object which representes any other instance
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether current instance and given object are equal
    /// </returns>
    public override bool Equals(object? obj)
    {
        if(obj is Triad<T1, T2, T3> another)
        {
            return this == another;
        }

        return false;
    }

    /// <summary>
    /// Function which checks on equality of current instance and given instance of <see cref="Triad{T1, T2, T3}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Triad{T1, T2, T3}"/> which represents other one instance of <see cref="Triad{T1, T2, T3}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether current instance and given one are equal
    /// </returns>
    public bool Equals(Triad<T1, T2, T3>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    /// <summary>
    /// Function which checks on equality two different instances of <see cref="Triad{T1, T2, T3}"/>
    /// </summary>
    /// <param name="triad1">
    /// An instance of <see cref="Triad{T1, T2, T3}"/> which represents other one instance of <see cref="Triad{T1, T2, T3}"/>
    /// </param>
    /// <param name="triad2">
    /// An instance of <see cref="Triad{T1, T2, T3}"/> which represents other one instance of <see cref="Triad{T1, T2, T3}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
    public bool Equals(Triad<T1, T2, T3>? triad1,
                       Triad<T1, T2, T3>? triad2)
    {
        if(triad1 == null && triad2 == null)
            return true;
        if(triad1 == null || triad2 == null)
            return false;

        return triad1 == triad2;
    }

    /// <summary>
    /// Function override which calcs hash code of current instance
    /// </summary>
    /// <returns>
    /// A signed 32-bit integer value which represents hash code of current instance
    /// </returns>
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

    /// <summary>
    /// Function which calcs hash code of given instance of <see cref="Triad{T1, T2, T3}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Triad{T1, T2, T3}"/> which represents other one instance of <see cref="Triad{T1, T2, T3}"/>
    /// </param>
    /// <returns>
    /// A signed 32-bit integer value which represents hash code of given instance of <see cref="Triad{T1, T2}"/>
    /// </returns>
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
