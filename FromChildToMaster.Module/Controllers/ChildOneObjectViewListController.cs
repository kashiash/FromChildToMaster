using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using FromChildToMaster.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromChildToMaster.Module.Controllers
{
    public class ChildOneObjectViewListController : ObjectViewController<ListView, ChildOne>
    {
        SingleChoiceAction selectChildTwoAction;
        Master currentMaster;
        public ChildOneObjectViewListController() : base()
        {
            selectChildTwoAction = new SingleChoiceAction(this, $"{GetType().FullName}-{nameof(selectChildTwoAction)}", PredefinedCategory.Unspecified)
            {
                Caption = "Select ChildTwo",
                ImageMode = ImageMode.UseActionImage,
                ImageName = "BO_Skull",
                ItemType = SingleChoiceActionItemType.ItemIsOperation,
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects
            };
            selectChildTwoAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
            selectChildTwoAction.Execute += selectChildTwoAction_Execute;

        }
        private void selectChildTwoAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var itemData = e.SelectedChoiceActionItem.Data;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112738/).
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            if (View.CollectionSource is PropertyCollectionSource collectionSource)
            {
                collectionSource.MasterObjectChanged += OnMasterObjectChanged;
                if (collectionSource.MasterObject != null)
                {
                    UpdateMasterObject(collectionSource.MasterObject);
                }
            }
        }

        private void OnMasterObjectChanged(object sender, EventArgs e)
        {
            UpdateMasterObject(((PropertyCollectionSource)sender).MasterObject);
        }

        private void UpdateMasterObject(object masterObject)
        {
            if (masterObject is not Master) return;

            currentMaster = (Master)masterObject;
            if (currentMaster != null)
            {
                FillGroupListAction();
                currentMaster.ChildTwoCollection.CollectionChanged += ChildTwoCollection_CollectionChanged;
                currentMaster.ChildTwoCollection.ListChanged += ChildTwoCollection_ListChanged;
            }
        }

        private void ChildTwoCollection_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            FillGroupListAction();
        }

        private void ChildTwoCollection_CollectionChanged(object sender, DevExpress.Xpo.XPCollectionChangedEventArgs e)
        {
            FillGroupListAction();
        }

        public void FillGroupListAction()
        {
            selectChildTwoAction.Items.Clear();


            foreach (var group in currentMaster.ChildTwoCollection)
            {
                selectChildTwoAction.Items.Add(new ChoiceActionItem(group.Name, group));
            }
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
    }

}
