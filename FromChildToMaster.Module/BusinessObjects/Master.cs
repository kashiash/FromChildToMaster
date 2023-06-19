using System;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FromChildToMaster.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Master : BaseObject
    {
        public Master() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Master(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }


        string notes;
        string masterName;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MasterName
        {
            get => masterName;
            set => SetPropertyValue(nameof(MasterName), ref masterName, value);
        }

        [Association("Master-ChildOneCollection")]
        public XPCollection<ChildOne> ChildOneCollection

        {
            get
            {
                return GetCollection<ChildOne>(nameof(ChildOne));
            }
        }

        [Association("Master-ChildTwoCollection")]
        public XPCollection<ChildTwo> ChildTwoCollection
        {
            get
            {
                return GetCollection<ChildTwo>(nameof(ChildTwoCollection));
            }
        }

        
        [Size(SizeAttribute.Unlimited)]
        public string Notes
        {
            get => notes;
            set => SetPropertyValue(nameof(Notes), ref notes, value);
        }
    }

}