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
/// A non-generic dynamic representation of <see cref="Pair{T}"/> which holds <see cref="object"/> as it's primary type
/// </summary>
public sealed class Pair : Pair<object> { }

/// <summary>
/// A class which represents a non-static container for pair of values
/// </summary>
/// <typeparam name="T">
/// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
/// </typeparam>
public class Pair<T> : Pair<T, T> { }

/// <summary>
/// A class which represents a non-static container for pair of values
/// </summary>
/// <typeparam name="T1">
/// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
/// </typeparam>
/// <typeparam name="T2">
/// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
/// </typeparam>
public class Pair<T1, T2> : IEquatable<Pair<T1, T2>>, IEqualityComparer<Pair<T1, T2>>,
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
    /// <inheritdoc cref="IData.Params()"/>
    /// </summary>
    public object?[] Params => new object?[] { Param1, Param2 };

    /// <summary>
    /// Instance init of the class constructor
    /// </summary>
    public Pair() {}

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="param1">
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param2">
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
    public Pair(T1? param1,
                T2? param2)
    {
        Param1 = param1;
        Param2 = param2;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="singleton1">
    /// An instance of <see cref="Singleton{T1}"/> which represents other one instance of <see cref="Singleton{T1}"/>
    /// </param>
    /// <param name="singleton2">
    /// An instance of <see cref="Singleton{T2}"/> which represents other one instance of <see cref="Singleton{T2}"/>
    /// </param>
    public Pair(Singleton<T1> singleton1,
                Singleton<T2> singleton2)
    {
        Param1 = singleton1.Param;
        Param2 = singleton2.Param;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Pair{T}"/> which from current one will be constructed
    /// </param>
    public Pair(Pair<T1, T2> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2}"/> which represents static tuple with two value
    /// </param>
    public Pair((T1, T2) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2}"/> which represents static tuple with two value
    /// </param>
    public Pair(Tuple<T1, T2> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
    }

    /// <summary>
    /// <inheritdoc cref="IData.Swap()"/>
    /// </summary>
    public void Swap()
    {
        var tmp_convert_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
        var tmp_convert_param2 = (T1?)Convert.ChangeType(Param2, typeof(T1));

        (Param1, Param2) = (tmp_convert_param2, tmp_convert_param1);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Move()"/>
    /// </summary>
    public void Move()
    {
        Swap();
    }

    /// <summary>
    /// <inheritdoc cref="IData.Nullify()"/>
    /// </summary>
    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
    }

    /// <summary>
    /// Operator for <see cref="Pair{T1, T2}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2}"/> which represents static tuple with two value
    /// </param>
    public static implicit operator Pair<T1, T2>(
                                        (T1, T2) value)
    {
        return new Pair<T1, T2>(value);
    }

    /// <summary>
    /// Operator for <see cref="Pair{T1, T2}"/> instance
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2}"/> which represents static tuple with two value
    /// </param>
    public static implicit operator Pair<T1, T2>(
                                   Tuple<T1, T2> tuple)
    {
        return new Pair<T1, T2>(tuple);
    }

    /// <summary>
    /// Operator for <see cref="Pair{T1, T2}"/> for EQUALS operand
    /// </summary>
    /// <param name="pair1">
    /// An instance of <see cref="Pair{T1, T2}"/> which represents other one instance of <see cref="Pair{T1, T2}"/>
    /// </param>
    /// <param name="pair2">
    /// An instance of <see cref="Pair{T1, T2}"/> which represents other one instance of <see cref="Pair{T1, T2}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
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

    /// <summary>
    /// Operator for <see cref="Pair{T1, T2}"/> for NOT EQUALS operand
    /// </summary>
    /// <param name="pair1">
    /// An instance of <see cref="Pair{T1, T2}"/> which represents other one instance of <see cref="Pair{T1, T2}"/>
    /// </param>
    /// <param name="pair2">
    /// An instance of <see cref="Pair{T1, T2}"/> which represents other one instance of <see cref="Pair{T1, T2}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are not equal
    /// </returns>
    public static bool operator !=(Pair<T1, T2>? pair1,
                                   Pair<T1, T2>? pair2)
    {
        return !(pair1 == pair2);
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
        if(obj is Pair<T1, T2> another)
        {
            return this == another;
        }

        return false;
    }

    /// <summary>
    /// Function which checks on equality of current instance and given instance of <see cref="Pair{T1, T2}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Pair{T1, T2}"/> which represents other one instance of <see cref="Pair{T1, T2}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether current instance and given one are equal
    /// </returns>
    public bool Equals(Pair<T1, T2>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    /// <summary>
    /// Function which checks on equality two different instances of <see cref="Pair{T1, T2}"/>
    /// </summary>
    /// <param name="pair1">
    /// An instance of <see cref="Pair{T1, T2}"/> which represents other one instance of <see cref="Pair{T1, T2}"/>
    /// </param>
    /// <param name="pair2">
    /// An instance of <see cref="Pair{T1, T2}"/> which represents other one instance of <see cref="Pair{T1, T2}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
    public bool Equals(Pair<T1, T2>? pair1,
                       Pair<T1, T2>? pair2)
    {
        if(pair1 == null && pair2 == null)
            return true;
        if(pair1 == null || pair2 == null)
            return false;

        return pair1 == pair2;
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

            return hash;
        }
    }

    /// <summary>
    /// Function which calcs hash code of current instance
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Pair{T1, T2}"/> which represents other one instance of <see cref="Pair{T1, T2}"/>
    /// </param>
    /// <returns>
    /// A signed 32-bit integer value which represents hash code of current instance
    /// </returns>
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
