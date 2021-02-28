using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;

namespace PAK_www.Models.Admin
{
    public class EditPersonNotes
    {
        private IConfiguration _configuration;
        public EditPersonNotes(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public EditPersonNotesForm Form { get; set; }

        public int? PersonId { get; set; }

        private string _notes { get; set; }
        public string Notes 
        {
            get
            {
                if (_notes == null && PersonId.HasValue)
                {
                    try
                    {
                        using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                        {
                            _notes = cn.QueryFirst<string>("spGetPersonNotes", new { PersonId }, commandType: System.Data.CommandType.StoredProcedure);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                return _notes;
            }

            set
            {
                _notes = value;
            }
        }

        public bool SaveNotes()
        {
            var success = false;
            try
            {
                using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                {
                    success = cn.Execute("spEditPersonNotes", Form, commandType: System.Data.CommandType.StoredProcedure) == 1;
                }
            }
            catch (Exception ex)
            {

            }
            return success;
        }
    }
}
