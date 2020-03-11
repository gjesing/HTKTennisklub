using HTKTennisklub.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTKTennisklub.DAL
{
    public class ClassificationRepository : BaseRepository
    {
        /// <summary>
        /// Retrieves all Classifications from the database.
        /// </summary>
        /// <returns>A List of all Classifications</returns>
        public List<Classification> GetClassifications() => HandleData(ExecuteQuery("SELECT * FROM Classifications"));

        /// <summary>
        /// Helper method used to convert DataTable to list of Classifications.
        /// </summary>
        /// <param name="dataTable">The DataTable to be converted to list of Classifications</param>
        /// <returns>A list of Classifications from the database (empty list if the parameter is null)</returns>
        private List<Classification> HandleData(DataTable dataTable)
        {
            List<Classification> classifications = new List<Classification>();
            if (dataTable is null) return classifications;
            dataTable.Rows.Cast<DataRow>().ToList().ForEach(row =>
            {
                classifications.Add(new Classification()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"]
                });
            });
            return classifications;
        }
    }
}
