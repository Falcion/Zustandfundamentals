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
/// A non-generic dynamic representation of <see cref="Quadra{T}"/> which holds <see cref="object"/> as it's primary type
/// </summary>
public sealed class Quadra : Quadra<object> { }

/// <summary>
/// A class which represents a non-static container for four values
/// </summary>
/// <typeparam name="T">
/// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
/// </typeparam>
public class Quadra<T> : IEquatable<Quadra<T>>, IEqualityComparer<Quadra<T>>,
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
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </summary>
    public T? Param4 { get; set; } = default;

    /// <summary>
    /// <inheritdoc cref="IData.Params()"/>
    /// </summary>
    public object?[] Params => new object?[] { Param1, Param2, Param3, Param4 };

    /// <summary>
    /// Instance init of the class constructor
    /// </summary>
    public Quadra() {}

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
    /// <param name="param4">
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </param>
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
    /// <param name="singleton4">
    /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </param>
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

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="pair1">
    /// An instance of <see cref="Pair{T}"/> which contains generic type <typeparamref name="T"/> values representing two of parameters in the data type
    /// </param>
    /// <param name="pair2">
    /// An instance of <see cref="Pair{T}"/> which contains generic type <typeparamref name="T"/> values representing two of parameters in the data type
    /// </param>
    public Quadra(Pair<T> pair1,
                  Pair<T> pair2)
    {
        Param1 = pair1.Param1;
        Param2 = pair1.Param2;
        Param3 = pair2.Param1;
        Param4 = pair2.Param2;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="triad">
    /// An instance of <see cref="Triad{T}"/> which contains generic type <typeparamref name="T"/> values representing three of parameters in the data type
    /// </param>
    /// <param name="param">
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </param>
    public Quadra(Triad<T> triad, T? param)
    {
        Param1 = triad.Param1;
        Param2 = triad.Param2;
        Param3 = triad.Param3;
        Param4 = param;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Quadra{T}"/> from which current one will be constructed
    /// </param>
    public Quadra(Quadra<T> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
        Param4 = other.Param4;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public Quadra((T, T, T, T) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public Quadra(Tuple<T, T, T, T> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    /// <summary>
    /// <inheritdoc cref="IData.Swap()"/>
    /// </summary>
    public void Swap()
    {
        (Param1, Param2, Param3, Param4) = (Param3, Param4, Param1, Param2);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Move()"/>
    /// </summary>
    public void Move()
    {
        (Param1, Param2, Param3, Param4) = (Param4, Param1, Param2, Param3);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Nullify()"/>
    /// </summary>
    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
        Param4 = default;
    }

    /// <summary>
    /// Operator for <see cref="Quadra{T}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Quadra<T>(
                                          (T, T, T, T) value)
    {
        return new Quadra<T>(value);
    }

    /// <summary>
    /// Operator for <see cref="Quadra{T}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Quadra<T>(
                                     Tuple<T, T, T, T> value)
    {
        return new Quadra<T>(value);
    }

    /// <summary>
    /// Operator for <see cref="Quadra{T}"/> for EQUALS operand
    /// </summary>
    /// <param name="quadra1">
    /// An instance of <see cref="Quadra{T}"/> which represents other one instance of <see cref="Quadra{T}"/>
    /// </param>
    /// <param name="quadra2">
    /// An instance of <see cref="Quadra{T}"/> which represents other one instance of <see cref="Quadra{T}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
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

    /// <summary>
    /// Operator for <see cref="Quadra{T}"/> for NOT EQUALS operand
    /// </summary>
    /// <param name="quadra1">
    /// An instance of <see cref="Quadra{T}"/> which represents other one instance of <see cref="Quadra{T}"/>
    /// </param>
    /// <param name="quadra2">
    /// An instance of <see cref="Quadra{T}"/> which represents other one instance of <see cref="Quadra{T}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are not equal
    /// </returns>
    public static bool operator !=(Quadra<T>? quadra1,
                                   Quadra<T>? quadra2)
    {
        return !(quadra1 == quadra2);
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
        if(obj is Quadra<T> another)
        {
            return this == another;
        }

        return false;
    }

    /// <summary>
    /// Function which checks on equality of current instance and given instance of <see cref="Quadra{T}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Quadra{T}"/> which represents other one instance of <see cref="Quadra{T}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether current instance and given one are equal
    /// </returns>
    public bool Equals(Quadra<T>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    /// <summary>
    /// Function which checks on equality two different instances of <see cref="Quadra{T}"/>
    /// </summary>
    /// <param name="quadra1">
    /// An instance of <see cref="Quadra{T}"/> which represents other one instance of <see cref="Quadra{T}"/>
    /// </param>
    /// <param name="quadra2">
    /// An instance of <see cref="Quadra{T}"/> which represents other one instance of <see cref="Quadra{T}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
    public bool Equals(Quadra<T>? quadra1,
                       Quadra<T>? quadra2)
    {
        if(quadra1 == null && quadra2 == null)
            return true;
        if(quadra1 == null || quadra2 == null)
            return false;

        return quadra1 == quadra2;
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
            hash = hash * 23 + (Param4?.GetHashCode() ?? 0);

            return hash;
        }
    }

    /// <summary>
    /// Function which calcs hash code of given instance of <see cref="Quadra{T}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Quadra{T}"/> which represents other one instance of <see cref="Quadra{T}"/>
    /// </param>
    /// <returns>
    /// A signed 32-bit integer value which represents hash code of given instance of <see cref="Quadra{T}"/>
    /// </returns>
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

/// <summary>
/// A class which represents a non-static container for four values
/// </summary>
/// <typeparam name="T1">
/// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
/// </typeparam>
/// <typeparam name="T2">
/// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
/// </typeparam>
public class Quadra<T1, T2> : IEquatable<Quadra<T1, T2>>, IEqualityComparer<Quadra<T1, T2>>,
                              IData
{
    /// <summary>
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </summary>
    public T1? Param1 { get; set; } = default;
    /// <summary>
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </summary>
    public T1? Param2 { get; set; } = default;
    /// <summary>
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </summary>
    public T2? Param3 { get; set; } = default;
    /// <summary>
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </summary>
    public T2? Param4 { get; set; } = default;

    /// <summary>
    /// <inheritdoc cref="IData.Move()"/>
    /// </summary>
    public object?[] Params => new object?[] { Param1, Param2, Param3, Param4 };

    /// <summary>
    /// Instance init of the class constructor
    /// </summary>
    public Quadra() {}

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="param1">
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param2">
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param3">
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param4">
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
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

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="singleton1">
    /// An instance of <see cref="Singleton{T1}"/> which contains generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="singleton2">
    /// An instance of <see cref="Singleton{T1}"/> which contains generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="singleton3">
    /// An instance of <see cref="Singleton{T2}"/> which contains generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="singleton4">
    /// An instance of <see cref="Singleton{T2}"/> which contains generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
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

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="pair1">
    /// An instance of <see cref="Pair{T1}"/> which contains generic type <typeparamref name="T1"/> values representing two of parameters in the data type
    /// </param>
    /// <param name="pair2">
    /// An instance of <see cref="Pair{T2}"/> which contains generic type <typeparamref name="T2"/> values representing two of parameters in the data type
    /// </param>
    public Quadra(Pair<T1> pair1,
                  Pair<T2> pair2)
    {
        Param1 = pair1.Param1;
        Param2 = pair1.Param2;
        Param3 = pair2.Param1;
        Param4 = pair2.Param2;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="triad">
    /// An instance of <see cref="Triad{T1, T2}"/> which contains generic type <typeparamref name="T1"/> and <typeparamref name="T2"/> values representing three of parameters in the data type
    /// </param>
    /// <param name="param">
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    public Quadra(Triad<T1, T2> triad, T1? param)
    {
        Param1 = triad.Param1;
        Param2 = param;
        Param3 = triad.Param3;
        Param4 = triad.Param2;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Quadra{T1, T2}"/> from which current one will be constructed
    /// </param>
    public Quadra(Quadra<T1, T2> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
        Param4 = other.Param4;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public Quadra((T1, T1, T2, T2) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public Quadra(Tuple<T1, T1, T2, T2> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    /// <summary>
    /// <inheritdoc cref="IData.Swap()"/>
    /// </summary>
    public void Swap()
    {
        var tmp_converted_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
        var tmp_converted_param2 = (T2?)Convert.ChangeType(Param2, typeof(T2));
        var tmp_converted_param3 = (T1?)Convert.ChangeType(Param3, typeof(T1));
        var tmp_converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));

        (Param1, Param2, Param3, Param4) = (tmp_converted_param3, tmp_converted_param4, tmp_converted_param1, tmp_converted_param2);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Move()"/>
    /// </summary>
    public void Move()
    {
        var tmp_converted_param2 = (T2?)Convert.ChangeType(Param2, typeof(T2));
        var tmp_converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));

        (Param1, Param2, Param3, Param4) = (tmp_converted_param4, Param1, tmp_converted_param2, Param3);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Nullify()"/>
    /// </summary>
    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
        Param4 = default;
    }

    /// <summary>
    /// Operator for <see cref="Quadra{T1, T2}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Quadra<T1, T2>(
                                          (T1, T1, T2, T2) value)
    {
        return new Quadra<T1, T2>(value);
    }

    /// <summary>
    /// Operator for <see cref="Quadra{T1, T2}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Quadra<T1, T2>(
                                     Tuple<T1, T1, T2, T2> value)
    {
        return new Quadra<T1, T2>(value);
    }

    /// <summary>
    /// Operator for <see cref="Quadra{T1, T2}"/> for EQUALS operand
    /// </summary>
    /// <param name="quadra1">
    /// An instance of <see cref="Quadra{T1, T2}"/> which represents other one instance of <see cref="Quadra{T1, T2}"/>
    /// </param>
    /// <param name="quadra2">
    /// An instance of <see cref="Quadra{T1, T2}"/> which represents other one instance of <see cref="Quadra{T1, T2}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
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

    /// <summary>
    /// Operator for <see cref="Quadra{T1, T2}"/> for NOT EQUALS operand
    /// </summary>
    /// <param name="quadra1">
    /// An instance of <see cref="Quadra{T1, T2}"/> which represents other one instance of <see cref="Quadra{T1, T2}"/>
    /// </param>
    /// <param name="quadra2">
    /// An instance of <see cref="Quadra{T1, T2}"/> which represents other one instance of <see cref="Quadra{T1, T2}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are not equal
    /// </returns>
    public static bool operator !=(Quadra<T1, T2>? quadra1,
                                   Quadra<T1, T2>? quadra2)
    {
        return !(quadra1 == quadra2);
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
        if(obj is Quadra<T1, T2> another)
        {
            return this == another;
        }

        return false;
    }

    /// <summary>
    /// Function which checks on equality of current instance and given instance of <see cref="Quadra{T1, T2}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Quadra{T1, T2}"/> which represents other one instance of <see cref="Quadra{T1, T2}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether current instance and given one are equal
    /// </returns>
    public bool Equals(Quadra<T1, T2>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    /// <summary>
    /// Function which checks on equality two different instances of <see cref="Quadra{T1, T2}"/>
    /// </summary>
    /// <param name="quadra1">
    /// An instance of <see cref="Quadra{T1, T2}"/> which represents other one instance of <see cref="Quadra{T1, T2}"/>
    /// </param>
    /// <param name="quadra2">
    /// An instance of <see cref="Quadra{T1, T2}"/> which represents other one instance of <see cref="Quadra{T1, T2}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
    public bool Equals(Quadra<T1, T2>? quadra1,
                       Quadra<T1, T2>? quadra2)
    {
        if(quadra1 == null && quadra2 == null)
            return true;
        if(quadra1 == null || quadra2 == null)
            return false;

        return quadra1 == quadra2;
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
            hash = hash * 23 + (Param4?.GetHashCode() ?? 0);

            return hash;
        }
    }

    /// <summary>
    /// Function which calcs hash code of given instance of <see cref="Quadra{T1, T2}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Quadra{T1, T2}"/> which represents other one instance of <see cref="Quadra{T1, T2}"/>
    /// </param>
    /// <returns>
    /// A signed 32-bit integer value which represents hash code of given instance of <see cref="Quadra{T1, T2}"/>
    /// </returns>
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

/// <summary>
/// A class which represents a non-static container for four values
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
public class Quadra<T1, T2, T3> : IEquatable<Quadra<T1, T2, T3>>, IEqualityComparer<Quadra<T1, T2, T3>>,
                                  IData
{
    /// <summary>
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </summary>
    public T1? Param1 { get; set; } = default;
    /// <summary>
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </summary>
    public T1? Param2 { get; set; } = default;
    /// <summary>
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </summary>
    public T2? Param3 { get; set; } = default;
    /// <summary>
    /// A generic type <typeparamref name="T3"/> value representing one of parameters in the data type
    /// </summary>
    public T3? Param4 { get; set; } = default;

    /// <summary>
    /// <inheritdoc cref="IData.Params()"/>
    /// </summary>
    public object?[] Params => new object?[] { Param1, Param2, Param3, Param4 };

    /// <summary>
    /// Instance init of the class constructor
    /// </summary>
    public Quadra() {}

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="param1">
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param2">
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param3">
    /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="param4">
    /// A generic type <typeparamref name="T3"/> value representing one of parameters in the data type
    /// </param>
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

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="singleton1">
    /// An instance of <see cref="Singleton{T1}"/> which contains generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="singleton2">
    /// An instance of <see cref="Singleton{T1}"/> which contains generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="singleton3">
    /// An instance of <see cref="Singleton{T2}"/> which contains generic type <typeparamref name="T2"/> value representing one of parameters in the data type
    /// </param>
    /// <param name="singleton4">
    /// An instance of <see cref="Singleton{T3}"/> which contains generic type <typeparamref name="T3"/> value representing one of parameters in the data type
    /// </param>
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

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="pair1">
    /// An instance of <see cref="Pair{T1}"/> which contains generic type <typeparamref name="T1"/> values representing two of parameters in the data type
    /// </param>
    /// <param name="pair2">
    /// An instance of <see cref="Pair{T1, T2}"/> which contains generic type <typeparamref name="T2"/> and <typeparamref name="T3"/> values representing two of parameters in the data type
    /// </param>
    public Quadra(Pair<T1> pair1,
                  Pair<T2, T3> pair2)
    {
        Param1 = pair1.Param1;
        Param2 = pair1.Param2;
        Param3 = pair2.Param1;
        Param4 = pair2.Param2;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="triad">
    /// An instance of <see cref="Triad{T1, T2, T3}"/> which contains generic type <typeparamref name="T1"/> and <typeparamref name="T2"/> and <typeparamref name="T3"/> values representing three of parameters in the data type
    /// </param>
    /// <param name="param">
    /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
    /// </param>
    public Quadra(Triad<T1, T2, T3> triad, T1? param)
    {
        Param1 = triad.Param1;
        Param2 = param;
        Param3 = triad.Param2;
        Param4 = triad.Param3;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Quadra{T}"/> from which current one will be constructed
    /// </param>
    public Quadra(Quadra<T1, T2, T3> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
        Param4 = other.Param4;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public Quadra((T1, T1, T2, T3) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public Quadra(Tuple<T1, T1, T2, T3> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    /// <summary>
    /// <inheritdoc cref="IData.Swap()"/>
    /// </summary>
    public void Swap()
    {
        var tmp_converted_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
        var tmp_converted_param2 = (T3?)Convert.ChangeType(Param2, typeof(T3));
        var tmp_converted_param3 = (T1?)Convert.ChangeType(Param3, typeof(T1));
        var tmp_converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));

        (Param1, Param2, Param3, Param4) = (tmp_converted_param3, tmp_converted_param4, tmp_converted_param1, tmp_converted_param2);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Move()"/>
    /// </summary>
    public void Move()
    {
        var tmp_converted_param2 = (T2?)Convert.ChangeType(Param2, typeof(T2));
        var tmp_converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));
        var tmp_converted_param3 = (T3?)Convert.ChangeType(Param3, typeof(T3));

        (Param1, Param2, Param3, Param4) = (tmp_converted_param4, Param1, tmp_converted_param2, tmp_converted_param3);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Nullify()"/>
    /// </summary>
    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
        Param4 = default;
    }

    /// <summary>
    /// Operator for <see cref="Quadra{T1, T2, T3}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Quadra<T1, T2, T3>(
                                          (T1, T1, T2, T3) value)
    {
        return new Quadra<T1, T2, T3>(value);
    }

    /// <summary>
    /// Operator for <see cref="Quadra{T1, T2, T3}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Quadra<T1, T2, T3>(
                                     Tuple<T1, T1, T2, T3> value)
    {
        return new Quadra<T1, T2, T3>(value);
    }

    /// <summary>
    /// Operator for <see cref="Quadra{T1, T2, T3}"/> for EQUALS operand
    /// </summary>
    /// <param name="quadra1">
    /// An instance of <see cref="Quadra{T1, T2, T3}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3}"/>
    /// </param>
    /// <param name="quadra2">
    /// An instance of <see cref="Quadra{T1, T2, T3}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
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

    /// <summary>
    /// Operator for <see cref="Quadra{T1, T2, T3}"/> for NOT EQUALS operand
    /// </summary>
    /// <param name="quadra1">
    /// An instance of <see cref="Quadra{T1, T2, T3}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3}"/>
    /// </param>
    /// <param name="quadra2">
    /// An instance of <see cref="Quadra{T1, T2, T3}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are not equal
    /// </returns>
    public static bool operator !=(Quadra<T1, T2, T3>? quadra1,
                                   Quadra<T1, T2, T3>? quadra2)
    {
        return !(quadra1 == quadra2);
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
        if(obj is Quadra<T1, T2, T3> another)
        {
            return this == another;
        }

        return false;
    }

    /// <summary>
    /// Function which checks on equality of current instance and given instance of <see cref="Quadra{T1, T2, T3}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Quadra{T1, T2, T3}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether current instance and given one are equal
    /// </returns>
    public bool Equals(Quadra<T1, T2, T3>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    /// <summary>
    /// Function which checks on equality two different instances of <see cref="Quadra{T1, T2, T3}"/>
    /// </summary>
    /// <param name="quadra1">
    /// An instance of <see cref="Quadra{T1, T2, T3}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3}"/>
    /// </param>
    /// <param name="quadra2">
    /// An instance of <see cref="Quadra{T1, T2, T3}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
    public bool Equals(Quadra<T1, T2, T3>? quadra1,
                       Quadra<T1, T2, T3>? quadra2)
    {
        if(quadra1 == null && quadra2 == null)
            return true;
        if(quadra1 == null || quadra2 == null)
            return false;

        return quadra1 == quadra2;
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
            hash = hash * 23 + (Param4?.GetHashCode() ?? 0);

            return hash;
        }
    }

    /// <summary>
    /// Function which calcs hash code of given instance of <see cref="Quadra{T1, T2, T3}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Quadra{T1, T2, T3}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3}"/>
    /// </param>
    /// <returns>
    /// A signed 32-bit integer value which represents hash code of given instance of <see cref="Quadra{T1, T2, T3}"/>
    /// </returns>
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

/// <summary>
/// A class which represents a non-static container for four values
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
/// <typeparam name="T4">
/// A generic type <typeparamref name="T4"/> value representing one of parameters in the data type
/// </typeparam>
public class Quadra<T1, T2, T3, T4> : IEquatable<Quadra<T1, T2, T3, T4>>, IEqualityComparer<Quadra<T1, T2, T3, T4>>,
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
    /// A generic type <typeparamref name="T4"/> value representing one of parameters in the data type
    /// </summary>
    public T4? Param4 { get; set; } = default;

    /// <summary>
    /// <inheritdoc cref="IData.Params"/>
    /// </summary>
    public object?[] Params => new object?[] { Param1, Param2, Param3, Param4 };

    /// <summary>
    /// Instance init of the class constructor
    /// </summary>
    public Quadra() {}

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
    /// <param name="param4">
    /// A generic type <typeparamref name="T4"/> value representing one of parameters in the data type
    /// </param>
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
    /// <param name="singleton4">
    /// An instance of <see cref="Singleton{T4}"/> which contains generic type <typeparamref name="T4"/> value representing one of parameters in the data type
    /// </param>
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

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="pair1">
    /// An instance of <see cref="Pair{T1, T2}"/> which contains generic type <typeparamref name="T1"/> and <typeparamref name="T2"/> values representing two of parameters in the data type
    /// </param>
    /// <param name="pair2">
    /// An instance of <see cref="Pair{T3, T4}"/> which contains generic type <typeparamref name="T3"/> and <typeparamref name="T4"/> values representing two of parameters in the data type
    /// </param>
    public Quadra(Pair<T1, T2> pair1,
                  Pair<T3, T4> pair2)
    {
        Param1 = pair1.Param1;
        Param2 = pair1.Param2;
        Param3 = pair2.Param1;
        Param4 = pair2.Param2;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="triad">
    /// An instance of <see cref="Triad{T1, T2, T3}"/> which contains generic {T1, T2, T3} values representing three of parameters in the data type
    /// </param>
    /// <param name="param">
    /// A generic type <typeparamref name="T4"/> value representing one of parameters in the data type
    /// </param>
    public Quadra(Triad<T1, T2, T3> triad, T4? param)
    {
        Param1 = triad.Param1;
        Param2 = triad.Param2;
        Param3 = triad.Param3;
        Param4 = param;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Quadra{T1, T2, T3, T4}"/> from which current one will be constructed
    /// </param>
    public Quadra(Quadra<T1, T2, T3, T4> other)
    {
        Param1 = other.Param1;
        Param2 = other.Param2;
        Param3 = other.Param3;
        Param4 = other.Param4;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public Quadra((T1, T2, T3, T4) tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public Quadra(Tuple<T1, T2, T3, T4> tuple)
    {
        Param1 = tuple.Item1;
        Param2 = tuple.Item2;
        Param3 = tuple.Item3;
        Param4 = tuple.Item4;
    }

    /// <summary>
    /// <inheritdoc cref="IData.Swap()"/>
    /// </summary>
    public void Swap()
    {
        var tmp_converted_param1 = (T3?)Convert.ChangeType(Param1, typeof(T3));
        var tmp_converted_param2 = (T4?)Convert.ChangeType(Param2, typeof(T4));
        var tmp_converted_param3 = (T1?)Convert.ChangeType(Param3, typeof(T1));
        var tmp_converted_param4 = (T2?)Convert.ChangeType(Param4, typeof(T2));

        (Param1, Param2, Param3, Param4) = (tmp_converted_param3, tmp_converted_param4, tmp_converted_param1, tmp_converted_param2);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Move()"/>
    /// </summary>
    public void Move()
    {
        var tmp_converted_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
        var tmp_converted_param2 = (T3?)Convert.ChangeType(Param2, typeof(T3));
        var tmp_converted_param3 = (T4?)Convert.ChangeType(Param3, typeof(T4));
        var tmp_converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));

        (Param1, Param2, Param3, Param4) = (tmp_converted_param4, tmp_converted_param1, tmp_converted_param2, tmp_converted_param3);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Nullify()"/>
    /// </summary>
    public void Nullify()
    {
        Param1 = default;
        Param2 = default;
        Param3 = default;
        Param4 = default;
    }

    /// <summary>
    /// Operator for <see cref="Quadra{T1, T2, T3, T4}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Quadra<T1, T2, T3, T4>(
                                          (T1, T2, T3, T4) value)
    {
        return new Quadra<T1, T2, T3, T4>(value);
    }

    /// <summary>
    /// Operator for <see cref="Quadra{T1, T2, T3, T4}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which represents static tuple with four value
    /// </param>
    public static implicit operator Quadra<T1, T2, T3, T4>(
                                     Tuple<T1, T2, T3, T4> value)
    {
        return new Quadra<T1, T2, T3, T4>(value);
    }

    /// <summary>
    /// Operator for <see cref="Quadra{T1, T2, T3, T4}"/> for EQUALS operand
    /// </summary>
    /// <param name="quadra1">
    /// An instance of <see cref="Quadra{T1, T2, T3, T4}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3, T4}"/>
    /// </param>
    /// <param name="quadra2">
    /// An instance of <see cref="Quadra{T1, T2, T3, T4}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3, T4}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
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

    /// <summary>
    /// Operator for <see cref="Quadra{T1, T2, T3, T4}"/> for NOT EQUALS operand
    /// </summary>
    /// <param name="quadra1">
    /// An instance of <see cref="Quadra{T1, T2, T3, T4}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3, T4}"/>
    /// </param>
    /// <param name="quadra2">
    /// An instance of <see cref="Quadra{T1, T2, T3, T4}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3, T4}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are not equal
    /// </returns>
    public static bool operator !=(Quadra<T1, T2, T3, T4>? quadra1,
                                   Quadra<T1, T2, T3, T4>? quadra2)
    {
        return !(quadra1 == quadra2);
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
        if(obj is Quadra<T1, T2, T3, T4> another)
        {
            return this == another;
        }

        return false;
    }

    /// <summary>
    /// Function which checks on equality of current instance and given instance of <see cref="Quadra{T1, T2, T3, T4}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Quadra{T1, T2, T3, T4}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3, T4}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether current instance and given one are equal
    /// </returns>
    public bool Equals(Quadra<T1, T2, T3, T4>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    /// <summary>
    /// Function which checks on equality two different instances of <see cref="Quadra{T1, T2, T3, T4}"/>
    /// </summary>
    /// <param name="quadra1">
    /// An instance of <see cref="Quadra{T1, T2, T3, T4}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3, T4}"/>
    /// </param>
    /// <param name="quadra2">
    /// An instance of <see cref="Quadra{T1, T2, T3, T4}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3, T4}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
    public bool Equals(Quadra<T1, T2, T3, T4>? quadra1,
                       Quadra<T1, T2, T3, T4>? quadra2)
    {
        if(quadra1 == null && quadra2 == null)
            return true;
        if(quadra1 == null || quadra2 == null)
            return false;

        return quadra1 == quadra2;
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
            hash = hash * 23 + (Param4?.GetHashCode() ?? 0);

            return hash;
        }
    }

    /// <summary>
    /// Function which calcs hash code of given instance of <see cref="Quadra{T1, T2, T3, T4}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Quadra{T1, T2, T3, T4}"/> which represents other one instance of <see cref="Quadra{T1, T2, T3, T4}"/>
    /// </param>
    /// <returns>
    /// A signed 32-bit integer value which represents hash code of given instance of <see cref="Quadra{T1, T2, T3, T4}"/>
    /// </returns>
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
