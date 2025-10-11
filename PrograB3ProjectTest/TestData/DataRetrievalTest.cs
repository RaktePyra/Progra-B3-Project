using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrograB3Project;
using PrograB3Project.Components;
using PrograB3Project.Data;
namespace PrograB3ProjectTest.TestData
{
    public class DataRetrievalTest
    {
        private GenericDataBase _dataBase;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void FileNotFoundTest()
        {
            _dataBase = new GenericDataBase();
            Assert.Throws<FileNotFoundException>(()=>_dataBase.LoadDataFromCSV("error"));
        }

        [Test]

        public void RetrievalOfDataTest()
        {
            _dataBase = new GenericDataBase();
            _dataBase.LoadDataFromCSV("../../../TestData/TestData.csv");
            Assert.That(_dataBase.GetData().Count, Is.EqualTo(1));
        }
    }
}
