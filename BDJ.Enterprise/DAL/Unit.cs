using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class Unit:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PrimaryQty { get; set; }
       
        public bool Insert()
        {

           

            Command = CommandBuilder("insert into unit  (name, description, primaryqty) values(@name, @description, @Primaryqty)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@primaryqty", PrimaryQty);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( "Update country set name = @name, description = @escription, primaryqty=@primaryqty where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@primaryqty", PrimaryQty);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
       

            Command = CommandBuilder("Delete from unit where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {

           Command = CommandBuilder( "select id, name, description, primaryqty from unit where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["description"].ToString();
                PrimaryQty = Convert.ToDouble(Reader["primaryqty"]);
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS("select id, name, description, primaryqty from unit");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table unit(id int identity primary key, name varchar(200),
                        Description varchar(2000),
                        primaryqty float)");
            return ExecuteNQ(Command);
        }
    }
}
