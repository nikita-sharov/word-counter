using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
                throw new NotImplementedException();
            }).ContinueWith((t) =>
            {
                // ignore
            }, TaskScheduler.Default);
        }
    }
}
