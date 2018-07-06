using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Category:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
       
        public bool Insert()
        {

           

            Command = CommandBuilder("insert into category(name, description, categoryId, ) values(@name, @description, @categoryId)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@categoryid", CategoryId);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( "Update category set name = @name description = @description, categoryid = @categoryid where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@categoryid", CategoryId);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
       

            Command = CommandBuilder("Delete from category where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection()) return false;
           Command = CommandBuilder( "select id,name,description, categoryid from category where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["description"].ToString();
                CategoryId = (Int32)Reader["categoryId"];
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS("select id,name,description,categoryid from category");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table category(id int identity primary key, name varchar(200)  not null,
                                              description varchar(500),categoryid int,
                                       foreign key(categoryid) references category(id)");
            return ExecuteNQ(Command);
        }
    }
}
