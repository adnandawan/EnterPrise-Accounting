using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class JournalDetails:MyBase, IDatabase
    {
       
       public int JournalId { get; set; }
        public int LedgerId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Remarks { get; set; }
       
        public bool Insert()
        {

            if (!Connection())
                return false;

            Command = CommandBuilder("insert journalDetails(journalId,ledgerid,debit,credit,remarks) values(@journalid,@leedgerid,@debit,@credit,@remarks)");
            Command.Parameters.AddWithValue("@journalid", JournalId);
            Command.Parameters.AddWithValue("@ledgerid", LedgerId);
            Command.Parameters.AddWithValue("@debit", Debit);
            Command.Parameters.AddWithValue("@credit", Credit);
            Command.Parameters.AddWithValue("@remarks", Remarks);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {

            if (!Connection())
                return false;
           Command = CommandBuilder( "Update journaldetails set debit = @debit,credit=@credit, remarks=@remark where journalid=@journalid");
            Command.Parameters.AddWithValue("@Debit", Debit);
            Command.Parameters.AddWithValue("@credit", Credit);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            Command.Parameters.AddWithValue("@jouyrnalid", JournalId);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {

            if (!Connection())
                return false;
            Command = CommandBuilder("Delete from journaldetails where journalid = @journalid");
            Command.Parameters.AddWithValue("@journalid", JournalId);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if(!Connection())
                return false;
           Command = CommandBuilder( "select journalid,ledgerid,debit,credit,remarks from journaldetails where journalid = @journalid");
            Command.Parameters.AddWithValue("@journalid", JournalId);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                JournalId = Convert.ToInt32(Reader["journalid"]);
                LedgerId = Convert.ToInt32(Reader["ledgerid"]);
                Debit = Convert.ToDecimal(Reader["debit"]);
                Credit = Convert.ToDecimal(Reader["credit"]);
                Remarks = Reader["remarks"].ToString();
                return true;
                
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS("select journalid,ledgerid,debit,credit,remarks from journaldetails");

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table journaldetails(journalId int not null, ledgerid int not null,
                debit float,credit float,remarks varchar(2000),foreign key(journalid) references journal(Id),
                foreign key(ledgerid) references ledger(id),primary key(journalid,ledgerid))");
            return ExecuteNQ(Command);
        }
    }
}
