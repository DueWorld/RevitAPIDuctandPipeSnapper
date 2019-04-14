namespace DuctAndPipeSnapper.Stringers
{
    using Autodesk.Revit.DB.Mechanical;

    class RevitDuctTypeStringer
    {
        
            private DuctType revitDuctType;
            private string stringerText;

            public DuctType RevitDuctType => revitDuctType;
            public string StringerText => stringerText;

            public RevitDuctTypeStringer(DuctType systemType)
            {
                revitDuctType = systemType;
                stringerText = systemType.Name;
            }

            public override string ToString()
            {
                return stringerText;
            }

        
    }
}
