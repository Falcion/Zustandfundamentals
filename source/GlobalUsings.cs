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

global using global::System;
global using global::System.Collections;
global using global::System.Collections.Generic;
global using global::System.Linq;

global using static Zustandf.CONSTS;

using Zustandf.Data.Models;

namespace Zustandf;

/// <summary>
/// Global container for system consts and other static data
/// </summary>
internal static class CONSTS
{
    /// <summary>
    /// String parameter of charseq which represents message of <see cref="NotSupportedException"/> in instances of <see cref="IData"/>
    /// </summary>
    public const string EXCEPTION_MESSAGE_DATA_EVEN = "Data instance supports this interaction method only for even-counted parameters instances.";

    public const string EXCEPTION_MESSAGE_JENGA_EMPTY = "Empty instance of collection wrapper can't interact with it's data.";

    public const string EXCEPTION_MESSAGE_JENGA_USE = "An instance of jenga wrapper acts as collection, but not interacts as it, instead use custom provided functionality or analogs of it.";

    public const string EXCEPTION_MESSAGE_JENGA_OUT_OF_RANGE = "Given argument {0} is out of range of collection's instance";
}
