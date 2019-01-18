using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.utils;
using Xunit;

namespace ConsoleTest.test_cases
{
    public class TestLog
    {        
        [Fact]
        public void Run()
        {
            SLogger.Info("just for test info");
            SLogger.Err("just for test err");
            SLogger.Debug("just for test debug");
            SLogger.Fatal("just for test fatal");
            SLogger.Warn("just for test warn");
        }
    }
}
