using dbaccess.helper.tools.Repository;
using Npgsql;
using System;
using System.Linq;
namespace dbaccess.helper
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "PORT=5432;DATABASE=test;HOST=localhost;PASSWORD=root;USER ID=postgres";
            UserRepository user = new UserRepository();
            //1.增
            var result = user.Insert<Guid>(connStr, new User()
            {
                id =Guid.NewGuid(),
                name = $"{Guid.NewGuid().ToString("N")}lsh",
                age = 25
            });
            Console.WriteLine(result);
            //2.删
            //bool result=user.Delete(connStr, "xxxs");
            // Console.WriteLine(result);
            //3.改
            //bool result = user.Update(connStr,new User() {id="xx",name="lsg" });
            //Console.WriteLine(result);
            //4.查
            //var result = user.Get(connStr,"xx");
            //Console.WriteLine(result.name);
            //var lst = user.GetAll(connStr).ToList();
            //lst.ForEach(ele =>
            //{

            //    Console.WriteLine(ele.name);
            //});
            Console.ReadKey();
        }
    }
}
