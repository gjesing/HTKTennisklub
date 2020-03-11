using HTKTennisklub.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTKTennisklub.DAL
{
    public class MemberRepository : BaseRepository
    {
        /// <summary>
        /// Retrieves all Members from the database.
        /// </summary>
        /// <returns>A List of all Members</returns>
        public List<Member> GetMembers() => HandleData(ExecuteQuery($"SELECT * FROM Members JOIN AgeGroups ON AgeGroups.Id = Members.AgeGroupId JOIN Levels ON Levels.Id = Members.LevelId"));

        /// <summary>
        /// Inserts Member into database.
        /// </summary>
        /// <param name="member">The member to be inserted into the database</param>
        public void InsertMember(Member member) => ExecuteNonQuery($"INSERT INTO Members VALUES ('{member.FirstName}', '{member.LastName}', '{member.Address}', '{member.PhoneNumber}', '{member.Email}', {member.BirthDate}, {member.Gender}, {member.AgeGroup.Id}, {member.Level.Id}, 1)");

        /// <summary>
        /// Updates the specified Member in the database.
        /// </summary>
        /// <param name="member">The member to be updated in the database</param>
        public void UpdateMember(Member member) => ExecuteNonQuery($"UPDATE Members SET FirstName='{member.FirstName}', LastName='{member.LastName}', Address='{member.Address}', PhoneNumber='{member.PhoneNumber}', Email='{member.Email}' WHERE Id={member.Id}");

        /// <summary>
        /// Sets IsMember of the specified Member to 0 (false) in the database.
        /// </summary>
        /// <param name="member">The member to be made inactive</param>
        public void MakeMemberInactive(Member member) => ExecuteNonQuery($"UPDATE Members SET IsMember={member.IsMember} WHERE Id={member.Id}");

        /// <summary>
        /// Helper method used to convert DataTable to list of Members.
        /// </summary>
        /// <param name="dataTable">The DataTable to be converted to list of Members</param>
        /// <returns>A list of Members from the database (empty list if the parameter is null)</returns>
        private List<Member> HandleData(DataTable dataTable)
        {
            List<Member> members = new List<Member>();
            if (dataTable is null) return members;
            dataTable.Rows.Cast<DataRow>().ToList().ForEach(row =>
            {
                Member member = new Member()
                {
                    Id = (int)row["Members.Id"],
                    FirstName = (string)row["FirstName"],
                    LastName = (string)row["LastName"],
                    Address = (string)row["Address"],
                    PhoneNumber = (string)row["PhoneNumber"],
                    Email = (string)row["Email"],
                    BirthDate = (DateTime)row["DateTime"],
                    Gender = (Gender)row["Gender"],
                    AgeGroup = new AgeGroup()
                    {
                        Id = (int)row["AgeGroups.Id"],
                        Name = (string)row["AgeGroups.Name"]
                    },
                    Level = new Level()
                    {
                        Id = (int)row["Levels.Id"],
                        Name = (string)row["Levels.Name"],
                        BasePoints = (int)row["BasePoints"]
                    },
                    IsMember = Convert.ToBoolean(row["IsMember"])
                };
                if (row["MinAge"] != DBNull.Value)
                {
                    member.AgeGroup.MinAge = (int)row["MinAge"];
                }
                if (row["MaxAge"] != DBNull.Value)
                {
                    member.AgeGroup.MaxAge = (int)row["MaxAge"];
                }
            });
            return members;
        }
    }
}
