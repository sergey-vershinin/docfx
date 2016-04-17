﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.DocAsCode.MarkdownLite.Tests
{
    using System.Collections.Generic;

    using Microsoft.DocAsCode.MarkdownLite;

    using Xunit;

    public class StringBufferTest
    {
        [Theory]
        [Trait("Related", "Markdown")]
        [InlineData(new string[0], "")]
        [InlineData(new string[] { "a", "b" }, "ab")]
        [InlineData(new string[] { "", "a", "b", "c", "", "d", null }, "abcd")]
        public void TestStringBuffer_Append(string[] inputs, string expected)
        {
            var sb = StringBuffer.Empty;
            foreach (var input in inputs)
            {
                sb += input;
            }
            Assert.Equal(expected, sb.ToString());
        }

        [Theory]
        [Trait("Related", "Markdown")]
        [InlineData(new string[0], 'a', false)]
        [InlineData(new string[] { "a", "b" }, 'a', true)]
        [InlineData(new string[] { "a", "b" }, 'b', false)]
        [InlineData(new string[] { "", "a", "b", "c", "", "d", null }, 'a', true)]
        [InlineData(new string[] { "", "a", "b", "c", "", "d", null }, 'b', false)]
        public void TestStringBuffer_StartsWith_Char(string[] inputs, char character, bool expected)
        {
            var sb = StringBuffer.Empty;
            foreach (var input in inputs)
            {
                sb += input;
            }
            Assert.Equal(expected, sb.StartsWith(character));
        }

        [Theory]
        [Trait("Related", "Markdown")]
        [InlineData(new string[0], "", true)]
        [InlineData(new string[0], "abc", false)]
        [InlineData(new string[] { "a", "b" }, "", true)]
        [InlineData(new string[] { "a", "b" }, "ab", true)]
        [InlineData(new string[] { "a", "b" }, "abc", false)]
        [InlineData(new string[] { "", "a", "b", "c", "", "d", null }, "abc", true)]
        [InlineData(new string[] { "", "a", "b", "c", "", "d", null }, "bc", false)]
        public void TestStringBuffer_StartsWith_String(string[] inputs, string character, bool expected)
        {
            var sb = StringBuffer.Empty;
            foreach (var input in inputs)
            {
                sb += input;
            }
            Assert.Equal(expected, sb.StartsWith(character));
        }

        [Theory]
        [Trait("Related", "Markdown")]
        [InlineData(new string[0], 'a', false)]
        [InlineData(new string[] { "a", "b" }, 'a', false)]
        [InlineData(new string[] { "a", "b" }, 'b', true)]
        [InlineData(new string[] { "", "a", "b", "c", "", "d", null }, 'd', true)]
        [InlineData(new string[] { "", "a", "b", "c", "", "d", null }, 'b', false)]
        public void TestStringBuffer_EndsWith_Char(string[] inputs, char character, bool expected)
        {
            var sb = StringBuffer.Empty;
            foreach (var input in inputs)
            {
                sb += input;
            }
            Assert.Equal(expected, sb.EndsWith(character));
        }

        [Theory]
        [Trait("Related", "Markdown")]
        [InlineData(new string[0], "", true)]
        [InlineData(new string[0], "abc", false)]
        [InlineData(new string[] { "a", "b" }, "", true)]
        [InlineData(new string[] { "a", "b" }, "ab", true)]
        [InlineData(new string[] { "a", "b" }, "abc", false)]
        [InlineData(new string[] { "", "a", "b", "c", "", "d", null }, "bcd", true)]
        [InlineData(new string[] { "", "a", "b", "c", "", "d", null }, "abc", false)]
        public void TestStringBuffer_EndsWith_String(string[] inputs, string character, bool expected)
        {
            var sb = StringBuffer.Empty;
            foreach (var input in inputs)
            {
                sb += input;
            }
            Assert.Equal(expected, sb.EndsWith(character));
        }

    }
}
