using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.Extensions.Configuration;

using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace ex1.Components
{
    public class Five
    {
        public int Id { get; set; }

        [Required]
        public string Note { get; set; }
    }

    public interface IFiveRepositry
    {
        Five Add(Five model);
        List<Five> GetAll();
        Five GetById(int id);
        Five Update(Five model);
        void Remove(int id);

        List<Five> GetAllWithPaging(int pageIndex, int pageSize = 10);
    }

    public class FiveRepository : IFiveRepositry
    {
        private IConfiguration _configure;
        private IDbConnection _db;

        public FiveRepository(IConfiguration configure)
        {
            _configure = configure;
            var connectionString = _configure.GetConnectionString("DefaultConnection");
            _db = new MySqlConnection(connectionString);
        }

        private MySqlConnection _GetConnection()
        {
            var connectionString = _configure.GetConnectionString("DefaultConnection");
            return new MySqlConnection(connectionString);
        }

        public Five Add(Five model)
        {
            throw new NotImplementedException();
        }

        public List<Five> GetAll()
        {
            var list = new List<Five>();

            string sql = "SELECT * FROM five order by id desc";

            // Raw 버전
            /*
            using(var connection = _GetConnection())
            {
                connection.Open();

                var cmd = new MySqlCommand(sql, connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(new Five()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Note = reader["note"].ToString()
                        });
                    }
                }

                connection.Close();
            }

            return list;
            */

            // Dapper 버전
            return _db.Query<Five>(sql).ToList();
        }

        public Five GetById(int id)
        {
            throw new NotImplementedException();
        }


        public Five Update(Five model)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public List<Five> GetAllWithPaging(int pageIndex, int pageSize = 10)
        {
            throw new NotImplementedException();
        }
    }
}
