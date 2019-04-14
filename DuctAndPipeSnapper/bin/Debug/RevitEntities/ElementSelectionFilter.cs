namespace HelloRevit
{
    using Autodesk.Revit.DB;

    public abstract class ElementSelectionFilter : ISelectionableFilter
    {
        public abstract bool AllowElement(Element elem);

        public abstract bool AllowReference(Reference reference, XYZ position);

    }
}
