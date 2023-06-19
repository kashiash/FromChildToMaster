using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp;
using FromChildToMaster.Module.BusinessObjects;

namespace FromChildToMaster.Module.Controllers
{
    public class MasterDetailViewController : ViewController
    {
        private void PushFrameToNestedController(Frame frame)
        {
            foreach (Controller c in frame.Controllers)
            {
                if (c is NestedListViewFrameController )
                {
                    ((NestedListViewFrameController)c).AssignMasterFrame(Frame);
                }

            }
        }
        private void lpe_FrameChanged(object sender, EventArgs e)
        {
            PushFrameToNestedController(((ListPropertyEditor)sender).Frame);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            foreach (ListPropertyEditor lpe in ((DetailView)View).GetItems<ListPropertyEditor>())
            {
                if (lpe.Frame != null)
                {
                    PushFrameToNestedController(lpe.Frame);
                }
                else
                {
                    lpe.FrameChanged += lpe_FrameChanged;
                }
            }
            View.ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
            ((Master)View.CurrentObject).ChildTwoCollection.CollectionChanged += ChildTwoCollection_CollectionChanged;


        }

        private void ChildTwoCollection_CollectionChanged(object sender, DevExpress.Xpo.XPCollectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        protected override void OnDeactivated()
        {
            foreach (ListPropertyEditor lpe in ((DetailView)View).GetItems<ListPropertyEditor>())
            {
                lpe.FrameChanged -= new EventHandler<EventArgs>(lpe_FrameChanged);
            }
            View.ObjectSpace.ObjectChanged -= ObjectSpace_ObjectChanged;
            base.OnDeactivated();
        }

        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Master.ChildTwoCollection))
            {
                //View.FindItem("OrderLines").Refresh();
                var a = 1;
            }

        }
        public MasterDetailViewController()
        {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(Master);
        }
    }
}
