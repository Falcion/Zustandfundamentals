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
/// An interface which represents common behaviour for data containers
/// </summary>
public interface IData
{
    /// <summary>
    /// An <see cref="Array"/> of <see cref="object"/> which represents parameters of the instance
    /// </summary>
    public object?[] Params { get; }

    /// <summary>
    /// Method which swaps values in instance of data container in even position terms
    /// </summary>
    public void Swap();

    /// <summary>
    /// Method which moves values positions between instance's parameters of data container
    /// </summary>
    public void Move();

    /// <summary>
    /// Method which resets instance's fields to default
    /// </summary>
    public void Nullify();
}
