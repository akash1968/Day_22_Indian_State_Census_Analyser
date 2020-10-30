using Day_22_Indian_Census_Analyser.DataDAO;
using Day_22_Indian_Census_Analyser.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_22_Indian_Census_Analyser
{
   public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> datamap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            datamap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Containers Wrong Delimiter", CensusAnalyserException.Exception.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    datamap.Add(column[1], new CensusDTO(new StateCodeDataDAO(column[0], column[1], column[2], column[3])));
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    datamap.Add(column[1], new CensusDTO(new CensusDataDAO(column[0], column[1], column[2], column[3])));
            }
            return datamap.ToDictionary(records => records.Key, records => records.Value);
        }

    }
}