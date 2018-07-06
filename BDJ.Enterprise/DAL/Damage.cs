using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    sealed class Damage:MyBase, IDatabase
    {
       
        public int Id { get; set; }
       public int ProductId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Quantity { get; set; }
        public string Remark { get; set; }
        public int employeeId { get; set; }

       
        public bool Insert()
        {

            if (!Connection())
                return false;

            Command = CommandBuilder("insert into damage(roductId, datetime, qty, Remarks, employeeId) values(@productId,@datetime,@qty,@Remarks,@employeeid)");
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@datetime", DateTime);
            Command.Parameters.AddWithValue("@qty", Quantity);
            Command.Parameters.AddWithValue("@Remarks", Remark);
            Command.Parameters.AddWithValue("@employeeid", employeeId);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {
            if (!Connection())
                return false;

           Command = CommandBuilder( "Update damage set productid = @productid, datetime=@datetime, qty=@qty, Remarks=@Remarks, employeeId=@employeeId where id = @id");
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@datetime", DateTime);
            Command.Parameters.AddWithValue("@qty", Quantity);
            Command.Parameters.AddWithValue("@Remarks", Remark);
            Command.Parameters.AddWithValue("@employeeId", employeeId);
            Command.Parameters.AddWithValue("@Id", Id);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
            if (!Connection())
                return false;

            Command = CommandBuilder("Delete from damage where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( "select id,productid,datetime,qty,Remarks,employeeid from damage where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                ProductId = Convert.ToInt32(Reader["productid"]);
                DateTime = (DateTime)Reader["Datetime"];
                Quantity = Convert.ToDecimal(Reader["qty"]);
                Remark = Reader["Remarks"].ToString();
                employeeId = Convert.ToInt32(Reader["employeeid"]); 
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS(@"select product.id  as productid, damage.datetime, damage.qty, damage.qty, damage.remarks, ledger.id as employeeid from damage
                           left join product on damage.productid=product.id
                            left join ledger on damage.employeeId=ledger.id from country");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table damage(id int identity primary key, productid int, datetime datetime,qty float, 
                                Remarks varchar(2000),employeeid int, foreign key(productid) references product(Id),
                                    foreign key(employeeId) references Ledger(Id))");
            return ExecuteNQ(Command);
        }
    }
}
