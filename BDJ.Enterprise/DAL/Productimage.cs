using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class ProductImage:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public byte[] Image { get; set; }
        public string FileName { get; set; }

       
        public bool Insert()
        {

           

            Command = CommandBuilder("insert into productimage(productid, title, image, fileName ) values(@productid, @title, @image, @fileName )");
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@title", Title);
            Command.Parameters.AddWithValue("@image", Image);
            Command.Parameters.AddWithValue("@fileName", FileName);




            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( "Update country set name = @name where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
         
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
                //Name = Reader["name"].ToString();
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS(@"select pi.id,pi.title,pi.datetime, p.name as product,pi.image from productImage as pi
                            left join product as p on pi.productid = p.id");

           

        }

        public bool Table()
        {
            Command = CommandBuilder("create table country(id int identity primary key, name varchar(200) unique not null)");
            return ExecuteNQ(Command);
        }
    }
}
