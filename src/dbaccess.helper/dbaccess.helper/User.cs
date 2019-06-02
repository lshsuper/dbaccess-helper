using Dapper;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


namespace dbaccess.helper
{
    [Table("t_user")]
    public class User
    {
     

      
        [Key,Column("id")]
        public   string userid { get; set; }
      
    
        public  string name { get; set; }
        public  int age { get; set; }
    }
}
