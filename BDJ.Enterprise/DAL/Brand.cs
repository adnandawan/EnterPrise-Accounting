using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Brand:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       
        public bool Insert()
        {

            Command = CommandBuilder(@"insert into brand(name,description) values(@name, @description)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( @"Update brand set name = @name, description =@description where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
       

            Command = CommandBuilder(@"Delete from brand where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( @"select id,name, description from brand where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["description"].ToString();
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS("select id,name, description from brand");

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table brand(id int identity primary key, name varchar(200) 
                                    unique not null, description varchar(50))");
            return ExecuteNQ(Command);
        }
    }
}
