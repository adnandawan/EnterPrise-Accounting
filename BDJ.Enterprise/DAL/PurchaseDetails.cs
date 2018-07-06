using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class PurchaseDetails:MyBase, IDatabase
    {
       
       public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public double Qty { get; set; }
        public double Rate { get; set; }
        public double Discount { get; set; }
        public double Vat { get; set; }
       
        public bool Insert()
        {

           

            Command = CommandBuilder(@"insert into PurchaseDetails(purchaseId,productid,qty,rate,discount,vat) values(@purchaseid,@productid,
                            @qty,@rate,@discount,@vat) values(@purchaseid,productid,qty,rate,discount,vat)");
            Command.Parameters.AddWithValue("@purchaseid", PurchaseId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@qty", Qty);
            Command.Parameters.AddWithValue("@rate", Rate);
            Command.Parameters.AddWithValue("@discount", Discount);
            Command.Parameters.AddWithValue("@vat", Vat);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( @"Update purchasedetails set qty=@quantity,rate=@rate,discount=@discount,vat=@vat where purchaseId=@purchaseid and productid=@productid");
            Command.Parameters.AddWithValue("@purchaseid", PurchaseId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@qty", Qty);
            Command.Parameters.AddWithValue("@rate", Rate);
            Command.Parameters.AddWithValue("@discount", Discount);
            Command.Parameters.AddWithValue("@vat", Vat );
            return ExecuteNQ(Command);


        }

       

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( "select purchaseId,productid,qty,rate,discount,vat from purchasedetails where purchaseid=@purchaseid and productid=@productid");
            Command.Parameters.AddWithValue("@purchaseid", PurchaseId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Qty = Convert.ToDouble(Reader["qty"]);
                Rate = Convert.ToDouble(Reader["rate"]);
                Discount = Convert.ToDouble(Reader["discount"]);
                Vat = Convert.ToDouble(Reader["vat"]);
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS(@"select c.id as purchaseid,p.name as productname,d.qty as quantity,d.rate,
                d.discount,d.vatfrom purchasedetails as D 
                left join product p on d.productid=p.id
                left join purchase c on d.purchaseid=c.id ");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table purchasedetails(purchaseid int not null,
                        productid int not null,qty float,rate float,discount float,vat float,
                    foreign key (purchaseid) references purchase(Id),
                    foreign key (productid) references product(Id),
                    primary key (purchaseid,productid))");
            return ExecuteNQ(Command);
        }
    }
}
