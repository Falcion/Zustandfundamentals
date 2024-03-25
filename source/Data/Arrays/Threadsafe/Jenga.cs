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


using Zustandf.Data.Models;

namespace Zustandf.Data.Arrays.Threadsafe;

/// <summary>
/// A class which represents threadsafe version of <see cref="Arrays.Jenga{T}"/>
/// </summary>
/// <typeparam name="T">
/// <inheritdoc cref="Arrays.Jenga{T}"/>
/// </typeparam>
public class Jenga<T> : Arrays.Jenga<T>
{
    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.IsSynchronized"/>
    /// </summary>
    public override bool IsSynchronized => true;

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Jenga(Arrays.Jenga{T})"/>
    /// </summary>
    /// <param name="basic">
    /// <inheritdoc cref="Arrays.Jenga{T}.Jenga(Arrays.Jenga{T})"/>
    /// </param>
    public Jenga(Arrays.Jenga<T> basic)
    {
        lock(SyncRoot)
            Controllers = basic.Controllers;
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Jenga(Jenga{T})"/>
    /// </summary>
    /// <param name="threadsafe">
    /// <inheritdoc cref="Arrays.Jenga{T}.Jenga(Jenga{T})"/>
    /// </param>
    public Jenga(Jenga<T> threadsafe)
    {
        lock(SyncRoot)
            Controllers = threadsafe.Controllers;
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Clear()"/>
    /// </summary>
    public override void Clear()
    {
        lock(SyncRoot)
            base.Clear();
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Clone()"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{T}.Clone()"/>
    /// </returns>
    public override object Clone()
    {
        lock(SyncRoot)
            return base.Clone();
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Duplicate()"/>
    /// </summary>
    /// <returns>
    /// An instance of <see cref="Jenga{T}"/> which represents clone of current threadsafe instance
    /// </returns>
    public new Jenga<T> Duplicate()
    {
        return new Jenga<T>(this);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Contains(T)"/>
    /// </summary>
    /// <param name="item">
    /// <inheritdoc cref="Arrays.Jenga{T}.Contains(T)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{T}.Contains(T)"/>
    /// </returns>
    public override bool Contains(T item)
    {
        lock(SyncRoot)
            return base.Contains(item);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.CopyTo(T[], int)"/>
    /// </summary>
    /// <param name="array">
    /// An <see cref="Array"/> of <typeparamref name="T"/> which represents array of data in which instance's container will be copied
    /// </param>
    /// <param name="arrayIndex">
    /// A signed 32-bit integer value which represents starting index for copying data into given array
    /// </param>
    public override void CopyTo(T[] array, int arrayIndex)
    {
        lock(SyncRoot)
            base.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Enter(KeyValuePair{long, T})"/>
    /// </summary>
    /// <param name="item">
    /// <inheritdoc cref="Arrays.Jenga{T}.Enter(KeyValuePair{long, T})"/>
    /// </param>
    public override void Enter(KeyValuePair<long, T> item)
    {
        lock(SyncRoot)
            base.Enter(item);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Enter(T)"/>
    /// </summary>
    /// <param name="item">
    /// <inheritdoc cref="Arrays.Jenga{T}.Enter(T)"/>
    /// </param>
    public override void Enter(T item)
    {
        lock(SyncRoot)
            base.Enter(item);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Enter(long)"/>
    /// </summary>
    /// <param name="position">
    /// <inheritdoc cref="Arrays.Jenga{T}.Enter(long)"/>
    /// </param>
    [Obsolete("Entering default for generic type value cause exceptions in case of custom collection, usage of this method can cause exceptions.")]
    public override void Enter(long position)
    {
        lock(SyncRoot)
            base.Enter(position);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Enter(long, T)"/>
    /// </summary>
    /// <param name="position">
    /// <inheritdoc cref="Jenga{T}.Enter(long)"/>
    /// </param>
    /// <param name="item">
    /// <inheritdoc cref="Jenga{T}.Enter(T)"/>
    /// </param>
    public override void Enter(long position, T item)
    {
        lock(SyncRoot)
            base.Enter(position, item);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Exit(KeyValuePair{long, T})"/>
    /// </summary>
    /// <param name="item">
    /// <inheritdoc cref="Arrays.Jenga{T}.Exit(KeyValuePair{long, T})"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{T}.Exit(KeyValuePair{long, T})"/>
    /// </returns>
    public override bool Exit(KeyValuePair<long, T> item)
    {
        lock(SyncRoot)
            return base.Exit(item);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Exit(T)"/>
    /// </summary>
    /// <param name="item">
    /// <inheritdoc cref="Arrays.Jenga{T}.Exit(T)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{T}.Exit(T)"/>
    /// </returns>
    public override bool Exit(T item)
    {
        lock(SyncRoot)
            return base.Exit(item);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Exit(long)"/>
    /// </summary>
    /// <param name="position">
    /// <inheritdoc cref="Arrays.Jenga{T}.Exit(long)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{T}.Exit(long)"/>
    /// </returns>
    public override bool Exit(long position)
    {
        lock(SyncRoot)
            return base.Exit(position);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Peek()"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{T}.Peek()"/>
    /// </returns>
    public override T? Peek()
    {
        lock(SyncRoot)
            return base.Peek();
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.PeekRange(long)"/>
    /// </summary>
    /// <param name="range">
    /// <inheritdoc cref="Arrays.Jenga{T}.PeekRange(long)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{T}.PeekRange(long)"/>
    /// </returns>
    public override T?[] PeekRange(long range)
    {
        lock(SyncRoot)
            return base.PeekRange(range);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Pipop()"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{T}.Pipop()"/>
    /// </returns>
    public override Pair<T?, bool> Pipop()
    {
        lock(SyncRoot)
            return base.Pipop();
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Pipop(long)"/>
    /// </summary>
    /// <param name="range">
    /// <inheritdoc cref="Arrays.Jenga{T}.Pipop(long)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{T}.Pipop(long)"/>
    /// </returns>
    public override Pair<T?, bool>[] Pipop(long range)
    {
        lock(SyncRoot)
            return base.Pipop(range);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Pop()"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{T}.Pop()"/>
    /// </returns>
    public override T? Pop()
    {
        lock(SyncRoot)
            return base.Pop();
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Pop(long)"/>
    /// </summary>
    /// <param name="range">
    /// <inheritdoc cref="Arrays.Jenga{T}.Pop(long)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{T}.Pop(long)"/>
    /// </returns>
    public override T?[] Pop(long range)
    {
        lock(SyncRoot)
            return base.Pop(range);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Push(KeyValuePair{long, T})"/>
    /// </summary>
    /// <param name="pair">
    /// <inheritdoc cref="Arrays.Jenga{T}.Push(KeyValuePair{long, T})"/>
    /// </param>
    public override void Push(KeyValuePair<long, T> pair)
    {
        lock(SyncRoot)
            base.Push(pair);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{T}.Push(T)"/>
    /// </summary>
    /// <param name="item">
    /// <inheritdoc cref="Arrays.Jenga{T}.Push(T)"/>
    /// </param>
    public override void Push(T item)
    {
        lock(SyncRoot)
            base.Push(item);
    }

    /// <summary>
    /// Index accessor for get-set pair of executors for this instance
    /// </summary>
    /// <param name="position">
    /// A signed 64-bit integer value which represents index of item in the instance's container
    /// </param>
    /// <returns>
    /// A generic type <typeparamref name="T"/> value representing value contained in the instance
    /// </returns>
    public override T this[long position]
    {
        get
        {
            lock(SyncRoot)
                return base[position];
        }
        set
        {
            lock(SyncRoot)
                base[position] = value;
        }
    }

    /// <summary>
    /// Function which turns threadsafe verion of <see cref="Jenga{T}"/> into basic iteration of it
    /// </summary>
    /// <param name="threadsafe">
    /// An instance of <see cref="Threadsafe.Jenga{T}"/> which from basic version will be constructed
    /// </param>
    /// <returns>
    /// An instance of <see cref="Arrays.Jenga{T}"/> which represents basic version of <see cref="Threadsafe.Jenga{T}"/>
    /// </returns>
    public static Arrays.Jenga<T> Unsychronized(Jenga<T> threadsafe)
           => new Arrays.Jenga<T>(threadsafe);
}

/// <summary>
/// A class which represents threadsafe version of <see cref="Arrays.Jenga{TKey, TValue}"/>
/// </summary>
/// <typeparam name="TKey">
/// A generic type <typeparamref name="TKey"/> value representing keys in instance's data container
/// </typeparam>
/// <typeparam name="TValue">
/// A generic type <typeparamref name="TValue"/> value representing values in instance's data container
/// </typeparam>
public class Jenga<TKey, TValue> : Arrays.Jenga<TKey, TValue> where TKey : notnull
{
    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.IsSynchronized"/>
    /// </summary>
    public override bool IsSynchronized => true;

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Jenga(Arrays.Jenga{TKey, TValue})"/>
    /// </summary>
    /// <param name="basic">
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Jenga(Arrays.Jenga{TKey, TValue})"/>
    /// </param>
    public Jenga(Arrays.Jenga<TKey, TValue> basic)
    {
        lock(SyncRoot)
            Controllers = basic.Controllers;
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Jenga(Jenga{TKey, TValue})"/>
    /// </summary>
    /// <param name="threadsafe">
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Jenga(Jenga{TKey, TValue})"/>
    /// </param>
    public Jenga(Jenga<TKey, TValue> threadsafe)
    {
        lock(SyncRoot)
            Controllers = threadsafe.Controllers;
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Clear()"/>
    /// </summary>
    public override void Clear()
    {
        lock(SyncRoot)
            base.Clear();
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Clone()"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Clone()"/>
    /// </returns>
    public override object Clone()
    {
        lock(SyncRoot)
            return base.Clone();
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Clone()"/>
    /// </summary>
    /// <returns>
    /// An instance of <see cref="Jenga{TKey, TValue}"/> which represents clone of current threadsafe instance
    /// </returns>
    public override Arrays.Jenga<TKey, TValue> Duplicate()
    {
        lock(SyncRoot)
            return base.Duplicate();
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Contains(TValue)"/>
    /// </summary>
    /// <param name="value">
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Contains(TValue)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Contains(TValue)"/>
    /// </returns>
    public override bool Contains(TValue value)
    {
        lock(SyncRoot)
            return base.Contains(value);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.CopyTo(KeyValuePair{TKey, TValue}[], int)"/>
    /// </summary>
    /// <param name="array">
    /// An <see cref="Array"/> of <see cref="KeyValuePair{TKey, TValue}"/> which represents array of data in which instance's container will be copied
    /// </param>
    /// <param name="arrayIndex">
    /// <inheritdoc cref="Jenga{TKey, TValue}.CopyTo(TValue[], int)"/>
    /// </param>
    public override void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        lock(SyncRoot)
            base.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.CopyTo(TValue[], int)"/>
    /// </summary>
    /// <param name="array">
    /// An <see cref="Array"/> of <typeparamref name="TValue"/> which represents array of data in which instance's container will be copied
    /// </param>
    /// <param name="arrayIndex">
    /// A signed 32-bit integer value which represents starting index for copying data into given array
    /// </param>
    public override void CopyTo(TValue[] array, int arrayIndex)
    {
        lock(SyncRoot)
            base.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Enter(KeyValuePair{TKey, TValue})"/>
    /// </summary>
    /// <param name="pair">
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Enter(KeyValuePair{TKey, TValue})"/>
    /// </param>
    public override void Enter(KeyValuePair<TKey, TValue> pair)
    {
        lock(SyncRoot)
            base.Enter(pair);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Enter(KeyValuePair{TKey, TValue}, TKey)"/>
    /// </summary>
    /// <param name="pair">
    /// <inheritdoc cref="Jenga{TKey, TValue}.Push(KeyValuePair{TKey, TValue})"/>
    /// </param>
    /// <param name="append_key">
    /// A generic type <typeparamref name="TKey"/> value representing key for new insert interaction into instance's container
    /// </param>
    public override void Enter(KeyValuePair<TKey, TValue> pair, TKey append_key)
    {
        lock(SyncRoot)
            base.Enter(pair, append_key);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Enter(TKey)"/>
    /// </summary>
    /// <param name="key">
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Enter(TKey)"/>
    /// </param>
    [Obsolete("Entering default for generic type value cause exceptions in case of custom dictionary, usage of this method can cause exceptions.")]
    public override void Enter(TKey key)
    {
        lock(SyncRoot)
            base.Enter(key);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Enter(TKey, TValue)"/>
    /// </summary>
    /// <param name="key">
    /// A generic type <typeparamref name="TKey"/> value representing key for interaction with data in instance's container
    /// </param>
    /// <param name="value">
    /// A generic type <typeparamref name="TValue"/> value representing value of interaction with instance's container
    /// </param>
    public override void Enter(TKey key, TValue value)
    {
        lock(SyncRoot)
            base.Enter(key, value);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Enter(TKey, TValue, TKey)"/>
    /// </summary>
    /// <param name="key">
    /// A generic type <typeparamref name="TKey"/> value representing key for interaction with data in instance's container
    /// </param>
    /// <param name="value">
    /// A generic type <typeparamref name="TValue"/> value representing value of interaction with instance's container
    /// </param>
    /// <param name="append_key">
    /// A generic type <typeparamref name="TKey"/> value representing key for new insert interaction into instance's container
    /// </param>
    public override void Enter(TKey key, TValue value, TKey append_key)
    {
        lock(SyncRoot)
            base.Enter(key, value, append_key);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Peek()"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Peek()"/>
    /// </returns>
    public override TValue? Peek()
    {
        lock(SyncRoot)
            return base.Peek();
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.PeekRange(long)"/>
    /// </summary>
    /// <param name="range">
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.PeekRange(long)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.PeekRange(long)"/>
    /// </returns>
    public override TValue?[] PeekRange(long range)
    {
        lock(SyncRoot)
            return base.PeekRange(range);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Pipop()"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Pipop()"/>
    /// </returns>
    public override Pair<TValue?, bool> Pipop()
    {
        lock(SyncRoot)
            return base.Pipop();
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Pipop(long)"/>
    /// </summary>
    /// <param name="range">
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Pipop(long)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Pipop(long)"/>
    /// </returns>
    public override Pair<TValue?, bool>[] Pipop(long range)
    {
        lock(SyncRoot)
            return base.Pipop(range);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Pop()"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Pop()"/>
    /// </returns>
    public override TValue? Pop()
    {
        lock(SyncRoot)
            return base.Pop();
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Pop(long)"/>
    /// </summary>
    /// <param name="range">
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Pop(long)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Pop(long)"/>
    /// </returns>
    public override TValue?[] Pop(long range)
    {
        lock(SyncRoot)
            return base.Pop(range);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Push(KeyValuePair{TKey, TValue})"/>
    /// </summary>
    /// <param name="pair">
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Push(KeyValuePair{TKey, TValue})"/>
    /// </param>
    public override void Push(KeyValuePair<TKey, TValue> pair)
    {
        lock(SyncRoot)
            base.Push(pair);
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.Push(TKey, TValue)"/>
    /// </summary>
    /// <param name="key">
    /// A generic type <typeparamref name="TKey"/> value representing key for interaction with data in instance's container
    /// </param>
    /// <param name="value">
    /// A generic type <typeparamref name="TValue"/> value representing value of interaction with instance's container
    /// </param>>
    public override void Push(TKey key, TValue value)
    {
        lock(SyncRoot)
            base.Push(key, value);
    }

    /// <summary>
    /// Index accessor for get-set pair of executors for this instance
    /// </summary>
    /// <param name="key">
    /// A generic type <typeparamref name="TKey"/> value representing index of item in the instance's container
    /// </param>
    /// <returns>
    /// A generic type <typeparamref name="TValue"/> value representing value contained in the instance
    /// </returns>
    public override TValue this[TKey key]
    {
        get
        {
            lock(SyncRoot)
                return base[key];
        }
        set
        {
            lock(SyncRoot)
                base[key] = value;
        }
    }

    /// <summary>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.TryGetValue(TKey, out TValue)"/>
    /// </summary>
    /// <param name="key">
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.TryGetValue(TKey, out TValue)"/>
    /// </param>
    /// <param name="value">
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.TryGetValue(TKey, out TValue)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Arrays.Jenga{TKey, TValue}.TryGetValue(TKey, out TValue)"/>
    /// </returns>
    public override bool TryGetValue(TKey key, out TValue value)
    {
        lock(SyncRoot)
            return base.TryGetValue(key, out value);
    }

    /// <summary>
    /// Function which turns threadsafe verion of <see cref="Jenga{TKey, TValue}"/> into basic iteration of it
    /// </summary>
    /// <param name="threadsafe">
    /// An instance of <see cref="Threadsafe.Jenga{TKey, TValue}"/> which from basic version will be constructed
    /// </param>
    /// <returns>
    /// An instance of <see cref="Arrays.Jenga{TKey, TValue}"/> which represents basic version of <see cref="Threadsafe.Jenga{TKey, TValue}"/>
    /// </returns>
    public static Arrays.Jenga<TKey, TValue> Unsychronized(Jenga<TKey, TValue> threadsafe)
           => new Arrays.Jenga<TKey, TValue>(threadsafe);
}
