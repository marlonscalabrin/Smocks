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
    public interface ISetup
    {
        /// <summary>
        /// Configures an exception that will be thrown when
        /// the target of the setup is invoked.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        void Throws<TException>() where TException : Exception, new();

        /// <summary>
        /// Configures an exception that will be thrown when
        /// the target of the setup is invoked.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="exception">The that will be thrown.</param>
        void Throws<TException>(TException exception) where TException : Exception;

        /// <summary>
        /// Marks this setup as verifiable. If the <see cref="ISmocksContext.Verify"/>
        /// method is invoked after marking the setup as verifiable  and the target of
        /// the setup has never been invoked, an exception will be thrown.
        /// </summary>
        void Verifiable();
    }
}