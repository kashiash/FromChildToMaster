using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using FromChildToMaster.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromChildToMaster.Module.Controllers
{
    public class ChildTwoObjectViewListController : ObjectViewController<ListView, ChildTwo>
    {
        private Frame masterFrame;
        ChildOneObjectViewListController controllerToRefresh;
        public ChildTwoObjectViewListController() : base()
        {
            // Target required Views (use the TargetXXX properties) and create their Actions.
            TargetViewNesting = Nesting.Nested;
            
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            View.ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            View.ObjectSpace.ObjectChanged -= ObjectSpace_ObjectChanged;
            base.OnDeactivated();
        }

        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ChildTwo.Name))
            {
                if (controllerToRefresh != null)
                {
                    controllerToRefresh.FillGroupListAction();
                }
            }
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

        }


        public void AssignMasterFrame(Frame parentFrame)
        {
            masterFrame = parentFrame;
            // Use this Frame to get Controllers and Actions. 
            var view = masterFrame.View;
            var objectSpace = view.ObjectSpace;
            var masterObject = view.CurrentObject;

            foreach (Controller c in masterFrame.Controllers)
            {
                if (c is ChildOneObjectViewListController)
                {
                    controllerToRefresh = (ChildOneObjectViewListController)c;
                }
            }
        }
    }

}
