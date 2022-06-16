using System;

namespace ProjectML.Core.Models
{
    //храняться префикци группы к примеру (ра, та, тб)  

    public class Group
    {
       public int Id { get; set; }
       public int ProfessionId { get; set; }
       public int CourceId { get; set; }
       public virtual Profession Profession { get; set; }
       public virtual Cource Cource { get; set; }
       public string Key { get; set; }
       public DateTime date { get; set; }
    }
}