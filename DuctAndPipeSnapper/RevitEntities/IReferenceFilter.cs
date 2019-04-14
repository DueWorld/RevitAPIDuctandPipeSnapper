namespace HelloRevit
{
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI.Selection;

    interface IReferenceFilter : ISelectionFilter
    {
        new bool AllowReference(Reference reference, XYZ position);
    }
}
