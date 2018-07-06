using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class SalesDetails:MyBase, IDatabase
    {
       
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public double Qty { get; set; }
        public double Rate { get; set; }
        public double Vat { get; set; }
        public double Discount { get; set; }
       
        public bool Insert()
        {

           

            Command = CommandBuilder(@"insert into formuladetails(salesid,productid,qty,rate,vat,discount) 
                    values(@salesid,@productid,@qty,@rate,@vat,@discount)");
            Command.Parameters.AddWithValue("@salesid", SalesId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@qty", Qty);
            Command.Parameters.AddWithValue("@rate", Rate);
            Command.Parameters.AddWithValue("@vat", Vat);
            Command.Parameters.AddWithValue("@discount", Discount);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( @"Update salesdetails set salesid=@salesid,productid=@productid qty=@qty,rate=@rate,vat=@vat,
                  discount=@discount where salesid=@salesid and productid=@productid");
            Command.Parameters.AddWithValue("@salesid", SalesId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@qty", Qty);
            Command.Parameters.AddWithValue("@rate", Rate);
            Command.Parameters.AddWithValue("@vat", Vat);
            Command.Parameters.AddWithValue("@discount", Discount);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
       

            Command = CommandBuilder(@"Delete from salesdetails where salesid=@salesid and productid=@productid");
            Command.Parameters.AddWithValue("@salesid", SalesId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( @"select salesid,productid,qty,rate,vat,discount from 
                            salesdetails where salesid=@salesid and productid=@productid");
            Command.Parameters.AddWithValue("@salesid", SalesId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Qty = Convert.ToDouble(Reader["qty"]);
                Vat = Convert.ToDouble(Reader["vat"]);
                Rate = Convert.ToDouble(Reader["rate"]);
                Discount = Convert.ToDouble(Reader["discount"]);
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS(@"select salesid,productid,qty,rate,vat,discount from salesdetails");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table salesdetails(
                        salesid int not null,productid int not null,
                    qty float,rate float,discount float,vat float,
                foreign key(salesid) references sales(id),
                foreign key (productid) references product(id),
                   primary key(salesid,productid)");
            return ExecuteNQ(Command);
        }
    }
}
