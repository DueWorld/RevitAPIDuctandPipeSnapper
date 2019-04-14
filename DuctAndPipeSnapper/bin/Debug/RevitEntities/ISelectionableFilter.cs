namespace HelloRevit
{
    using Autodesk.Revit.ApplicationServices;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.DB.Architecture;
    using Autodesk.Revit.UI;
    using Autodesk.Revit.UI.Selection;
    using System;

    
    interface ISelectionableFilter :ISelectionFilter
    {
        new bool AllowElement(Element elem);
        
    }
}
