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
            //string connStr = "PORT=5432;DATABASE=test;HOST=localhost;PASSWORD=root;USER ID=postgres";
            //UserRepository user = new UserRepository();
            //1.增
            //var result = user.Add<string>(connStr, new User()
            //{
            //    userid =Guid.NewGuid().ToString("N"),
            //    name = $"{Guid.NewGuid().ToString("N")}lsh",
            //    age = 25
            //});
           // Console.WriteLine(result);
            //2.删
            //bool result=user.Remove(connStr, "xxxs");
            // Console.WriteLine(result);
            //3.改
            //bool result = user.Modify(connStr,new User() {id="xx",name="lsg" });
            //Console.WriteLine(result);
            //4.查
            //var result = user.Find(connStr,"xx");
            //Console.WriteLine(result.name);
            //var lst = user.Query(connStr).ToList();
            //lst.ForEach(ele =>
            //{

            //    Console.WriteLine(ele.name);
            //});
            //5.数量
            //int count= user.Count(connStr);
           // Console.WriteLine(count);
           // Console.ReadKey();
        }
    }
}
