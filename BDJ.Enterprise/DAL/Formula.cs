using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class Formula:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Decimal Quantity { get; set; }
       
        public bool Insert()
        {

            if (!Connection())
                return false;

            Command = CommandBuilder("insert into formula(name,productId,qty) values(@name,@productid,@qty) select @@identity");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@qty", Quantity);

            return ExecuteScaler(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( "Update formula set name = @name,productId=@productid,qty=@qty where id = @id");
          
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@qty", Quantity);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {

            if (!Connection())
                return false;
            Command = CommandBuilder("Delete from formula where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( "select id, name, productid, qty from formula where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                ProductId = Convert.ToInt32(Reader["productid"]);
                Quantity = Convert.ToDecimal(Reader["qty"].ToString());
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS("select f.id, f.name, p.name as product, f.qty from formula f left join product p on f.productid = p.id");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table formula(id int identity primary key, name varchar(200),productid int, qty float,foreign key(productid) references product(id)");
            return ExecuteNQ(Command);
        }
    }
}
