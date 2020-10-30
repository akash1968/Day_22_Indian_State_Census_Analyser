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
       // TC.1.1 File Path
        public static string indianStateCensusFilePath = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV\IndiaStateCensusData.csv";
        public static string indianStateCodeFilePath = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV\IndiaStateCode.csv";
        // TC 1.2 Wrong File Path
        public static string wrongIndianStateCensusFilePath = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV1\IndiaStateCensusData.csv";
       // TC 1.3 Wrong File Type
        public static string wrongIndianStateCensusFileType = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\IndiaStateCensusData.txt";
       // TC 1.4 Incorrect Delimeter
        public static string wrongDelimeterIndianStateCensusFilePath = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV\DelimiterIndiaStateCensusData.csv";
       // TC 1.5 Incorrect Header
        public static string wrongHeaderIndianStateCensusFilePath = @"C:\Users\Lenovo\source\repos\Day_22_Indian_Census_Analyser\Day_22_Indian_Census_Analyser\CSV\WrongIndiaStateCensusData.csv";
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
        /// <summary>
        /// TC 1.4 : Given the state census CSV file when correct but delimeter incorrect should throw custom exception.
        /// </summary>
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
    }
}