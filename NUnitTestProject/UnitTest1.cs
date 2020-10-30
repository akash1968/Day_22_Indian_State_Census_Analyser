using NUnit.Framework;
using System.Collections.Generic;
using Day_22_Indian_Census_Analyser;
using Day_22_Indian_Census_Analyser.DTO;

namespace NUnitTestProject
{
    public class Tests
    {
        //header definition stored in a string
        public static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
       // TC.2.1 File Path
        public static string indianStateCensusFilePath = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV\IndiaStateCensusData.csv";
        public static string indianStateCodeFilePath = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV\IndiaStateCode.csv";
        // TC 2.2 Wrong File Path
        public static string wrongIndianStateCensusFilePath = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV1\IndiaStateCensusData.csv";
        public static string wrongindianStateCodeFilePath = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV1\IndiaStateCode.csv";
        // TC 2.3 Wrong File Type
        public static string wrongIndianStateCensusFileType = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\IndiaStateCensusData.txt";
        public static string wrongIndianStateCodeFileType = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\IndiaStateCode.txt";
        // TC 2.4 Incorrect Delimeter        
        public static string wrongDelimeterIndianStateCensusFilePath = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV\DelimiterIndiaStateCensusData.csv";
        public static string wrongDelimeterIndianStateCodeFilePath= @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV\DelimiterIndiaStateCode.csv";
        // TC 2.5 Incorrect Header
        public static string wrongHeaderIndianStateCensusFilePath = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV\WrongIndiaStateCensusData.csv";
        public static string wrongHeaderIndianStateCodeFilePath = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV\WrongIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        // Initialising the instance of the Class objects
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        // TC 1.1 - To get the records and to assert whether the count of all the records matches to manually addressed or not
        // Using the Dictionary Collection to store the Indian State Census Records and then Count it
        [Test]
        public void GivenIndianStateDataCensus_ReturnsCorrectCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        // TC 1.2 - To pass a wrong file path and assert whether the custom exception of file not found is returned or not
        [Test]
        public void GivenWrongFile_ShouldReturnCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, indianStateCensusResult.exception);
        }

        // TC 1.3 - To pass a wrong file type and the correct file name and assert whether the custom exception of file not found is returned or not        
        [Test]
        public void GivenWrongFileType_ShouldReturnCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, indianStateCensusResult.exception);
        }

        // TC 1.4 : Given the state census CSV file when correct but delimeter incorrect should throw custom exception.
        [Test]
        public void GivenStateCensusCSVFileWhenCorrectButDelimeterIncorrect_ShouldThrowCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongDelimeterIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_DELIMITER, indianStateCensusResult.exception);
        }

        // TC 1.5 - To pass a wrong header in the Indian Census File and the correct file name and assert whether the custom exception of incorrect header is returned or not
        [Test]
        public void GivenWrongHeader_ShouldReturnCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_HEADER, indianStateCensusResult.exception);
        }

        // TC 2.1 : Given the indian state code data file when read should return data count.
        [Test]
        public void GivenIndianStateCodeDataFile_WhenRead_ShouldReturnDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        // TC 2.2 : Given the wrong file path for indian state code data file should throw custom exception.
        [Test]
        public void GivenWrongIndianStateCodeDataFile_ShouldThrowCustomException()
        {
            var stateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongindianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, stateCodeResult.exception);
        }

        // TC 2.3 : Given the wrong indian state code data file type should throw custom exceotion.
        [Test]
        public void GivenWrongIndianStateCodeDataFileType_ShouldThrowCustomExceotion()
        {
            var stateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, stateCodeResult.exception);
        }

        // TC 2.4 : Given the state census CSV file when correct but delimeter incorrect should throw custom exception.
        [Test]
        public void GivenStateCodeCSVFileWhenCorrectButDelimeterIncorrect_ShouldThrowCustomException()
        {
            var stateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongDelimeterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_DELIMITER, stateCodeResult.exception);
        }

        // TC 2.5 : Given the state census CSV file when correct but CSV header incorrect should throw custom exception.
        [Test]
        public void GivenStateCodeCSVFileWhenCorrectButCSVHeaderIncorrect_ShouldThrowCustomException()
        {
            var stateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_HEADER, stateCodeResult.exception);
        }
    }
}