using System;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FromChildToMaster.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class ChildOne : BaseObject
    {
        public ChildOne() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public ChildOne(Session session) : base(session)
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
        string childOneName;
        Master master;

        [Association("Master-ChildOneCollection")]
        public Master Master

        {
            get => master;
            set => SetPropertyValue(nameof(Master), ref master, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ChildOneName
        {
            get => childOneName;
            set => SetPropertyValue(nameof(ChildOneName), ref childOneName, value);
        }

        
        [Size(SizeAttribute.Unlimited)]
        public string Notes
        {
            get => notes;
            set => SetPropertyValue(nameof(Notes), ref notes, value);
        }
    }

}