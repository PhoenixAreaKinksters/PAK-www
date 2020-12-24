using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using PAK_www.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAK_www.Models.Admin
{
    public class EditPerson
    {
        private IConfiguration _configuration;
        public EditPerson(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int? PersonId { get; set; }
        private Person _currentPerson { get; set; }
        public Person CurrentPerson
        {
            get
            {
                if (_currentPerson == null && PersonId.HasValue)
                {
                    try
                    {
                        using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                        {
                            _currentPerson = cn.QueryFirst<Person>("spSearchPeople", new { ID = PersonId, Name = (string)null, Email = (string)null, ShowAll = 0}, commandType: System.Data.CommandType.StoredProcedure);
                        }
                    }
                    catch
                    {

                    }
                }
                return _currentPerson;
            }
            set
            {
                _currentPerson = value;
            }
        }

        public int SavePerson()
        {
            try
            {
                using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                {
                    if (CurrentPerson.PersonId == 0)
                    {
                        CurrentPerson.PersonId = cn.QueryFirst<int>("spAddPerson", new { CurrentPerson.LegalName, CurrentPerson.SceneName, CurrentPerson.Email, CurrentPerson.Birthday }, commandType: System.Data.CommandType.StoredProcedure);
                    }
                    else
                    {
                        var updated = (cn.Execute("spEditPerson", CurrentPerson, commandType: System.Data.CommandType.StoredProcedure) == 1);
                        if (!updated)
                        {
                            CurrentPerson.PersonId = 0;
                        }
                    }
                }
            }
            catch
            {
                CurrentPerson.PersonId = 0;
            }
            return CurrentPerson.PersonId;
        }

        public bool DeletePerson()
        {
            var success = false;
            if (PersonId > 0)
            {
                try
                {
                    using (var cn = new MySqlConnection(_configuration.GetConnectionString("PAK")))
                    {
                        success = (cn.Execute("spDeletePerson", new { ID = PersonId }, commandType: System.Data.CommandType.StoredProcedure) == 1);
                    }
                }
                catch
                {

                }
            }
            return success;
        }
    }
}
