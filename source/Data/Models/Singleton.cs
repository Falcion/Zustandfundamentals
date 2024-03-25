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
/// A non-generic dynamic representation of <see cref="Singleton{T}"/> which holds <see cref="object"/> as it's primary type
/// </summary>
public sealed class Singleton : Singleton<object> { }

/// <summary>
/// A class which represents a non-static container for one single value which avoids precompilation preparations
/// </summary>
/// <typeparam name="T">
/// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
/// </typeparam>
public class Singleton<T> : IEquatable<Singleton<T>>, IEqualityComparer<Singleton<T>>,
                            IData
{
    /// <summary>
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </summary>
    public T? Param { get; set; } = default;

    /// <summary>
    /// <inheritdoc cref="IData.Params"/>
    /// </summary>
    public object?[] Params => new object?[] { Param };

    /// <summary>
    /// Instance init of the class constructor
    /// </summary>
    public Singleton() {}

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="param">
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </param>
    public Singleton(T? param)
    {
        Param = param;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="tuple">
    /// An instance of <see cref="Tuple{T1}"/> which represents static tuple with one value
    /// </param>
    public Singleton(Tuple<T> tuple)
    {
        Param = tuple.Item1;
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Singleton{T}"/> which from current one will be constructed
    /// </param>
    public Singleton(Singleton<T> other)
    {
        Param = other.Param;
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
    /// <exception cref="NotSupportedException">
    /// Thrown whenever this method is called
    /// </exception>
    [Obsolete(EXCEPTION_MESSAGE_DATA_EVEN, true)]
    public void Move()
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_DATA_EVEN);
    }

    /// <summary>
    /// <inheritdoc cref="IData.Nullify()"/>
    /// </summary>
    public void Nullify()
    {
        Param = default;
    }

    /// <summary>
    /// Operator for <see cref="Singleton{T}"/> instance
    /// </summary>
    /// <param name="value">
    /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
    /// </param>
    public static implicit operator Singleton<T>(
                                              T value)
    {
        return new Singleton<T>(value);
    }

    /// <summary>
    /// Operator for <see cref="Singleton{T}"/> instance
    /// </summary>
    /// <param name="value">
    /// An instance of <see cref="Tuple{T1}"/> which represents static tuple with one value
    /// </param>
    public static implicit operator Singleton<T>(
                                        Tuple<T> value)
    {
        return new Singleton<T>(value.Item1);
    }

    /// <summary>
    /// Operator for <see cref="Singleton{T}"/> for EQUALS operand
    /// </summary>
    /// <param name="singleton1">
    /// An instance of <see cref="Singleton{T}"/> which represents other one instance of <see cref="Singleton{T}"/>
    /// </param>
    /// <param name="singleton2">
    /// An instance of <see cref="Singleton{T}"/> which represents other one instance of <see cref="Singleton{T}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
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

    /// <summary>
    /// Operator for <see cref="Singleton{T}"/> for NOT EQUALS operand
    /// </summary>
    /// <param name="singleton1">
    /// An instance of <see cref="Singleton{T}"/> which represents other one instance of <see cref="Singleton{T}"/>
    /// </param>
    /// <param name="singleton2">
    /// An instance of <see cref="Singleton{T}"/> which represents other one instance of <see cref="Singleton{T}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are not equal
    /// </returns>
    public static bool operator !=(Singleton<T>? singleton1,
                                   Singleton<T>? singleton2)
    {
        return !(singleton1 == singleton2);
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
        if(obj is Singleton<T> another)
        {
            return this == another;
        }

        return false;
    }

    /// <summary>
    /// Function which checks on equality of current instance and given instance of <see cref="Singleton{T}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Singleton{T}"/> which represents other one instance of <see cref="Singleton{T}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether current instance and given one are equal
    /// </returns>
    public bool Equals(Singleton<T>? other)
    {
        if(other is null)
            return false;

        return this == other;
    }

    /// <summary>
    /// Function which checks on equality two different instances of <see cref="Singleton{T}"/>
    /// </summary>
    /// <param name="singleton1">
    /// An instance of <see cref="Singleton{T}"/> which represents other one instance of <see cref="Singleton{T}"/>
    /// </param>
    /// <param name="singleton2">
    /// An instance of <see cref="Singleton{T}"/> which represents other one instance of <see cref="Singleton{T}"/>
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates whether two instances are equal
    /// </returns>
    public bool Equals(Singleton<T>? singleton1,
                       Singleton<T>? singleton2)
    {
        if(singleton1 == null && singleton2 == null)
            return true;
        if(singleton1 == null || singleton2 == null)
            return false;

        return singleton1 == singleton2;
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

            hash = hash * 23 + (Param?.GetHashCode() ?? 0);

            return hash;
        }
    }

    /// <summary>
    /// Function which calcs hash code of given instance of <see cref="Singleton{T}"/>
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Singleton{T}"/> which represents other one instance of <see cref="Singleton{T}"/>
    /// </param>
    /// <returns>
    /// A signed 32-bit integer value which represents hash code of given instance of <see cref="Singleton{T}"/>
    /// </returns>
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
