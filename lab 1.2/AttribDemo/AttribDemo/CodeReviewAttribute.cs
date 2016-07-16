using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct,AllowMultiple = true,Inherited = true)]
   public class CodeReviewAttribute:System.Attribute
    {
       public  string  ReviewerName { get; set; }
        public string ReviewDate { get; set; }
        public bool Approved { get; set; }

        public CodeReviewAttribute(string name,string date,bool approved)
        {
            ReviewerName = name;
            ReviewDate = date;
            Approved = approved;
        }
        public override string ToString()
        {
            return $"reviewer name: {ReviewerName}, review date: {ReviewDate},appreved?: {Approved}";
        }
    }
}
