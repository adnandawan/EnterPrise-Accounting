using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class Production:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double Qty { get; set; }
        public double ActualQty { get; set; }
        public DateTime ManufuctureDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Number { get; set; }
        public int FormulaId { get; set; }
        public int EmployeeId { get; set; }
       
        public bool Insert()
        {

           

            Command = CommandBuilder(@"insert into production(productid,Qty,actualqty,manufacturedate,Expiredate,
            number,formulaid,employeeid,) values(@productid,@qty,@actualqty,@manufacturedate,@expiredate,@number,@formulaid,@employeeid)");
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@qty", Qty);
            Command.Parameters.AddWithValue("@actualqty",ActualQty );
            Command.Parameters.AddWithValue("@manufacturedate", ManufuctureDate);
            Command.Parameters.AddWithValue("@expire", ExpireDate);
            Command.Parameters.AddWithValue("@number", Number);
            Command.Parameters.AddWithValue("@formulaid", FormulaId);
            Command.Parameters.AddWithValue("@employeeid", EmployeeId);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( @"Update production set productid=@productid,qty=@qty,actualqty=@actualqty,
            manufucturedate=@manufucturedate,expiredate=@expiredate,number=@number,formulaid=@formulaid,employeeid=@employeeid where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@qty", Qty);
            Command.Parameters.AddWithValue("@actualqty", ActualQty);
            Command.Parameters.AddWithValue("@manufucturedate", ManufuctureDate);
            Command.Parameters.AddWithValue("@Expire", ExpireDate);
            Command.Parameters.AddWithValue("@number", Number);
            Command.Parameters.AddWithValue("@formulaid", FormulaId);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
       

            Command = CommandBuilder("Delete from production where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( @"select id,productid,qty,actualqty,manufucturedate,expiredate,number,formulaid,employeeid from production where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                ProductId = Convert.ToInt32(Reader["productid"]);
                Qty = Convert.ToDouble(Reader["qty"]);
                ActualQty = Convert.ToDouble(Reader["Actualqty"]);
                ExpireDate = Convert.ToDateTime(Reader["expiredate"]);
                ManufuctureDate = Convert.ToDateTime(Reader["manufucturedate"]);
                Number = Reader["number"].ToString();
                FormulaId = Convert.ToInt32(Reader["Formulaid"]);

                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS(@"select id,productid,qty,actualqty,manufucturedate,
                    expiredate, number,formulaid, employeeid from production");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table production(id int identity primary key, productid int, qty float,actualqty float,
            expiredate datetime, manufucturedate datetime, number varchar(20) unique not null,formulaid int,employeeid int,
            foreign key (productid) references product(id),
            foreign key (formulaid) references formula(id),
            foreign key (employeeid) references ledger(Id))");
            return ExecuteNQ(Command);
        }
    }
}
