using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class ProductManual:MyBase, IDatabase
    {
       
        public int ProductId { get; set; }
        public byte[] Manual { get; set; }
        public string FileName { get; set; }
       
        public bool Insert()
        {

           

            Command = CommandBuilder("insert into productManual(productId, manual, fileName) values(@productId, @manual, @fileName)");
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@manual", Manual);
            Command.Parameters.AddWithValue("@fileName", FileName);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( "Update country set name = @name where id = @id");
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@manual", Manual);
            Command.Parameters.AddWithValue("@fileName", FileName);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
       

            Command = CommandBuilder("Delete from productManual where productId = @productId");
            Command.Parameters.AddWithValue("@productId", ProductId);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {

           Command = CommandBuilder( "select productId, manual, fileName from productManual where productId = @productId");
            Command.Parameters.AddWithValue("@productId", ProductId);
            Reader = ExecuteReader(Command);
            while(Reader.Read())
            {
                Manual = (byte[])Reader["manual"];
                FileName = Reader["fileName"].ToString();
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS("select pm.productId, p.name as product, pm.fileName name from productManual pm left join product p on pm.productId = p.id");

           

        }

        public bool Table()
        {
            Command = CommandBuilder("create table country(id int identity primary key, name varchar(200) unique not null)");
            return ExecuteNQ(Command);
        }
    }
}
