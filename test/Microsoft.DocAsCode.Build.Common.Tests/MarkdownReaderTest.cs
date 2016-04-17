﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.DocAsCode.Build.Common.Tests
{
    using System;
    using System.IO;

    using Xunit;

    public class MarkdownReaderTest
    {
        [Fact]
        public void TestReadMarkdownAsOverwrite()
        {
            const string Content = @"---
uid: Test
remarks: Hello
---

This is unit test!";
            const string FileName = "ut_ReadMarkdownAsOverwrite.md";
            File.WriteAllText(FileName, Content);
            var results = MarkdownReader.ReadMarkdownAsOverwrite(Environment.CurrentDirectory, FileName);
            Assert.NotNull(results);
            Assert.Equal(1, results.Count);
            Assert.Equal("Test", results[0].Uid);
            Assert.Equal("Hello", results[0].Metadata["remarks"]);
            Assert.Equal(@"
This is unit test!", results[0].Conceptual);
            File.Delete(FileName);
        }
    }
}
