using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    sealed class Sales:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public int number { get; set; }
        public DateTime Datetime { get; set; }
        public int EmployeeId { get; set; }
        public int LedgerId { get; set; }
        public decimal Total { get; set; }
        public decimal Addition { get; set; }
        public decimal Deduction { get; set; }
        public string Remarks { get; set; }
       
        public bool Insert()
        {


            if (!Connection())
                return false;
            Command = CommandBuilder(@"insert into sales(Number,date,employeeid,ledgerid,total,addition,deduction,remarks) values(@number,@date,@employeeid,@ledgerid,@total,@addition,@deduction,@remarks)");
            Command.Parameters.AddWithValue("@number", number);
            Command.Parameters.AddWithValue("@date", Datetime);
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
            if (!Connection())
                return false;

           Command = CommandBuilder( @"Update sales set number=@number,date=@date,employeeid=@employeeid,ledgerid=@ledgerid,
                total=@total,addition=@addition,deduction=@deduction,remarks=@remarks where id = @id");
            Command.Parameters.AddWithValue("@number", number);
            Command.Parameters.AddWithValue("@date", Datetime);
            Command.Parameters.AddWithValue("@employeeid", EmployeeId);
            Command.Parameters.AddWithValue("@ledgerid", LedgerId);
            Command.Parameters.AddWithValue("@total", Total);
            Command.Parameters.AddWithValue("@addition", Addition);
            Command.Parameters.AddWithValue("@deduction", Deduction);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            Command.Parameters.AddWithValue("@id", Id);
            
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {

            if (!Connection())
                return false;
            Command = CommandBuilder("Delete from sales where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder(@"select id,number,date,employeeid,ledgerid,total,addition,deduction,remarks, from sales where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                number = Convert.ToInt32(Reader["number"]);
                Datetime = Convert.ToDateTime(Reader["date"]);
                EmployeeId = Convert.ToInt32(Reader["employeeid"]);
                LedgerId = Convert.ToInt32(Reader["ledgerid"]);
                Total = Convert.ToDecimal(Reader["total"]);
                Addition = Convert.ToDecimal(Reader["addition"]);
                Deduction = Convert.ToDecimal(Reader["deduction"]);
                Remarks = Reader["remarks"].ToString();
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS(@"select s.Id,s.Number,s.date,l.name as employeename,l.Id as ledgerid,s.total,
                s.addition,s.deduction,s.remarks from sales as s 
                left join ledger l on s.employeeId=l.Id");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table Sales(Id int identity primary key,number int,date datetime,
                    employeeid int,ledgerid int, total float,addition float,deduction float,remarks varchar(2000),
                    foreign key(employeeid) references ledger(Id),
                    foreign key(LedgerId) references Ledger(Id))");
            return ExecuteNQ(Command);
        }
    }
}
