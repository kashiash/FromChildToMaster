using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromChildToMaster.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class ChildTwo : BaseObject
    {
        public ChildTwo(Session session) : base(session)
        { }


        string notes;
        Master master;

        [Association("Master-ChildTwoCollection")]
        public Master Master
        {
            get => master;
            set => SetPropertyValue(nameof(Master), ref master, value);
        }

        
        [Size(SizeAttribute.Unlimited)]
        public string Notes
        {
            get => notes;
            set => SetPropertyValue(nameof(Notes), ref notes, value);
        }
    }
}
