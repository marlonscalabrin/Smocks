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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Moq;
using NUnit.Framework;
using Smocks.AppDomains;
using Smocks.Serialization;

namespace Smocks.Tests.AppDomains
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class SerializableLambdaTests
    {
        private Mock<ISerializer> _serializerMock;

        [TearDown]
        public void AfterTests()
        {
            _serializerMock.Verify();
        }

        [TestCase]
        public void Create_ActionWithoutTarget_SetsMethodOnly()
        {
            var method = typeof(Console).GetMethod("WriteLine", new Type[0]);
            var result = SerializableLambda.Create(Console.WriteLine, _serializerMock.Object);

            Assert.Null(result.TargetType);
            Assert.Null(result.TargetValues);
            Assert.AreEqual(method, result.Method);
        }

        [TestCase]
        public void Create_ActionWithTarget_SetsTypeAndMethodAndSerializesTarget()
        {
            int capturedInt = 42;
            Action lambda = () => Console.WriteLine(capturedInt);

            _serializerMock
                .Setup(serializer => serializer.Serialize(lambda.Target))
                .Returns(new Dictionary<string, object>());

            var result = SerializableLambda.Create(lambda, _serializerMock.Object);

            Assert.NotNull(result.TargetType);
            Assert.AreEqual(lambda.Target.GetType(), result.TargetType);
            Assert.NotNull(result.Method);
            Assert.AreEqual(lambda.Method, result.Method);
        }

        [SetUp]
        public void Setup()
        {
            _serializerMock = new Mock<ISerializer>(MockBehavior.Strict);
        }
    }
}