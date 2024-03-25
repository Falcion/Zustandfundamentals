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

public class Jenga<T> : Arrays.Jenga<T>
{
    public override bool IsSynchronized => true;

    public Jenga(Arrays.Jenga<T> basic)
    {
        lock(SyncRoot)
            Controllers = basic.Controllers;
    }

    public Jenga(Jenga<T> threadsafe)
    {
        lock(SyncRoot)
            Controllers = threadsafe.Controllers;
    }

    public override void Clear()
    {
        lock(SyncRoot)
            base.Clear();
    }

    public override object Clone()
    {
        lock(SyncRoot)
            return base.Clone();
    }

    public new Jenga<T> Duplicate()
    {
        return new Jenga<T>(this);
    }

    public override bool Contains(T item)
    {
        lock(SyncRoot)
            return base.Contains(item);
    }

    public override void CopyTo(T[] array, int arrayIndex)
    {
        lock(SyncRoot)
            base.CopyTo(array, arrayIndex);
    }

    public override void Enter(KeyValuePair<long, T> item)
    {
        lock(SyncRoot)
            base.Enter(item);
    }

    public override void Enter(T item)
    {
        lock(SyncRoot)
            base.Enter(item);
    }

    [Obsolete("Entering default for generic type value cause exceptions in case of custom collection, usage of this method can cause exceptions.")]
    public override void Enter(long position)
    {
        lock(SyncRoot)
            base.Enter(position);
    }

    public override void Enter(long position, T item)
    {
        lock(SyncRoot)
            base.Enter(position, item);
    }

    public override bool Exit(KeyValuePair<long, T> item)
    {
        lock(SyncRoot)
            return base.Exit(item);
    }

    public override bool Exit(T item)
    {
        lock(SyncRoot)
            return base.Exit(item);
    }

    public override bool Exit(long position)
    {
        lock(SyncRoot)
            return base.Exit(position);
    }

    public override T? Peek()
    {
        lock(SyncRoot)
            return base.Peek();
    }

    public override T?[] PeekRange(long range)
    {
        lock(SyncRoot)
            return base.PeekRange(range);
    }

    public override Pair<T?, bool> Pipop()
    {
        lock(SyncRoot)
            return base.Pipop();
    }

    public override Pair<T?, bool>[] Pipop(long range)
    {
        lock(SyncRoot)
            return base.Pipop(range);
    }

    public override T? Pop()
    {
        lock(SyncRoot)
            return base.Pop();
    }

    public override T?[] Pop(long range)
    {
        lock(SyncRoot)
            return base.Pop(range);
    }

    public override void Push(KeyValuePair<long, T> pair)
    {
        lock(SyncRoot)
            base.Push(pair);
    }

    public override void Push(T item)
    {
        lock(SyncRoot)
            base.Push(item);
    }

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

    public static Arrays.Jenga<T> Unsychronized(Jenga<T> threadsafe)
           => new Arrays.Jenga<T>(threadsafe);
}

public class Jenga<TKey, TValue> : Arrays.Jenga<TKey, TValue> where TKey : notnull
{
    public override bool IsSynchronized => true;

    public Jenga(Arrays.Jenga<TKey, TValue> basic)
    {
        lock(SyncRoot)
            Controllers = basic.Controllers;
    }

    public Jenga(Jenga<TKey, TValue> threadsafe)
    {
        lock(SyncRoot)
            Controllers = threadsafe.Controllers;
    }

    public override void Clear()
    {
        lock(SyncRoot)
            base.Clear();
    }

    public override object Clone()
    {
        lock(SyncRoot)
            return base.Clone();
    }

    public override Arrays.Jenga<TKey, TValue> Duplicate()
    {
        lock(SyncRoot)
            return base.Duplicate();
    }

    public override bool Contains(TValue value)
    {
        lock(SyncRoot)
            return base.Contains(value);
    }

    public override void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        lock(SyncRoot)
            base.CopyTo(array, arrayIndex);
    }

    public override void CopyTo(TValue[] array, int arrayIndex)
    {
        lock(SyncRoot)
            base.CopyTo(array, arrayIndex);
    }

    public override void Enter(KeyValuePair<TKey, TValue> pair)
    {
        lock(SyncRoot)
            base.Enter(pair);
    }

    public override void Enter(KeyValuePair<TKey, TValue> pair, TKey append_key)
    {
        lock(SyncRoot)
            base.Enter(pair, append_key);
    }

    public override void Enter(TKey key)
    {
        lock(SyncRoot)
            base.Enter(key);
    }

    public override void Enter(TKey key, TValue value)
    {
        lock(SyncRoot)
            base.Enter(key, value);
    }

    public override void Enter(TKey key, TValue value, TKey append_key)
    {
        lock(SyncRoot)
            base.Enter(key, value, append_key);
    }

    public override TValue? Peek()
    {
        lock(SyncRoot)
            return base.Peek();
    }

    public override TValue?[] PeekRange(long range)
    {
        lock(SyncRoot)
            return base.PeekRange(range);
    }

    public override Pair<TValue?, bool> Pipop()
    {
        lock(SyncRoot)
            return base.Pipop();
    }

    public override Pair<TValue?, bool>[] Pipop(long range)
    {
        lock(SyncRoot)
            return base.Pipop(range);
    }

    public override TValue? Pop()
    {
        lock(SyncRoot)
            return base.Pop();
    }

    public override TValue?[] Pop(long range)
    {
        lock(SyncRoot)
            return base.Pop(range);
    }

    public override void Push(KeyValuePair<TKey, TValue> pair)
    {
        lock(SyncRoot)
            base.Push(pair);
    }

    public override void Push(TKey key, TValue value)
    {
        lock(SyncRoot)
            base.Push(key, value);
    }

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

    public override bool TryGetValue(TKey key, out TValue value)
    {
        lock(SyncRoot)
            return base.TryGetValue(key, out value);
    }

    public static Arrays.Jenga<TKey, TValue> Unsychronized(Jenga<TKey, TValue> threadsafe)
           => new Arrays.Jenga<TKey, TValue>(threadsafe);
}
