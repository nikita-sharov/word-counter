using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Tests
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void Test()
        {
            Task.Run(() =>
            {
                throw new Exception();
            }).ContinueWith((t) =>
            {
                // ignore
            });
        }
    }
}
