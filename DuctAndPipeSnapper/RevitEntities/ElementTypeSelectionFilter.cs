namespace HelloRevit
{
    using Autodesk.Revit.DB;

    public class ElementTypeSelectionFilter<T> : ElementSelectionFilter where T : Element
    {
        public override bool AllowElement(Element elem)
        {

            return elem is T;
        }

        public override bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
