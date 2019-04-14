namespace DuctAndPipeSnapper.Stringers
{
    using Autodesk.Revit.DB.Mechanical;

    class RevitDuctSystemTypeStringer
    {
        private MechanicalSystemType revitSystemType;
        private string stringerText;

        public MechanicalSystemType RevitSystemType => revitSystemType;
        public string StringerText => stringerText;

        public RevitDuctSystemTypeStringer(MechanicalSystemType systemType)
        {
            revitSystemType = systemType;
            stringerText = systemType.Name;
        }

        public override string ToString()
        {
            return stringerText;
        }

    }
}
