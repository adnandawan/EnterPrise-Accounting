using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
     class City:MyBase, IDatabase
    {
        
           
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public bool Dispose()
        {
            return true;

        }
   
        public bool Insert()
        {

           
            Command = CommandBuilder("insert into city(name, countryId) values(@name, @countryId)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@countryId", CountryId);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


            Command = CommandBuilder("Update city set name = @name, countryId = @countryId where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@countryId", CountryId);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
       

            Command = CommandBuilder ("Delete from city where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {

            Command = CommandBuilder("select id,name, countryId from city where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                CountryId = Convert.ToInt32(Reader["countryId"]);
                Reader.Close();
              
                return true;
            }
            Reader.Close();
       
            return false;

        }

        public DataSet Select()
        {
            return ExecuteDS("select city.id,city.name, country.name as country from city left join country on city.countryId = country.id");

        }

        public bool Table()
        {
            Command = CommandBuilder("create table city(id int identity primary key, name varchar(200) not null), countryId int not null, foreign key(countryId) references country(Id)");
            return ExecuteNQ(Command);
        }
    }
}
