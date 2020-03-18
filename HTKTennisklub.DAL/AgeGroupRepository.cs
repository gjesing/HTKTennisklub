using HTKTennisklub.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTKTennisklub.DAL
{
    public class AgeGroupRepository : BaseRepository
    {
        /// <summary>
        /// Retrieves all AgeGroups from the database.
        /// </summary>
        /// <returns>A List of all AgeGroups</returns>
        public List<AgeGroup> GetAgeGroups() => HandleData(ExecuteQuery("SELECT * FROM AgeGroups ORDER BY MinAge"));

        /// <summary>
        /// Helper method used to convert DataTable to list of AgeGroups.
        /// </summary>
        /// <param name="dataTable">The DataTable to be converted to list of AgeGroups</param>
        /// <returns>A list of AgeGroups from the database (empty list if the parameter is null)</returns>
        private List<AgeGroup> HandleData(DataTable dataTable)
        {
            List<AgeGroup> ageGroups = new List<AgeGroup>();
            if (dataTable is null) return ageGroups;
            dataTable.Rows.Cast<DataRow>().ToList().ForEach(row =>
            {
                ageGroups.Add(new AgeGroup()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    MinAge = (byte)row["MinAge"],
                    MaxAge = (byte)row["MaxAge"]
                });
            });
            return ageGroups;
        }
    }
}
