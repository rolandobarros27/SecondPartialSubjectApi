using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Infraestructure.Repository
{
    public class SubjectRepository
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public SubjectRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.connection = new Npgsql.NpgsqlConnection(this._connectionString);
        }

        public string insert(SubjectModel subject)
        {
            try
            {
                String query = "insert into subject(name, lastname, email, document_type, telephone, document, address, status) " +
                     " values(@name, @lastname, @email, @document_type, @telephone, @document, @address, @status)";
                connection.Open();
                connection.Execute(query, subject);
                connection.Close();

                return "Se inserto correctamente...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string modify(SubjectModel subject, int id)
        {
            try
            {
                connection.Execute($"UPDATE subject SET " +
                    "name = @name, " +
                    "lastname = @lastname, " +
                    "email = @email, " +
                    "telephone = @telephone, " +
                    "document_type = @document_type, " +
                    "document = @document, " +
                    "address = @address, " +
                    "status = @status, " +

                    $"WHERE id = {id}", subject);
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string delete(int id)
        {
            try
            {
                connection.Execute($" DELETE FROM subject WHERE id = {id}");
                return "Se eliminó correctamente el registro...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SubjectModel getById(int id)
        {
            try
            {
                return connection.QueryFirst<SubjectModel>($"SELECT * FROM subject WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SubjectModel> read()
        {
            try
            {
                // get all subjects
                return connection.Query<SubjectModel>("SELECT * FROM subject");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
