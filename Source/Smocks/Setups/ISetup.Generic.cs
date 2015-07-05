﻿#region License
//// The MIT License (MIT)
//// 
//// Copyright (c) 2015 Tom van der Kleij
//// 
//// Permission is hereby granted, free of charge, to any person obtaining a copy of
//// this software and associated documentation files (the "Software"), to deal in
//// the Software without restriction, including without limitation the rights to
//// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
//// the Software, and to permit persons to whom the Software is furnished to do so,
//// subject to the following conditions:
//// 
//// The above copyright notice and this permission notice shall be included in all
//// copies or substantial portions of the Software.
//// 
//// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
//// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
//// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
//// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;

namespace Smocks.Setups
{
    /// <summary>
    /// A setup for an expression that can be used to configure the behaviour
    /// and/or expectations for the target of the setup.
    /// </summary>
    /// <typeparam name="TReturnValue">The type of the return value.</typeparam>
    public partial interface ISetup<in TReturnValue> : ISetup
    {
        /// <summary>
        /// Configures a constant return value.
        /// </summary>
        /// <param name="returnValue">The return value.</param>
        /// <returns>
        /// The setup for fluent chaining.
        /// </returns>
        ISetup<TReturnValue> Returns(TReturnValue returnValue);

        /// <summary>
        /// Configures a generated return value.
        /// </summary>
        /// <param name="returnValue">The return value.</param>
        /// <returns>
        /// The setup for fluent chaining.
        /// </returns>
        ISetup<TReturnValue> Returns(Func<TReturnValue> returnValue);
    }
}