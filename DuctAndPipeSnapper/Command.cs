namespace DuctAndPipeSnapper
{
    using Autodesk.Revit.ApplicationServices;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using DuctAndPipeSnapper.Forms;

    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            PlugInDuctForm form = new PlugInDuctForm(doc);
            form.ShowDialog();
            if (form.GenerationFlag)
            {
                LinkedDuctSystemDrawer ductDrawer = new LinkedDuctSystemDrawer(form.CadLink, form.LayerDetails, doc);
                using (Transaction trans = new Transaction(doc, "Duct Drawer"))
                {
                    trans.Start();
                    ductDrawer.DrawDuctFromCadLink();
                    trans.Commit();
                }
            }
            return Result.Succeeded;
        }
    }
}
