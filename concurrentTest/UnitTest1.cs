using NUnit.Framework;
using System.Windows.Controls;
using System.Threading;
using concurrent;
namespace concurrentTest
{
    public class Tests
    {
        private MainWindow window;
        private TextBlock textBlock;
        
        [SetUp]
        public void Setup()
        {
            window = new MainWindow();
            window.Show();
            textBlock = window.FindName("Text") as TextBlock;
        }

        [Test]
        public void Test1()
        {
            Assert.That(textBlock.Text, Is.EqualTo("Hello World!!!"));
        }

        [TearDown] public void TearDown() { window.Close(); }
    }
}