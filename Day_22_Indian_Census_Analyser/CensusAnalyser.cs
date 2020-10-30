using Day_22_Indian_Census_Analyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day_22_Indian_Census_Analyser
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA, USA
        }
        public Dictionary<string, CensusDTO> datamap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            datamap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return datamap;
        }
    }
}
