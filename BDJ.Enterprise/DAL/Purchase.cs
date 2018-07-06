using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class Purchase:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public int LedgerId { get; set; }
        public double Total { get; set; }
        public double Addition { get; set; }
        public double Deduction { get; set; }
        public string Remarks { get; set; }
      
       
        public bool Insert()
        {

           

            Command = CommandBuilder(@"insert into Purchase(number,date,employeeid,ledgerid,total,addition,deduction,remarks) values(@number,
                @date,@employeeid,@ledgerid,@total,@addition,@deduction,@remarks)");
            Command.Parameters.AddWithValue("@number", Number);
            Command.Parameters.AddWithValue("@date", Date);
            Command.Parameters.AddWithValue("@employeeid", EmployeeId);
            Command.Parameters.AddWithValue("@ledgerid", LedgerId);
            Command.Parameters.AddWithValue("@total", Total);
            Command.Parameters.AddWithValue("@addition", Addition);
            Command.Parameters.AddWithValue("@deduction", Deduction);
            Command.Parameters.AddWithValue("@remarks", Remarks);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder(@"Update purchase set 
           number=@number,date=@date,employeeid=@employeeid,ledgerid=@ledgerid,total=@total,
            addition=@addition,deduction=@deduction,remarks=@remarks where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@number", Number);
            Command.Parameters.AddWithValue("@date", Date);
            Command.Parameters.AddWithValue("@employeeid", EmployeeId);
            Command.Parameters.AddWithValue("@ledgerid", LedgerId);
            Command.Parameters.AddWithValue("@total", Total);
            Command.Parameters.AddWithValue("@addition", Addition);
            Command.Parameters.AddWithValue("@deduction", Deduction);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {

            if (!Connection())
                return false;
            Command = CommandBuilder("Delete from purchase where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( @"select id,number,date,employeeid,ledgerid,total,addition,deduction,remarks from purchase");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Number = Convert.ToInt32(Reader["number"]);
                Date = (DateTime)Reader["date"];
                EmployeeId = Convert.ToInt32(Reader["employeeid"]);
                LedgerId = Convert.ToInt32(Reader["ledgerid"]);
                Total = Convert.ToDouble(Reader["total"]);
                Addition = Convert.ToDouble(Reader["addition"]);
                Deduction = Convert.ToDouble(Reader["deduction"]);
                Remarks = (Reader["remarks"]).ToString();
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS(@"select p.number,p.date,l.name as employeename,l.id as ledgerid,p.total,
                p.addition,p.deduction,p.remarks
                from purchase as p
                left join ledger l on p.employeeid=l.id");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table purchase(id int identity primary key, number varchar(20) unique not null,
                                date datetime,employeeid int,ledgerid int,total float,addition float,deduction float,remarks varchar(2000),
                            foreign key (employeeid) references ledger (Id),
                            foreign key(ledgerId) references ledger(id))");
            return ExecuteNQ(Command);
        }
    }
}
