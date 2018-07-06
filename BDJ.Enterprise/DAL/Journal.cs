using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class Journal:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public int VoucherId { get; set; }
        public int LedgerId { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public int EmployeeId { get; set; }
        public string Remarks { get; set; }
       
        public bool Insert()
        {

           

            Command = CommandBuilder(@"insert into Journal(VoucherId,ledgerid,Number,date,debit,credit,employeeid,remarks) 
                            values(@VoucherId,@ledgerid,@number,@date,@debit,@credit,@employeeid,@remarks) select @@identity");
            Command.Parameters.AddWithValue("@voucherid", VoucherId);
            Command.Parameters.AddWithValue("@ledgerId", LedgerId);
            Command.Parameters.AddWithValue("@Number", Number);
            Command.Parameters.AddWithValue("@date",Date);
            Command.Parameters.AddWithValue("@debit", Debit);
            Command.Parameters.AddWithValue("@credit", Credit);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            Command.Parameters.AddWithValue("@remarks", Remarks);

            return ExecuteScaler(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( @"Update Journal set VoucherId=@voucherid,ledgerid=@ledgerid,
                number=@number,date=@date,debit=@debit,credit=@credit,employeeid=@employeeid,remarks=@remarks where id = @id");
            Command.Parameters.AddWithValue("@voucherid", VoucherId);
            Command.Parameters.AddWithValue("@ledgerId", LedgerId);
            Command.Parameters.AddWithValue("@Number", Number);
            Command.Parameters.AddWithValue("@date", Date);
            Command.Parameters.AddWithValue("@debit", Debit);
            Command.Parameters.AddWithValue("@credit", Credit);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
       

            Command = CommandBuilder("Delete from Journal where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( @"select voucherid,ledgerid,number,date,debit,credit,employeeid,remarks from journal where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                VoucherId = (Int32)Reader["voucherid"];
                LedgerId = (Int32)Reader["ledgerid"];
                Number = Reader["Number"].ToString();
                Date = (DateTime)Reader["date"];
                Debit = (Double)Reader["Debit"];
                Credit = (double)Reader["credit"];
                EmployeeId = (Int32)Reader["employeeid"];
                Remarks = Reader["remarks"].ToString();
                
                return true;
            }
            Reader.Close();
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS("select id,number,debit,credit,remarks from journal");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table journal(id int identity primary key,
                voucherId int,ledgerid int,number varchar(20) unique not null,date datetime,
                debit float,credit float,employeeid int,remarks varchar(2000),
                foreign key(ledgerid) references ledger(id),
                    foreign key(employeeid) references ledger(id))");
            return ExecuteNQ(Command);
        }
    }
}
