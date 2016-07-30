using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    /**
     It is not reccomended to set inherited to true unless necessary.
        The inherited attribute means that the attribute will decorate each derived class of the decorated class
        Which is not something we would want in this case - since each class should be reviewed regardless of whether or not its base class was reviewed
         */
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
