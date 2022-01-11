using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SweetnSaltyDbAccess
{
    public class SweetnSaltyDbAccessClass : ISweetnSaltyDbAccessClass
    {
        private readonly string str = "data source:DESKTOP-MGG67M3\\SQLEXPRESS; database = SweetnSalty; integrated security = SSPI";
        private readonly SqlConnection _con;

        //constructor
        public SweetnSaltyDbAccessClass()
        {
            this._con = new SqlConnection(this.str);
            _con.Open();
        }

        public async Task<SqlDataReader> PostFlavor(string flavorname)
        {
            string sqlQuery = $"INSERT INTO Flavor VALUES (@flavorname)";

            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                cmd.Parameters.AddWithValue("@flavorname", flavorname);
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    string retrieveFlavor = "SELECT * FROM Flavor WHERE FlavorID = (SELECT MAX(FlavorID) FROM Flavor)";
                    using(SqlCommand cmd1 = new SqlCommand(retrieveFlavor, this._con))
                    {
                        SqlDataReader dr = await cmd1.ExecuteReaderAsync();
                        return dr;
                    }
                }
                catch(DbException ex)
                {
                    Console.WriteLine("exception in PostFlavor(DbAccess)");
                    return null;
                }
            }
        }

        //POST a person who likes a flavor 
        public async Task<SqlDataReader> PostPerson(string fname, string lname)
        {
            string sqlQuery = $"INSERT INTO Person(FirstName, LastName) VALUES (@firstname, @lastname)";

            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                cmd.Parameters.AddWithValue("@firstname", fname);
                cmd.Parameters.AddWithValue("@lastname", lname);
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    string retrievePerson = "SELECT * FROM Person WHERE PersonID = (SELECT MAX(PersonID) FROM Person)";
                    using (SqlCommand cmd1 = new SqlCommand(retrievePerson, this._con))
                    {
                        SqlDataReader dr = await cmd1.ExecuteReaderAsync();
                        return dr;
                    }
                }
                catch (DbException ex)
                {
                    Console.WriteLine("exception in PostPerson(DbAccess)");
                    return null;
                }
            }
        }

        /*POST a person who likes a flavor 
        -- GET a person and their liked flavors by id.
        string sqlQuery = $"SELECT PersonID, FlavorName FROM PersonFlavorJunction pfj LEFT JOIN Flavor f ON pfj.FlavorID = f.FlavorID WHERE PersonID = {id}";
        -- GET a list of flavors available.
        string sqlQuery = "SELECT FlavorName FROM Flavor";
         */

        //-- GET a person by name.
        public async Task<SqlDataReader> GetPersonByName(string fName, string lName)
        {
            string sqlQuery = $"SELECT Person WHERE FirstName LIKE {fName} LastName LIKE {lName})";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, this._con);
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
            }
            catch(DbException ex)
            {
                Console.WriteLine("can't find in Db for GetPersonByName(DbAccess)");
                return null;
            }
        }

        //-- GET a list of flavors available.

        public async Task<SqlDataReader> GetAllFlavors()
        {
            string sqlQuery = "SELECT FlavorName FROM Flavor";
            SqlCommand cmd = new SqlCommand(sqlQuery, this._con);
            SqlDataReader dr = await cmd.ExecuteReaderAsync();
            return dr;
        }
    }
}
