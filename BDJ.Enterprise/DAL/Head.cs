using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class Head:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HeadId { get; set; }
       
        public bool Insert()
        {
            string param = "";
            string field = "";
            Command = CommandBuilder("");
            Command.Parameters.AddWithValue("name", Name);
            Command.Parameters.AddWithValue("description", Description);

            if(HeadId > 0)
            {
                param = ", @headId";
                field = ", headId";
                Command.Parameters.AddWithValue("headId", HeadId);
            }
            Command.CommandText = string.Format("insert into Head(name,description{0}) values(@name, @description{1})", field, param);
            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( "Update Head set name = @name,description = @description,headId = @headId where id = @id");
            Command.Parameters.AddWithValue("id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("description", Description);
            Command.Parameters.AddWithValue("@headId", HeadId);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
       

            Command = CommandBuilder("Delete from Head where id = @id");
            Command.Parameters.AddWithValue("id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( "select id,name,description,headid from Head where id = @id");
            Command.Parameters.AddWithValue("id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                HeadId = (Int32)Reader["HeadId"];
                Description = Reader["description"].ToString();
                return true;
            }
            Reader.Close();
                return false;

        }
    

        public DataSet Select(string ExtraSQL = "")
        {
            return ExecuteDS(@"select h1.id, h1.name, h1.description, h2.name as head from Head as h1
                    left join Head h2 on h1.headId =h2.id" + ExtraSQL);

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table Head(id int identity primary key, name varchar(200) unique not null,
                        description varchar(500),headId int,foreign key(headId) references Head(Id))");
            return ExecuteNQ(Command);
        }
    }
}
