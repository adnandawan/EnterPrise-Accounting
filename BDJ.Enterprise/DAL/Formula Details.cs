using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class FormulaDetails:MyBase, IDatabase
    {
       
        public int FormulaId { get; set; }
        public int ProductId { get; set; }
        public double Qty { get; set; }
        public string Remarks { get; set; }
       
        public bool Insert()
        {

           

            Command = CommandBuilder(@"insert into formuladetails(formulaid,productid, qty, remarks) values(@formulaid,@productid,@qty,@remarks)");
            Command.Parameters.AddWithValue("@formulaid", FormulaId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@qty", Qty);
            Command.Parameters.AddWithValue("@remarks", Remarks);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {


           Command = CommandBuilder( @"Update formuladetails set formulaid = @formulaid, productid = @productid, qty=@qty, remarks = @remarks, where formulaid=@formulaid and productid=@productid");
            Command.Parameters.AddWithValue("@formulaid", FormulaId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Command.Parameters.AddWithValue("@qty", Qty);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {
       

            Command = CommandBuilder(@"Delete from formuladetails where formulaid=@formulaid and productid=@productid");
            Command.Parameters.AddWithValue("@formulaid", FormulaId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( @"select formulaid, productid, qty, remarks from formuladetails where formulaid=@formulaid and productid=@productid");
            Command.Parameters.AddWithValue("@formulaid", FormulaId);
            Command.Parameters.AddWithValue("@productid", ProductId);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Qty = Convert.ToDouble(Reader["qty"]);
                Remarks = Reader["Remarks"].ToString();
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS("select fd.formulaid, f.name formula, fd.productid, p.name product, fd.qty, fd.remarks from formuladetails fd left join formula f on fd.formulaid = f.id left join product p on fd.productid = p.id");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table formuladetails(formulaid int, productid int,
                        qty float,remarks varchar(2000),
                    foreign key(productid) references product(id),
                    foreign key (formulaid) references formula(id),
                    primary key(productid,formulaid)");
            return ExecuteNQ(Command);
        }
    }
}
