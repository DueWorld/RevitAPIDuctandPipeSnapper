namespace DuctAndPipeSnapper.Helper
{
    public enum Unit
    {
        MeliMeter = 0,
        Meter,
        Inch,
        Foot

    }

    public class RevitUnitConverter
    {
        private double assignedValue;
        private double convertedValue;
        private Unit documentUnit;


        public double AssignedValue { get => assignedValue; set => assignedValue = value; }
        public double ConvertedValue => convertedValue;
        public Unit DocumentUnit { get => documentUnit; set => documentUnit = value; }


        public RevitUnitConverter(double value, Unit docUnit)
        {
            documentUnit = docUnit;
            assignedValue = value;
            convertedValue = ConvertValueToApiUnit(value, docUnit);
        }

        private double ConvertValueToApiUnit(double value, Unit docUnit)
        {
            if (docUnit == Unit.MeliMeter)
            {
                return value * (1 / 304.8);
            }
            else if (docUnit == Unit.Meter)
            {
                return value * (1 / 0.3048);
            }
            else if (docUnit == Unit.Inch)
            {
                return value * (1 / 12);
            }
            else
            {
                return value;
            }

        }
    }
}

