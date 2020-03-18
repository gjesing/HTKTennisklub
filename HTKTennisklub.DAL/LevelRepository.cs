using HTKTennisklub.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTKTennisklub.DAL
{
    public class LevelRepository : BaseRepository
    {
        /// <summary>
        /// Retrieves all Levels from the database.
        /// </summary>
        /// <returns>A List of all Levels</returns>
        public List<Level> GetLevels() => HandleData(ExecuteQuery("SELECT * FROM Levels ORDER BY BasePoints"));

        /// <summary>
        /// Gets Level from the database where Name is equal to the specified string.
        /// </summary>
        /// <param name="name">The string to search for in the Level Names</param>
        /// <returns>Level with the specified string as Name</returns>
        public Level GetLevel(string name) => HandleDataRow(ExecuteQuery($"SELECT TOP 1 * FROM Levels WHERE Name='{name}'"));

        /// <summary>
        /// Helper method used to convert DataTable to list of Levels.
        /// </summary>
        /// <param name="dataTable">The DataTable to be converted to list of Levels</param>
        /// <returns>A list of Levels from the database (empty list if the parameter is null)</returns>
        private List<Level> HandleData(DataTable dataTable)
        {
            List<Level> levels = new List<Level>();
            if (dataTable is null) return levels;
            dataTable.Rows.Cast<DataRow>().ToList().ForEach(row =>
            {
                levels.Add(new Level()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    BasePoints = (byte)row["BasePoints"]
                });
            });
            return levels;
        }

        /// <summary>
        /// Helper method used to convert first Row in DataTable to a Level.
        /// </summary>
        /// <param name="dataTable">The DataTable of which the first Row should be converted to a Level</param>
        /// <returns>A Level from the database (null if the parameter is null)</returns>
        private Level HandleDataRow(DataTable dataTable)
        {
            if (dataTable is null) return null;
            DataRow row = dataTable.Rows[0];
            return new Level()
            {
                Id = (int)row["Id"],
                Name = (string)row["Name"],
                BasePoints = (byte)row["BasePoints"]
            };
        }
    }
}
