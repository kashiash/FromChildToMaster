using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;

namespace FromChildToMaster.Module.Controllers
{
    public class NestedListViewFrameController : ViewController
    {
        private Frame masterFrame;
        public NestedListViewFrameController()
        {
            TargetViewType = ViewType.ListView;
            TargetViewNesting = Nesting.Nested;
        }
        public void AssignMasterFrame(Frame parentFrame)
        {
            masterFrame = parentFrame;
            // Use this Frame to get Controllers and Actions. 
            var view = masterFrame.View;
            var objectSpace = view.ObjectSpace;
            var masterObject = view.CurrentObject;

        }
    }
}
