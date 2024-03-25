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
    /// A signed 32-bit integer value which represents number of elements inside the <see cref="Dictionary{TKey, TValue}"/> inside instance
    /// </summary>
    public int Count => Controllers.Count;

    /// <summary>
    /// A signed 64-bit integer value which represents number of elements inside the <see cref="Dictionary{TKey, TValue}"/> inside instance
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
    /// Boolean parameter which indicates whether instance's container is read-only
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
    /// A signed 32-bit integer value which represents starting capacity for value instance's containers inside the instance
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

    /// <summary>
    /// Method which force pushes given pair of key-item into the current stack
    /// </summary>
    /// <param name="pair">
    /// An instance of <see cref="KeyValuePair{TKey, TValue}"/> which represents key-item pair in context of stack
    /// </param>
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

    /// <summary>
    /// Function which removes and returns the object at the top of the current instance
    /// </summary>
    /// <returns>
    /// A generic type <typeparamref name="T"/> value representing value contained in the instance
    /// </returns>
    public virtual T? Pop()
    {
        return Pipop().Param1;
    }

    /// <summary>
    /// Function which removes and returns objects at the top of the current instance
    /// </summary>
    /// <param name="range">
    /// A signed 64-bit integer value which represents amount of pops for current instance
    /// </param>
    /// <returns>
    /// An <see cref="Array"/> of <typeparamref name="T"/> value which represents values contained in the instance
    /// </returns>
    public virtual T?[] Pop(long range)
    {
        return Pipop(range)
                    .Select(PR => PR.Param1)
                    .ToArray();
    }

    /// <summary>
    /// Function which removes and return objects with deletion operation status at the top of the current instance
    /// </summary>
    /// <returns>
    /// An instance of <see cref="Pair{T1, T2}"/> which represents boolean parameter of deletion status and exact value
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when instance contains less than one value or just empty
    /// </exception>
    public virtual Pair<T?, bool> Pipop()
    {
        if(Controllers.Count < 1)
            throw new InvalidOperationException(EXCEPTION_MESSAGE_JENGA_EMPTY);

        long index = Controllers.Count - 1;

        T item = Controllers[index];

        bool found = Controllers.Remove(index);

        return (item, found);
    }

    /// <summary>
    /// Function which removes and returns objects with deletion operation status at the top of the current instance
    /// </summary>
    /// <param name="range">
    /// A signed 64-bit integer value which represents amount of pops for current instance
    /// </param>
    /// <returns>
    /// An <see cref="Array"/> of <see cref="Pair{T1, T2}"/> which represents boolean parameters of deletion status and exact values
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when instance contains less than one value or just empty
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when amount of pops is greater than amount of values inside the instance
    /// </exception>
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

    /// <summary>
    /// Function which returns the object at the top of the current instance without removing it
    /// </summary>
    /// <returns>
    /// A generic type <typeparamref name="T"/> value representing value contained in the instance
    /// </returns>
    public virtual T? Peek()
    {
        if(Controllers.Count < 1)
           return default;

        long index = Controllers.Count - 1;

        return Controllers[index];
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Peek()"/>
    /// </summary>
    /// <param name="instance">
    /// An instance of <see cref="Jenga{T}"/> which with operation will be performed
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Peek()"/>
    /// </returns>
    public static T? Peeky(Jenga<T> instance)
    {
        return instance.Peek();
    }

    /// <summary>
    /// Function which returns the objects at the top of the current instance without removing them
    /// </summary>
    /// <param name="range">
    /// A signed 64-bit integer value which represents amount of peeks in the current instance
    /// </param>
    /// <returns>
    /// An <see cref="Array"/> of <typeparamref name="T"/> value which represents values contained in the instance
    /// </returns>
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

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.PeekRange(long)"/>
    /// </summary>
    /// <param name="instance">
    /// <inheritdoc cref="Jenga{T}.Peeky(Jenga{T})"/>
    /// </param>
    /// <param name="range">
    /// <inheritdoc cref="Jenga{T}.PeekRange(long)"/>
    /// </param>
    /// <returns></returns>
    public static T?[] PeekyRange(Jenga<T> instance, long range)
    {
        return instance.PeekRange(range);
    }

    /// <summary>
    /// Method which clears container for values in current instance
    /// </summary>
    public virtual void Clear()
    {
        Controllers.Clear();
    }

    /// <summary>
    /// Function which clones current instance
    /// </summary>
    /// <returns>
    /// An object which represents clone of current instance
    /// </returns>
    public virtual object Clone()
    {
        return new Jenga<T>(this);
    }

    /// <summary>
    /// Function which clones current instance
    /// </summary>
    /// <returns>
    /// An instance of <see cref="Jenga{T}"/> which represents clone of current instance
    /// </returns>
    public virtual Jenga<T> Duplicate()
    {
        return new Jenga<T>(this);
    }

    /// <summary>
    /// Method which copies the value instance's container in given array starting from given index
    /// </summary>
    /// <param name="array">
    /// An <see cref="Array"/> of <typeparamref name="T"/> which represents array of data in which instance's container will be copied
    /// </param>
    /// <param name="arrayIndex">
    /// A signed 32-bit integer value which represents starting index for copying data into given array
    /// </param>
    public virtual void CopyTo(T[] array,
                               int arrayIndex)
    {
        Controllers.Values.CopyTo(array,
                                  arrayIndex);
    }

    public static Threadsafe.Jenga<T> Synchronized(Jenga<T> instance)
           => new Threadsafe.Jenga<T>(instance);

    /// <summary>
    /// Method which adds given item into instance's container
    /// </summary>
    /// <param name="item">
    /// A generic type <typeparamref name="T"/> value representing input into the instance
    /// </param>
    /// <exception cref="NotSupportedException">
    /// Thrown via usage
    /// </exception>
    [Obsolete(EXCEPTION_MESSAGE_JENGA_USE, true)]
    public void Add(T item)
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_JENGA_USE);
    }

    /// <summary>
    /// Function which removes given input from current instance's container
    /// </summary>
    /// <param name="item">
    /// A generic type <typeparamref name="T"/> value representing input into the instance
    /// </param>
    /// <returns>
    /// Boolean parameter which represents status of deletion operation
    /// </returns>
    /// <exception cref="NotSupportedException">
    /// Thrown via usage
    /// </exception>
    [Obsolete(EXCEPTION_MESSAGE_JENGA_USE, true)]
    public bool Remove(T item)
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_JENGA_USE);
    }

    /// <summary>
    /// Function which returns an enumerator that iterates through the instance's container.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="IEnumerator{T}"/> which can be used to iterate through the instance's container.
    /// </returns>
    public IEnumerator<T> GetEnumerator()
    => Controllers.Values.GetEnumerator();

    /// <summary>
    /// Function which returns an enumerator that iterates through the instance's container.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="IEnumerator"/> which can be used to iterate through the instance's container.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
             => Controllers.GetEnumerator();

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Add(T)"/>
    /// </summary>
    /// <param name="item">
    /// <inheritdoc cref="Jenga{T}.Add(T)"/>
    /// </param>
    public virtual void Enter(T item)
    {
        Push(item);
    }

    /// <summary>
    /// Method which adds default value by given position
    /// </summary>
    /// <param name="position">
    /// A signed 64-bit integer value which represents position in which value will be inserted
    /// </param>
    [Obsolete("Entering default for generic type value cause exceptions in case of custom collection, usage of this method can cause exceptions.")]
    public virtual void Enter(long position)
    {
#pragma warning disable CS8604
        Enter(position, default);
#pragma warning restore CS8604
    }

    /// <summary>
    /// Method which adds given item into given position
    /// </summary>
    /// <param name="position">
    /// <inheritdoc cref="Jenga{T}.Enter(long)"/>
    /// </param>
    /// <param name="item">
    /// <inheritdoc cref="Jenga{T}.Enter(T)"/>
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when given position exceeds capacity and/or length of value's instance's container
    /// </exception>
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

    /// <summary>
    /// Method which adds given instance of <see cref="KeyValuePair{TKey, TValue}"/> into instance's container
    /// </summary>
    /// <param name="item">
    /// An instance of <see cref="KeyValuePair{TKey, TValue}"/> which represents value paired with key
    /// </param>
    public virtual void Enter(KeyValuePair<long, T> item)
    {
        Enter(item.Key,
              item.Value);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Remove(T)"/>
    /// </summary>
    /// <param name="item">
    /// <inheritdoc cref="Jenga{T}.Remove(T)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Remove(T)"/>
    /// </returns>
    public virtual bool Exit(T item)
    {
        if(!Contains(item))
            return false;

        long supposed_key = Controllers.FirstOrDefault(K => EqualityComparer<T>.Default.Equals(K.Value, item)).Key;

        return Controllers.Remove(supposed_key);
    }

    /// <summary>
    /// Function which removes an item from instance's container by it's position
    /// </summary>
    /// <param name="position">
    /// A signed 64-bit integer value which represents position in which value will be removed
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Exit(T)"/>
    /// </returns>
    public virtual bool Exit(long position)
    {
        if(!ContainsKey(position))
            return false;

        return Controllers.Remove(position);
    }

    /// <summary>
    /// Function which removes given item from instance's container both by it's position and value
    /// </summary>
    /// <param name="position">
    /// <inheritdoc cref="Jenga{T}.Exit(long)"/>
    /// </param>
    /// <param name="item">
    /// <inheritdoc cref="Jenga{T}.Exit(T)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Exit(T)"/>
    /// </returns>
    public virtual bool Exit(long position, T item)
    {
        if(position < 0 ||
           position >= Controllers.Values.Count)
            return false;

        if(!Contains(new KeyValuePair<long, T>(position, item)))
            return false;

        return Controllers.Remove(position);
    }

    /// <summary>
    /// Method which removes given instance of <see cref="KeyValuePair{TKey, TValue}"/> from instance's container
    /// </summary>
    /// <param name="item">
    /// An instance of <see cref="KeyValuePair{TKey, TValue}"/> which represents value paired with key
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Exit(T)"/>
    /// </returns>
    public virtual bool Exit(KeyValuePair<long, T> item)
    {
        return Exit(item.Key,
                    item.Value);
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

    /// <summary>
    /// Function which checks does instance's container holds given value
    /// </summary>
    /// <param name="item">
    /// A generic type <typeparamref name="T"/> value representing input into the instance
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates does given value is container in the instance
    /// </returns>
    public virtual bool Contains(T item)
    {
        return Controllers.ContainsValue(item);
    }

    /// <summary>
    /// Function which checks does any value is contained in the instance's container by specified parameters
    /// </summary>
    /// <param name="position">
    /// A signed 64-bit integer value which represents an index of value inside the instance's container
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates does any value is container in the instance's container
    /// </returns>
    public bool ContainsKey(long position)
    {
        return Controllers.ContainsKey(position);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.ContainsKey(long)"/>
    /// </summary>
    /// <param name="item">
    /// A generic type <typeparamref name="T"/> value representing value contained in the instance
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.ContainsKey(long)"/>
    /// </returns>
    public bool ContainsValue(T item)
    {
        return Controllers.ContainsValue(item);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.ContainsKey(long)"/>
    /// </summary>
    /// <param name="position">
    /// <inheritdoc cref="Jenga{T}.ContainsKey(long)"/>
    /// </param>
    /// <param name="item">
    /// <inheritdoc cref="Jenga{T}.ContainsValue(T)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.ContainsKey(long)"/>
    /// </returns>
    public bool Contains(long position, T item)
    {
        return Contains(new KeyValuePair<long, T>(position, item));
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.ContainsKey(long)"/>
    /// </summary>
    /// <param name="item">
    /// An instance of <see cref="KeyValuePair{TKey, TValue}"/> which represents value paired with key
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.ContainsKey(long)"/>
    /// </returns>
    public bool Contains(KeyValuePair<long, T> item)
    {
        return Controllers.Contains(item);
    }
}

/// <summary>
/// A class which represents an unique array data structure reminiscent of the structure of the same name
/// </summary>
/// <typeparam name="TKey">
/// A generic type <typeparamref name="TKey"/> value representing keys in instance's data container
/// </typeparam>
/// <typeparam name="TValue">
/// A generic type <typeparamref name="TValue"/> value representing values in instance's data container
/// </typeparam>
public class Jenga<TKey, TValue> : IDictionary<TKey, TValue>, ICloneable where TKey : notnull
{
    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Count"/>
    /// </summary>
    public int Count => Controllers.Values.Count;

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.LongCount"/>
    /// </summary>
    public long LongCount => Controllers.Values.LongCount();

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Items"/>
    /// </summary>
    public List<TValue> Items => Controllers.Values.ToList();

    /// <summary>
    /// An instance of <see cref="Dictionary{TKey, TValue}"/> which represents key-value pairs of every value of instance
    /// </summary>
    public Dictionary<TKey, TValue> Controllers { get; internal set; } = new();

    /// <summary>
    /// An instance of <see cref="ICollection{T}"/> which represents array of keys of <see cref="Dictionary{TKey, TValue}"/> of the inner instance
    /// </summary>
    public ICollection<TKey> Keys => Controllers.Keys;

    /// <summary>
    /// An instance of <see cref="ICollection{T}"/> which represents array of values of <see cref="Dictionary{TKey, TValue}"/> of the inner instance
    /// </summary>
    public ICollection<TValue> Values => Controllers.Values;

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.IsSynchronized"/>
    /// </summary>
    public virtual bool IsSynchronized => false;

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.IsReadOnly"/>
    /// </summary>
    public virtual bool IsReadOnly => false;

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.SyncRoot"/>
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
    /// A signed 32-bit integer value which represents starting capacity for value instance's containers inside the instance
    /// </param>
    public Jenga(int capacity)
    {
        Controllers = new Dictionary<TKey, TValue>(capacity);
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="dictionary">
    /// An instance of <see cref="IDictionary{TKey, TValue}"/> which represents dictionary's interface for constructing
    /// </param>
    public Jenga(IDictionary<TKey, TValue> dictionary)
    {
        Controllers = new Dictionary<TKey, TValue>(dictionary);
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="enumerable">
    /// An instance of <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey, TValue}"/> which represents data interface for constructing
    /// </param>
    public Jenga(IEnumerable<KeyValuePair<TKey, TValue>> enumerable)
    {
        Controllers = new Dictionary<TKey, TValue>(enumerable);
    }

    /// <summary>
    /// Instance constructor for the class
    /// </summary>
    /// <param name="other">
    /// An instance of <see cref="Jenga{TKey, TValue}"/> from which current one will be constructed
    /// </param>
    public Jenga(Jenga<TKey, TValue> other)
    {
        Controllers = other.Controllers;
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Push(T)"/> within the key
    /// </summary>
    /// <param name="key">
    /// A generic type <typeparamref name="TKey"/> value representing key for interaction with data in instance's container
    /// </param>
    /// <param name="value">
    /// A generic type <typeparamref name="TValue"/> value representing value of interaction with instance's container
    /// </param>
    public virtual void Push(TKey key, TValue value)
    {
        /* In case of dictionarized jenga, only available interaction
         * is push by both key and value pairs, making it's behaviour distinct from generic or defined by integer and generic. */
        Push(new KeyValuePair<TKey, TValue>(key, value));
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Push(KeyValuePair{long, T})"/>
    /// </summary>
    /// <param name="pair">
    /// <inheritdoc cref="Jenga{T}.Push(KeyValuePair{long, T})"/>
    /// </param>
    public virtual void Push(KeyValuePair<TKey, TValue> pair)
    {
        if (ContainsKey(pair.Key))
            Controllers[pair.Key]= pair.Value;
        else
            Controllers.Add(pair.Key,
                            pair.Value);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Pop()"/>
    /// </summary>
    /// <returns>
    /// A generic type <typeparamref name="TValue"/> value representing value contained in the instance
    /// </returns>
    public virtual TValue? Pop()
    {
        return Pipop().Param1;
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Pop(long)"/>
    /// </summary>
    /// <param name="range">
    /// <inheritdoc cref="Jenga{T}.Pop(long)"/>
    /// </param>
    /// <returns>
    /// An <see cref="Array"/> of <typeparamref name="TValue"/> value which represents values contained in the instance
    /// </returns>
    public virtual TValue?[] Pop(long range)
    {
        return Pipop(range)
                    .Select(PR => PR.Param1)
                    .ToArray();
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Pipop()"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Pipop()"/>
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// <inheritdoc cref="Jenga{T}.Pipop()"/>
    /// </exception>
    public virtual Pair<TValue?, bool> Pipop()
    {
        if(Controllers.Count < 1)
            throw new InvalidOperationException(EXCEPTION_MESSAGE_JENGA_EMPTY);

        KeyValuePair<TKey, TValue> item = Controllers.LastOrDefault();

        bool found = Controllers.Remove(item.Key);

        return (item.Value, found);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Pipop(long)"/>
    /// </summary>
    /// <param name="range">
    /// <inheritdoc cref="Jenga{T}.Pipop(long)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Pipop(long)"/>
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// <inheritdoc cref="Jenga{T}.Pipop(long)"/>
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <inheritdoc cref="Jenga{T}.Pipop(long)"/>
    /// </exception>
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

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Peek()"/>
    /// </summary>
    /// <returns>
    /// A generic type <typeparamref name="TValue"/> value representing value contained in the instance
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// <inheritdoc cref="Jenga{T}.Peek()"/>
    /// </exception>
    public virtual TValue? Peek()
    {
        if(Controllers.Count < 1)
            throw new InvalidOperationException(EXCEPTION_MESSAGE_JENGA_EMPTY);

        return Controllers.Values.LastOrDefault();
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{TKey, TValue}.Peek()"/>
    /// </summary>
    /// <param name="instance">
    /// An instance of <see cref="Jenga{TKey, TValue}"/> which with operation will be performed
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{TKey, TValue}.Peek()"/>
    /// </returns>
    public static TValue? Peeky(Jenga<TKey, TValue> instance)
    {
        return instance.Peek();
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.PeekRange(long)"/>
    /// </summary>
    /// <param name="range">
    /// <inheritdoc cref="Jenga{T}.PeekRange(long)"/>
    /// </param>
    /// <returns>
    /// An <see cref="Array"/> of <typeparamref name="TValue"/> value which represents values contained in the instance
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// <inheritdoc cref="Jenga{T}.PeekRange(long)"/>
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <inheritdoc cref="Jenga{T}.PeekRange(long)"/>
    /// </exception>
    public virtual TValue?[] PeekRange(long range)
    {
        if(Controllers.Count < 1)
            throw new InvalidOperationException(EXCEPTION_MESSAGE_JENGA_EMPTY);

        if(Controllers.Count - range < 1)
            throw new ArgumentOutOfRangeException(nameof(range), string.Format(EXCEPTION_MESSAGE_JENGA_OUT_OF_RANGE, nameof(range)));

        return Duplicate().Pop(range);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{TKey, TValue}.PeekRange(long)"/>
    /// </summary>
    /// <param name="instance">
    /// <inheritdoc cref="Jenga{TKey, TValue}.Peeky(Jenga{TKey, TValue})"/>
    /// </param>
    /// <param name="range">
    /// <inheritdoc cref="Jenga{TKey, TValue}.PeekRange(long)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{TKey, TValue}.PeekRange(long)"/>
    /// </returns>
    public static TValue?[] PeekyRange(Jenga<TKey, TValue> instance, long range)
    {
        return instance.PeekRange(range);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Clear()"/>
    /// </summary>
    public virtual void Clear()
    {
        Controllers.Clear();
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Clone()"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Clone()"/>
    /// </returns>
    public virtual object Clone()
    {
        return new Jenga<TKey, TValue>(this);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Duplicate()"/>
    /// </summary>
    /// <returns>
    /// An instance of <see cref="Jenga{TKey, TValue}"/> which represents clone of current instance
    /// </returns>
    public virtual Jenga<TKey, TValue> Duplicate()
    {
        return new Jenga<TKey, TValue>(this);
    }

    /// <summary>
    /// Function which tries to get exact value out from instance's container
    /// </summary>
    /// <param name="key">
    /// A generic type <typeparamref name="TKey"/> value representing keys in instance's data container
    /// </param>
    /// <param name="value">
    /// A generic type <typeparamref name="TValue"/> value representing value contained in the instance
    /// </param>
    /// <returns></returns>
    public virtual bool TryGetValue(TKey key, out TValue value)
    {
#pragma warning disable CS8601
        return Controllers.TryGetValue(key, out value);
#pragma warning restore CS8601
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.CopyTo(T[], int)"/>
    /// </summary>
    /// <param name="array">
    /// An <see cref="Array"/> of <typeparamref name="TValue"/> which represents array of data in which instance's container will be copied
    /// </param>
    /// <param name="arrayIndex">
    /// A signed 32-bit integer value which represents starting index for copying data into given array
    /// </param>
    public virtual void CopyTo(TValue[] array,
                                    int arrayIndex)
    {
        Controllers.Values.CopyTo(array,
                                  arrayIndex);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{TKey, TValue}.CopyTo(TValue[], int)"/>
    /// </summary>
    /// <param name="array">
    /// An <see cref="Array"/> of <see cref="KeyValuePair{TKey, TValue}"/> which represents array of data in which instance's container will be copied
    /// </param>
    /// <param name="arrayIndex">
    /// <inheritdoc cref="Jenga{TKey, TValue}.CopyTo(TValue[], int)"/>
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when start index is out of range of given array
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when array does not have required capacity to contain instance's container
    /// </exception>
    public virtual void CopyTo(KeyValuePair<TKey, TValue>[] array,
                                                        int arrayIndex)
    {
        if(arrayIndex < 0 ||
            arrayIndex >= array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Invalid start index in copying method of collection wrapper instance.");

        if(array.Length -
            arrayIndex < Controllers.Count)
            throw new ArgumentException($"Not enough space in the array to accommodate all elements starting from the specified index from instance of collection wrapper.");

        int i = arrayIndex;

#pragma warning disable IDE0008
        foreach(var K in Controllers)
        {
            array[i] = K;
            i++;
        }
#pragma warning restore IDE0008
    }

    public static Threadsafe.Jenga<TKey, TValue> Synchronized(Jenga<TKey, TValue> instance)
           => new Threadsafe.Jenga<TKey, TValue>(instance);

    /// <summary>
    /// <inheritdoc cref="Jenga{TKey, TValue}.Push(TKey, TValue)"/>
    /// </summary>
    /// <param name="key">
    /// A generic type <typeparamref name="TKey"/> value representing key for interaction with data in instance's container
    /// </param>
    /// <param name="value">
    /// A generic type <typeparamref name="TValue"/> value representing value of interaction with instance's container
    /// </param>
    /// <exception cref="NotSupportedException">
    /// Thrown via usage
    /// </exception>
    [Obsolete(EXCEPTION_MESSAGE_JENGA_USE, true)]
    public void Add(TKey key, TValue value)
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_JENGA_USE);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Enter(KeyValuePair{long, T})"/>
    /// </summary>
    /// <param name="pair">
    /// <inheritdoc cref="Jenga{TKey, TValue}.Push(KeyValuePair{TKey, TValue})"/>
    /// </param>
    /// <exception cref="NotSupportedException">
    /// Thrown via usage
    /// </exception>
    [Obsolete(EXCEPTION_MESSAGE_JENGA_USE, true)]
    public void Add(KeyValuePair<TKey, TValue> pair)
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_JENGA_USE);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Remove(T)"/>
    /// </summary>
    /// <param name="key">
    /// A generic type <typeparamref name="TKey"/> value representing key for interaction with data in instance's container
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Remove(T)"/>
    /// </returns>
    /// <exception cref="NotSupportedException">
    /// Thrown via usage
    /// </exception>
    [Obsolete(EXCEPTION_MESSAGE_JENGA_USE, true)]
    public bool Remove(TKey key)
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_JENGA_USE);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Exit(KeyValuePair{long, T})"/>
    /// </summary>
    /// <param name="pair">
    /// <inheritdoc cref="Jenga{TKey, TValue}.Push(KeyValuePair{TKey, TValue})"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Exit(KeyValuePair{long, T})"/>
    /// </returns>
    /// <exception cref="NotSupportedException">
    /// Thrown via usage
    /// </exception>
    [Obsolete(EXCEPTION_MESSAGE_JENGA_USE, true)]
    public bool Remove(KeyValuePair<TKey, TValue> pair)
    {
        throw new NotSupportedException(EXCEPTION_MESSAGE_JENGA_USE);
    }

    /// <summary>
    /// Method which adds default value by given key
    /// </summary>
    /// <param name="key">
    /// A generic type <typeparamref name="TKey"/> value representing key for interaction with data in instance's container
    /// </param>
    [Obsolete("Entering default for generic type value cause exceptions in case of custom dictionary, usage of this method can cause exceptions.")]
    public virtual void Enter(TKey key)
    {
#pragma warning disable CS8604
            Enter(key, default);
#pragma warning restore CS8604
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{TKey, TValue}.Add(TKey, TValue)"/>
    /// </summary>
    /// <param name="key">
    /// <inheritdoc cref="Jenga{TKey, TValue}.Enter(TKey)"/>
    /// </param>
    /// <param name="value">
    /// A generic type <typeparamref name="TValue"/> value representing value of interaction with instance's container
    /// </param>
    public virtual void Enter(TKey key, TValue value)
    {
        Push(key, value);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{TKey, TValue}.Enter(TKey, TValue)"/> and replaces old value into new position
    /// </summary>
    /// <param name="key">
    /// <inheritdoc cref="Jenga{TKey, TValue}.Enter(TKey)"/>
    /// </param>
    /// <param name="value">
    /// A generic type <typeparamref name="TValue"/> value representing value of interaction with instance's container
    /// </param>
    /// <param name="append_key">
    /// A generic type <typeparamref name="TKey"/> value representing key for new insert interaction into instance's container
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown when appending key in instance's container has any form of data in it
    /// </exception>
    public virtual void Enter(TKey key, TValue value, TKey append_key)
    {
        if(!Controllers.ContainsKey(key))
            Enter(key, value);
        else
        {
#pragma warning disable CA1854
            /* Since we checking in one time both parameters from method and instance
             * simultaneously we're required to force double find method */
            if (Controllers.ContainsKey(append_key) && !EqualityComparer<TValue>.Default.Equals(Controllers[append_key], default))
                throw new ArgumentException("Can't set existing in current instance of jenga key as append key for case of updating existing key situation.", nameof(append_key));
#pragma warning restore CA1854

            TValue temp = Controllers[key];

            Controllers[key]= value;

            /* Using infinite appendable tower logic for current instance of jenga. */
            Enter(append_key, temp);
        }
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Enter(KeyValuePair{long, T})"/>
    /// </summary>
    /// <param name="pair">
    /// <inheritdoc cref="Jenga{TKey, TValue}.Push(KeyValuePair{TKey, TValue})"/>
    /// </param>
    public virtual void Enter(KeyValuePair<TKey, TValue> pair)
    {
        Enter(pair.Key,
              pair.Value);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{TKey, TValue}.Enter(KeyValuePair{TKey, TValue})"/>
    /// </summary>
    /// <param name="pair">
    /// <inheritdoc cref="Jenga{TKey, TValue}.Push(KeyValuePair{TKey, TValue})"/>
    /// </param>
    /// <param name="append_key">
    /// A generic type <typeparamref name="TKey"/> value representing key for new insert interaction into instance's container
    /// </param>
    public virtual void Enter(KeyValuePair<TKey, TValue> pair, TKey append_key)
    {
        Enter(pair.Key,
              pair.Value, append_key);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.GetEnumerator()"/>
    /// </summary>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.GetEnumerator()"/>
    /// </returns>
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
                                    => Controllers.GetEnumerator();

    /// <summary>
    /// Method which returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="IEnumerator"/> which can be used to iterate through the collection.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
             => Controllers.GetEnumerator();

    /// <summary>
    /// Index accessor for get-set pair of executors for this instance
    /// </summary>
    /// <param name="key">
    /// A generic type <typeparamref name="TKey"/> value representing index of item in the instance's container
    /// </param>
    /// <returns>
    /// A generic type <typeparamref name="TValue"/> value representing value contained in the instance
    /// </returns>
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

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.ContainsKey(long)"/>
    /// </summary>
    /// <param name="key">
    /// A generic type <typeparamref name="TKey"/> value representing key for interaction with data in instance's container
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Contains(long, T)"/>
    /// </returns>
    public bool ContainsKey(TKey key)
    {
        return Controllers.ContainsKey(key);
    }

    /// <summary>
    /// Function which checks does instance's container holds given value
    /// </summary>
    /// <param name="value">
    /// A generic type <typeparamref name="TValue"/> value representing input into the instance
    /// </param>
    /// <returns>
    /// Boolean parameter which indicates does given value is container in the instance
    /// </returns>
    public virtual bool Contains(TValue value)
    {
        return Controllers.ContainsValue(value);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.ContainsValue(T)"/>
    /// </summary>
    /// <param name="value">
    /// A generic type <typeparamref name="TValue"/> value representing value of interaction with instance's container
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.ContainsValue(T)"/>
    /// </returns>
    public bool ContainsValue(TValue value)
    {
        return Controllers.ContainsValue(value);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Contains(long, T)"/>
    /// </summary>
    /// <param name="key">
    /// <inheritdoc cref="Jenga{TKey, TValue}.ContainsKey(TKey)"/>
    /// </param>
    /// <param name="value">
    /// <inheritdoc cref="Jenga{TKey, TValue}.ContainsValue(TValue)"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Contains(long, T)"/>
    /// </returns>
    public bool Contains(TKey key, TValue value)
    {
        return Controllers.ContainsKey(key) &&
               Controllers.ContainsValue(value);
    }

    /// <summary>
    /// <inheritdoc cref="Jenga{T}.Contains(KeyValuePair{long, T})"/>
    /// </summary>
    /// <param name="pair">
    /// <inheritdoc cref="Jenga{T}.Contains(KeyValuePair{long, T})"/>
    /// </param>
    /// <returns>
    /// <inheritdoc cref="Jenga{T}.Contains(KeyValuePair{long, T})"/>
    /// </returns>
    public bool Contains(KeyValuePair<TKey, TValue> pair)
    {
        return Controllers.Contains(pair);
    }
}
