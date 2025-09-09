using pipeline_project;
using System.Diagnostics.CodeAnalysis;

namespace PipelineTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase(3.99, pipeline_project.Type.cheap, "P01", "Test", 1, 0)]
        [TestCase(3.99, pipeline_project.Type.cheap, "P01", "Test", 50, 0)]
        [TestCase(3.99, pipeline_project.Type.cheap, "P01", "Test", 51, 5.00)]
        [TestCase(3.99, pipeline_project.Type.cheap, "P01", "Test", 100, 5.00)]
        [TestCase(3.99, pipeline_project.Type.cheap, "P01", "Test", 101, 10.00)]
        [TestCase(3.99, pipeline_project.Type.cheap, "P01", "Test", 150, 10.00)]
        [TestCase(3.99, pipeline_project.Type.cheap, "P01", "Test", 151, 20.00)]
        [TestCase(3.99, pipeline_project.Type.cheap, "P01", "Test", 2045, 20.00)]
        [TestCase(23.99, pipeline_project.Type.expensive, "P01", "Test", 1, 0)]
        [TestCase(23.99, pipeline_project.Type.expensive, "P01", "Test", 5, 0)]
        [TestCase(23.99, pipeline_project.Type.expensive, "P01", "Test", 6, 3.00)]
        [TestCase(23.99, pipeline_project.Type.expensive, "P01", "Test", 10, 3.00)]
        [TestCase(23.99, pipeline_project.Type.expensive, "P01", "Test", 11, 8.00)]
        [TestCase(23.99, pipeline_project.Type.expensive, "P01", "Test", 20, 8.00)]
        [TestCase(23.99, pipeline_project.Type.expensive, "P01", "Test", 21, 12.00)]
        [TestCase(23.99, pipeline_project.Type.expensive, "P01", "Test", 3856, 12.00)]
        [TestCase(9.99, pipeline_project.Type.basic, "P01", "Test", 1, 0)]
        [TestCase(9.99, pipeline_project.Type.basic, "P01", "Test", 15, 0)]
        [TestCase(9.99, pipeline_project.Type.basic, "P01", "Test", 16, 5.00)]
        [TestCase(9.99, pipeline_project.Type.basic, "P01", "Test", 30, 5.00)]
        [TestCase(9.99, pipeline_project.Type.basic, "P01", "Test", 31, 10.00)]
        [TestCase(9.99, pipeline_project.Type.basic, "P01", "Test", 50, 10.00)]
        [TestCase(9.99, pipeline_project.Type.basic, "P01", "Test", 51, 20.00)]
        [TestCase(9.99, pipeline_project.Type.basic, "P01", "Test", 5555, 20.00)]
        public void TestMarketingDetermineRate(double cost, pipeline_project.Type type, string id, string product, int quantity, double expectedRate)
        {
            pipeline_project.Marketing marketObj = new pipeline_project.Marketing(cost, type, id, product, quantity);

            Assert.That(expectedRate, Is.EqualTo(marketObj.DetermineRate()));
        }
    }
}