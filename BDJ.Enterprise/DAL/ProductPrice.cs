using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    sealed class ProductPrice : MyBase, IDatabase
    {
       
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public double Price { get; set; }
       
        public bool Insert()
        {


            if (!Connection())
                return false;
            Command = CommandBuilder("insert into Productprice(productId,unitid,price) values(@productid,@unitid,@price)");
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@unitid", UnitId);
            Command.Parameters.AddWithValue("@price", Price);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {
            if (!Connection())
                return false;

           Command = CommandBuilder( "Update Productprice set price=@price where productid = @productid");
            Command.Parameters.AddWithValue("@price", Price);
            Command.Parameters.AddWithValue("@productid", ProductId);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {

            if (!Connection())
                return false;
            Command = CommandBuilder("Delete from productprice where productid=@productid");
            Command.Parameters.AddWithValue("@productid", ProductId);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( "select productid,unitid, price from productprice where productid=@productid");
            Command.Parameters.AddWithValue("@productid", ProductId);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Price = Convert.ToDouble(Reader["price"]);
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS(@"select pp.productId, pp.unitId, p.name as product,u.name as unit,pp.price from productprice as pp
                left join product as p on pp.productid = p.id
                left join unit as u on pp.unitid = u.id");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table productprice(productid int not null,unitid int not null,price float,
            foreign key(productid) references product(id),
             foreign key (unitid) references unit(id),
                primary key(productid,unitid))");
            return ExecuteNQ(Command);
        }
    }
}
