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

namespace Zustandf.Data.Arrays;

/// <summary>
/// A non-generic dynamic representation of <see cref="Jenga{T}"/> which holds <see cref="object"/> as it's primary type
/// </summary>
public sealed class Jenga : Jenga<object> { }

/// <summary>
/// A class which represents an unique array data structure reminiscent of the structure of the same name
/// </summary>
/// <typeparam name="T">
/// A generic type <typeparamref name="T"/> value representing data which array structure storages as it's values
/// </typeparam>
public class Jenga<T> : ICollection<T>, ICloneable
{
    /// <summary>
    /// A signed 32-bit integer value which represents number of elements inside the <see cref="Dictionary{TKey, TValue}.Values"/> inside instance
    /// </summary>
    public int Count => Controllers.Count;

    /// <summary>
    /// A signed 64-bit integer value which represents number of elements inside the <see cref="Dictionary{TKey, TValue}.Values"/> inside instance
    /// </summary>
    public long LongCount => Controllers.LongCount();

    /// <summary>
    /// An instance of <see cref="ICollection{T}"/> which represents collection of values inside of <see cref="Controllers"/>
    /// </summary>
    public ICollection<T> Items => Controllers.Values;

    /// <summary>
    /// An instance of <see cref="Dictionary{TKey, TValue}"/> which represents key-value pairs of every value of instance, where key is ID and value is <typeparamref name="T"/>
    /// </summary>
    public Dictionary<long, T> Controllers { get; internal set; } = new();

    /// <summary>
    /// Boolean parameter which indicates whether access to the current instance is thread safe
    /// </summary>
    public virtual bool IsSynchronized => false;

    /// <summary>
    /// Boolean parameter which indicates whether collection is read-only
    /// </summary>
    public virtual bool IsReadOnly => false;

    /// <summary>
    /// An object which represents root for sync access to the current instance
    /// </summary>
    public virtual object SyncRoot => new();

    /// <summary>
    /// Instance init of the class constructor
    /// </summary>
    public Jenga() { }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="capacity">
    /// A signed 32-bit integer value which represents starting capacity for value collections inside the instance
    /// </param>
    public Jenga(int capacity)
    {
        Controllers = new Dictionary<long, T>(capacity);
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="collection">
    /// An instance of <see cref="ICollection{T}"/> which represents collection from which instance construct its own
    /// </param>
    public Jenga(ICollection<T> collection)
    {
        List<T> tmp_list = new();

        /* Jumping between signed and unsigned for direct cast of indexer. */
        for(uint i = 0; i < collection.Count; i++)
            Controllers[i]= tmp_list[(int)i];
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Jenga{T}"/> from which current one will be constructed
    /// </param>
    public Jenga(Jenga<T> other)
    {
        Controllers = other.Controllers;
    }

    /// <summary>
    /// Method which pushes given item on top of the stack
    /// </summary>
    /// <param name="item">
    /// A generic type <typeparamref name="T"/> value representing input into the instance
    /// </param>
    public virtual void Push(T item)
    {
        /* Not subtracting one because we
         * are creating NEW data in new position, thereafter, no need to recalculate index.
         */
        long index = Controllers.Count;

        Controllers.Add(index, item);
    }

    public virtual void Push(KeyValuePair<long, T> pair)
    {
        if(ContainsKey(pair.Key))
        {
            T tmp_item = Controllers[pair.Key];

            Controllers[pair.Key] = pair.Value;

            Push(tmp_item);
        }
        else
            Controllers.Add(pair.Key,
                            pair.Value);
    }

    public virtual T? Pop()
    {
        return Pipop().Param1;
    }

    public virtual T?[] Pop(long range)
    {
        return Pipop(range)
                    .Select(PR => PR.Param1)
                    .ToArray();
    }

    public virtual Pair<T?, bool> Pipop()
    {
        if (Controllers.Count < 1)
            throw new InvalidOperationException(EXCEPTION_MESSAGE_JENGA_EMPTY);

        long index = Controllers.Count - 1;

        T item = Controllers[index];

        bool found = Controllers.Remove(index);

        return (item, found);
    }

    public virtual Pair<T?, bool>[] Pipop(long range)
    {
        if(Controllers.Count < 1)
            throw new InvalidOperationException(EXCEPTION_MESSAGE_JENGA_EMPTY);

        if(Controllers.Count - range < 1)
            throw new ArgumentOutOfRangeException(nameof(range), string.Format(EXCEPTION_MESSAGE_JENGA_OUT_OF_RANGE, nameof(range)));

        Pair<T?, bool>[] tmp_data= new Pair<T?, bool>[range];

        for(long i = 0; i < range; i++)
            tmp_data[i] = Pipop();

        return tmp_data;
    }

    public virtual T? Peek()
    {
        if(Controllers.Count < 1)
           return default;

        long index = Controllers.Count - 1;

        return Controllers[index];
    }

    public static T? Peeky(Jenga<T> instance)
    {
        return instance.Peek();
    }

    public virtual T?[] PeekRange(long range)
    {
        if(Controllers.Count < 1)
            return Array.Empty<T>();

        T?[] tmp_data = new T?[range];

        if(Controllers.Count - range < 1)
        {
            for(int i = 0; i < range; i++)
                tmp_data[i]= default;
        }

        int tmp_index = Controllers.Count - 1;

        for(long i = 0; i < range; i++)
            tmp_data[i] = Controllers[tmp_index - range + i];

        return tmp_data;
    }

    public static T?[] PeekyRange(Jenga<T> instance, long range)
    {
        return instance.PeekRange(range);
    }

    public virtual void Clear()
    {
        Controllers.Clear();
    }

    public virtual object Clone()
    {
        return new Jenga<T>(this);
    }

    public virtual Jenga<T> Duplicate()
    {
        return new Jenga<T>(this);
    }

    public virtual bool Contains(T item)
    {
        return Controllers.ContainsValue(item);
    }

    public virtual void CopyTo(T[] array,
                               int arrayIndex)
    {
        Controllers.Values.CopyTo(array,
                                  arrayIndex);
    }

    [Obsolete(EXCEPTION_MESSAGE_JENGA_USE, true)]
    public void Add(T item)
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_JENGA_USE);
    }

    [Obsolete(EXCEPTION_MESSAGE_JENGA_USE, true)]
    public bool Remove(T item)
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_JENGA_USE);
    }

    public IEnumerator<T> GetEnumerator()
    => Controllers.Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
             => Controllers.GetEnumerator();

    public virtual void Enter(T item)
    {
        Push(item);
    }

    [Obsolete("Entering default for generic type value cause exceptions in case of custom collection, usage of this method can cause exceptions.")]
    public virtual void Enter(long position)
    {
#pragma warning disable CS8604
        Enter(position, default);
#pragma warning restore CS8604
    }

    public virtual void Enter(long position, T item)
    {
        if(Controllers.Keys.Count < 1)
        {
            if(position > Controllers.EnsureCapacity((int)position))
                throw new ArgumentOutOfRangeException(nameof(position), string.Format(EXCEPTION_MESSAGE_JENGA_OUT_OF_RANGE, nameof(position)));

            Controllers[position] = item;
        }
        else
        {
            if(position < 0 &&
               position >= Controllers.Values.Count)
                throw new ArgumentOutOfRangeException(nameof(position), string.Format(EXCEPTION_MESSAGE_JENGA_OUT_OF_RANGE, nameof(position)));

            /* Moves the existing item at the specified position to the top
             * and insert the new item within specified position. */

            Push(Controllers[position]);

            Controllers[position]= item;
        }
    }

    public virtual void Enter(KeyValuePair<long, T> item)
    {
        Enter(item.Key,
              item.Value);
    }

    public virtual bool Exit(T item)
    {
        if(!Contains(item))
            return false;

        long supposed_key = Controllers.FirstOrDefault(K => EqualityComparer<T>.Default.Equals(K.Value, item)).Key;

        return Controllers.Remove(supposed_key);
    }

    public virtual bool Exit(long position)
    {
        if(!ContainsKey(position))
            return false;

        return Controllers.Remove(position);
    }

    public virtual bool Exit(long position, T item)
    {
        if(position < 0 ||
           position >= Controllers.Values.Count)
            return false;

        if(!Contains(new KeyValuePair<long, T>(position, item)))
            return false;

        return Controllers.Remove(position);
    }

    public virtual bool Exit(KeyValuePair<long, T> item)
    {
        return Exit(item.Key,
                    item.Value);
    }

    public virtual T this[long position]
    {
        get
        {
            return Controllers[position];
        }

        set
        {
            T item = Controllers[position];

            /* Add the overridden item to the top and
             * assign the new value at the specified position */

            Push(item);

            Controllers[position] = value;
        }
    }

    public bool ContainsKey(long position)
    {
        return Controllers.ContainsKey(position);
    }

    public bool ContainsValue(T item)
    {
        return Controllers.ContainsValue(item);
    }

    public bool Contains(long key, T item)
    {
        return Contains(new KeyValuePair<long, T>(key, item));
    }

    public bool Contains(KeyValuePair<long, T> item)
    {
        return Controllers.Contains(item);
    }
}

public class Jenga<TKey, TValue> : IDictionary<TKey, TValue>, ICloneable where TKey : notnull
{
    public int Count => Controllers.Values.Count;

    public long LongCount => Controllers.Values.LongCount();

    public List<TValue> Items => Controllers.Values.ToList();

    public Dictionary<TKey, TValue> Controllers { get; internal set; } = new();

    /// <summary>
    /// An instance of <see cref="ICollection{T}"/> which represents array of keys of <see cref="Dictionary{TKey, TValue}"/> of the inner instance
    /// </summary>
    public ICollection<TKey> Keys => Controllers.Keys;

    /// <summary>
    /// An instance of <see cref="ICollection{T}"/> which represents array of values of <see cref="Dictionary{TKey, TValue}"/> of the inner instance
    /// </summary>
    public ICollection<TValue> Values => Controllers.Values;

    public virtual bool IsSynchronized => false;

    public virtual bool IsReadOnly => false;

    public virtual object SyncRoot => new();

    public Jenga() { }

    public Jenga(int capacity)
    {
        Controllers = new Dictionary<TKey, TValue>(capacity);
    }

    public Jenga(IDictionary<TKey, TValue> dictionary)
    {
        Controllers = new Dictionary<TKey, TValue>(dictionary);
    }

    public Jenga(IEnumerable<KeyValuePair<TKey, TValue>> enumerable)
    {
        Controllers = new Dictionary<TKey, TValue>(enumerable);
    }

    public Jenga(Jenga<TKey, TValue> other)
    {
        Controllers = other.Controllers;
    }

    public virtual void Push(TKey key, TValue value)
    {
        /* In case of dictionarized jenga, only available interaction
         * is push by both key and value pairs, making it's behaviour distinct from generic or defined by integer and generic. */
        Push(new KeyValuePair<TKey, TValue>(key, value));
    }

    public virtual void Push(KeyValuePair<TKey, TValue> pair)
    {
        if (ContainsKey(pair.Key))
            Controllers[pair.Key]= pair.Value;
        else
            Controllers.Add(pair.Key,
                            pair.Value);
    }

    public virtual TValue? Pop()
    {
        return Pipop().Param1;
    }

    public virtual TValue?[] Pop(long range)
    {
        return Pipop(range)
                    .Select(PR => PR.Param1)
                    .ToArray();
    }

    public virtual Pair<TValue?, bool> Pipop()
    {
        if(Controllers.Count < 1)
            throw new InvalidOperationException(EXCEPTION_MESSAGE_JENGA_EMPTY);

        KeyValuePair<TKey, TValue> item = Controllers.LastOrDefault();

        bool found = Controllers.Remove(item.Key);

        return (item.Value, found);
    }

    public virtual Pair<TValue?, bool>[] Pipop(long range)
    {
        if(Controllers.Count < 1)
            throw new InvalidOperationException(EXCEPTION_MESSAGE_JENGA_EMPTY);

        if(Controllers.Count - range < 1)
            throw new ArgumentOutOfRangeException(nameof(range), string.Format(EXCEPTION_MESSAGE_JENGA_OUT_OF_RANGE, nameof(range)));

        Pair<TValue?, bool>[] tmp_data = new Pair<TValue?, bool>[range];

        for(long i = 0; i < range; i++)
            tmp_data[i] = Pipop();

        return tmp_data;
    }

    public virtual TValue? Peek()
    {
        if(Controllers.Count < 1)
            throw new InvalidOperationException(EXCEPTION_MESSAGE_JENGA_EMPTY);

        return Controllers.Values.LastOrDefault();
    }

    public static TValue? Peeky(Jenga<TKey, TValue> instance)
    {
        return instance.Peek();
    }

    public virtual TValue?[] PeekRange(long range)
    {
        if(Controllers.Count < 1)
            throw new InvalidOperationException(EXCEPTION_MESSAGE_JENGA_EMPTY);

        if(Controllers.Count - range < 1)
            throw new ArgumentOutOfRangeException(nameof(range), string.Format(EXCEPTION_MESSAGE_JENGA_OUT_OF_RANGE, nameof(range)));

        return Duplicate().Pop(range);
    }

    public static TValue?[] PeekyRange(Jenga<TKey, TValue> instance, long range)
    {
        return instance.PeekRange(range);
    }

    public virtual void Clear()
    {
        Controllers.Clear();
    }

    public virtual object Clone()
    {
        return new Jenga<TKey, TValue>(this);
    }

    public virtual Jenga<TKey, TValue> Duplicate()
    {
        return new Jenga<TKey, TValue>(this);
    }

    public virtual bool TryGetValue(TKey key, out TValue? value)
    {
        return Controllers.TryGetValue(key, out value);
    }

    public virtual void CopyTo(TValue[] array,
                                    int arrayIndex)
    {
        Controllers.Values.CopyTo(array,
                                  arrayIndex);
    }

    public virtual void CopyTo(KeyValuePair<TKey, TValue>[] array,
                                                        int arrayIndex)
    {
        if (arrayIndex < 0 ||
            arrayIndex >= array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Invalid start index in copying method of {nameof(Jenga<TKey, TValue>)} instance");

        if (array.Length -
            arrayIndex < Controllers.Count)
            throw new ArgumentException($"Not enough space in the array to accommodate all elements starting from the specified index from instance of {nameof(Jenga<TKey, TValue>)}");

        int i = arrayIndex;

#pragma warning disable IDE0008
        foreach (var K in Controllers)
        {
            array[i] = K;
            i++;
        }
#pragma warning restore IDE0008
    }

    [Obsolete(EXCEPTION_MESSAGE_JENGA_USE, true)]
    public void Add(TKey key, TValue value)
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_JENGA_USE);
    }

    [Obsolete(EXCEPTION_MESSAGE_JENGA_USE, true)]
    public void Add(KeyValuePair<TKey, TValue> item)
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_JENGA_USE);
    }

    [Obsolete(EXCEPTION_MESSAGE_JENGA_USE, true)]
    public bool Remove(TKey key)
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_JENGA_USE);
    }

    [Obsolete(EXCEPTION_MESSAGE_JENGA_USE, true)]
    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_JENGA_USE);
    }

    [Obsolete("Entering default for generic type value cause exceptions in case of custom dictionary, usage of this method can cause exceptions.")]
    public virtual void Enter(TKey key)
    {
#pragma warning disable CS8604
            Enter(key, default);
#pragma warning restore CS8604
    }

    public virtual void Enter(TKey key, TValue value)
    {
        Push(key, value);
    }

    public virtual void Enter(TKey key, TValue value, TKey append_key)
    {
        if(!Controllers.ContainsKey(key))
            Enter(key, value);
        else
        {
            if(Controllers.ContainsKey(append_key) && !EqualityComparer<TValue>.Default.Equals(Controllers[append_key], default))
                throw new ArgumentException("Can't set existing in current instance of jenga key as append key for case of updating existing key situation.", nameof(append_key));

            TValue temp = Controllers[key];

            Controllers[key]= value;

            /* Using infinite appendable tower logic for current instance of jenga. */
            Enter(append_key, temp);
        }
    }

    public virtual void Enter(KeyValuePair<TKey, TValue> pair)
    {
        Enter(pair.Key,
              pair.Value);
    }

    public virtual void Enter(KeyValuePair<TKey, TValue> pair, TKey append_key)
    {
        Enter(pair.Key,
              pair.Value, append_key);
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
                                    => Controllers.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
             => Controllers.GetEnumerator();

    public virtual TValue this[TKey key]
    {
        get
        {
            return Controllers[key];
        }
        set
        {
            Controllers[key] = value;
        }
    }

    public bool ContainsKey(TKey key)
    {
        return Controllers.ContainsKey(key);
    }

    public bool ContainsValue(TValue value)
    {
        return Controllers.ContainsValue(value);
    }

    public bool Contains(TKey key, TValue value)
    {
        return Controllers.ContainsKey(key) &&
               Controllers.ContainsValue(value);
    }

    public bool Contains(KeyValuePair<TKey, TValue> pair)
    {
        return Controllers.Contains(pair);
    }
}
