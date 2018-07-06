using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class Voucher:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AutoNumber { get; set; }
        public int CurrentNumber { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public int Length { get; set; }
        public bool AutoPrint { get; set; }
        public string Nature { get; set; }
       
        public bool Insert()
        {

           

            Command = CommandBuilder(@"insert into voucher(name,description,autonumber,currentnumber,prefix,postfix,length,autoprint) 
                values(@name,@description,@autonumber,@currentnumber,@prefix,@postfix,@length, @autoprint)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@autonumber", AutoNumber);
            Command.Parameters.AddWithValue("@currentnumber" , CurrentNumber);
            Command.Parameters.AddWithValue("@prefix", Prefix);
            Command.Parameters.AddWithValue("@postfix", Postfix);
            Command.Parameters.AddWithValue("@length", Length);
            Command.Parameters.AddWithValue("@autoprint", AutoPrint);


            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( @"Update voucher set name = @name,description=@description,autonumber=@autonumber,prefix=@prefix,
            currentnumber=@currentnumber,postfix=@postfix,length=@length,autoprint=@autoprint where id = @id");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@autonumber", AutoNumber);
            Command.Parameters.AddWithValue("@prefix", Prefix);
            Command.Parameters.AddWithValue("@currentnumber", CurrentNumber);
            Command.Parameters.AddWithValue("@postfix", Postfix);
            Command.Parameters.AddWithValue("@length", Length);
            Command.Parameters.AddWithValue("@autoprint", AutoPrint);
            Command.Parameters.AddWithValue("@id", Id);
           
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
       

            Command = CommandBuilder("Delete from voucher where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( "select id, name, description, autonumber, prefix, currentnumber, postfix, length, autoprint,Nature  from voucher where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = ExecuteReader(Command);
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["Description"].ToString();
                AutoNumber = Convert.ToBoolean(Reader["autonumber"]);
                Prefix = Reader["prefix"].ToString();
                CurrentNumber = Convert.ToInt32(Reader["currentnumber"]);
                Postfix = Reader["postfix"].ToString();
                Length = Convert.ToInt32(Reader["length"]);
                AutoPrint = Convert.ToBoolean(Reader["autoprint"]);
                Nature = Reader["nature"].ToString();

                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS("select id, name, description, autonumber, prefix, currentnumber, postfix, length, autoprint from voucher");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table voucher(id int identity primary key, name varchar(200),description varchar(500),autonumber int,
                                prefix varchar(5),currentnumber bit,postfix varchar(5),length int,autoprint bit)");
            
                    return ExecuteNQ(Command);
        }
    }
}
