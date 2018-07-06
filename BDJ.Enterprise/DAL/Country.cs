using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class Country:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
       
        public bool Insert()
        {

           

            Command = CommandBuilder("insert into country(name) values(@name)");
            Command.Parameters.AddWithValue("@name", Name);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( "Update country set name = @name where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
       

            Command = CommandBuilder("Delete from country where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {

           Command = CommandBuilder( "select id,name from country where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS("select id,name from country");

           

        }

        public bool Table()
        {
            Command = CommandBuilder("create table country(id int identity primary key, name varchar(200) unique not null)");
            return ExecuteNQ(Command);
        }
    }
}
