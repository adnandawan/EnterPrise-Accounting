using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   sealed class Product:MyBase, IDatabase
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string Offers { get; set; }
        public double Discount { get; set; }
       
        public bool Insert()
        {


            if (!Connection())
                return false;
            Command = CommandBuilder(@"insert into product(name,description,tag,code,type,categoryId,brandId,
                offers,discount) values(@name,@description,@Tag,@Code,@Type,@categoryId,@BrandId,@Offers,@Discount)");

            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@Tag", Tag);
            Command.Parameters.AddWithValue("@Code", Code);
            Command.Parameters.AddWithValue("@Type", Type);
            Command.Parameters.AddWithValue("@categoryid", CategoryId);
            Command.Parameters.AddWithValue("@brandid", BrandId);
            Command.Parameters.AddWithValue("@offers", Offers);
            Command.Parameters.AddWithValue("@discount", Discount);

            return ExecuteNQ(Command);
          

        }
        public bool Update()
        {

            if (!Connection())
                return false;
           Command = CommandBuilder( @"Update product set name = @name,description=@description,tag=@tag,
            code=@code, type=@type,categoryid=@categoryid,brandid=@brandid,images=@images,offers=@offers,
            discount=@discount where id = @id");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@Tag", Tag);
            Command.Parameters.AddWithValue("@code", Code);
            Command.Parameters.AddWithValue("@type", Type);
            Command.Parameters.AddWithValue("@categoryid", CategoryId);
            Command.Parameters.AddWithValue("@brandid", BrandId);
         
            Command.Parameters.AddWithValue("@offers", Offers);
            Command.Parameters.AddWithValue("@discount", Discount);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);


        }

        public bool Delete()
        {

            if (!Connection())
                return false;
            Command = CommandBuilder("Delete from product where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }

        public bool SelectById()
        {
            if (!Connection())
                return false;
           Command = CommandBuilder( @"select id,name,description,tag,code,type,categoryid,
              brandid,offers,discount from product where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Name = Reader["name"].ToString();
                Description = Reader["description"].ToString();
                Tag = Reader["tag"].ToString();
                Code = Reader["code"].ToString();
                Type = Reader["type"].ToString();
                CategoryId = Convert.ToInt32(Reader["categoryid"]);
                BrandId = Convert.ToInt32(Reader["brandid"]);
               
                Offers = Reader["offers"].ToString();
                Discount = Convert.ToDouble(Reader["discount"]);
                return true;
            }
                return false;

        }

        public DataSet Select()
        {
            return ExecuteDS(@"

               select p.id,p.name,p.description,p.tag,
              p.code,p.type,c.name as category,b.name as brand,
              p.offers, p.discount from product as p
             left join category as c on p.categoryid=c.id
             left join brand as b on p.brandid=b.id");

           

        }

        public bool Table()
        {
            Command = CommandBuilder(@"create table product(id int identity primary key, name varchar(200),
                                     description varchar(2000),tag varchar(200),code varchar(200) unique,
                                      type varchar(5),categoryid int not null,brandid int not null,
                                        offers varchar(2000),Discount float,
                                    foreign key (categoryid) references category(Id),
                                    foreign key(brandId) references brand(Id))");
            return ExecuteNQ(Command);
        }
    }
}
