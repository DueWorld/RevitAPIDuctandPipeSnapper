namespace DuctAndPipeSnapper.Forms
{
    using Autodesk.Revit.DB;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using DuctAndPipeSnapper.Stringers;
    using Autodesk.Revit.DB.Mechanical;
    using static DuctAndPipeSnapper.Helper.CurveSorterUtils;
    using DuctAndPipeSnapper.Helper;

    public class PlugInDuctForm : System.Windows.Forms.Form
    {
        private Document doc;
        private List<DuctLinkLayerDetail> layerDetails;
        private ImportInstance cadLink;

        private ComboBox combBoxSysType;
        private Label lblSysType;
        private ComboBox combBoxLvl;
        private ComboBox combBoxLayer;
        private Label lblRefLvl;
        private Label lblOffset;
        private ComboBox combBoxUnit;
        private Label lblUnW;
        private Label lblHeight;
        private Label lblWidth;
        private TextBox txtOffset;
        private TextBox txtHeight;
        private TextBox txtWidth;
        private Button btnGenerate;
        private Button btnSaveInfo;
        private Label lblCadLayers;
        private Label lblCadLink;
        private ComboBox combBoxCadLink;
        private Label lblDuctType;
        private ComboBox combBoxDuctType;
        private bool generationFlag;
        private double comboBoxCounter;

        public Document Doc { get => doc; set => doc = value; }
        public bool GenerationFlag => generationFlag;
        public List<DuctLinkLayerDetail> LayerDetails => layerDetails;
        public ImportInstance CadLink => cadLink;

        #region Automatically written code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlugInDuctForm));
            this.combBoxSysType = new System.Windows.Forms.ComboBox();
            this.lblSysType = new System.Windows.Forms.Label();
            this.combBoxLvl = new System.Windows.Forms.ComboBox();
            this.combBoxLayer = new System.Windows.Forms.ComboBox();
            this.lblRefLvl = new System.Windows.Forms.Label();
            this.lblOffset = new System.Windows.Forms.Label();
            this.combBoxUnit = new System.Windows.Forms.ComboBox();
            this.lblUnW = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnSaveInfo = new System.Windows.Forms.Button();
            this.lblCadLayers = new System.Windows.Forms.Label();
            this.lblCadLink = new System.Windows.Forms.Label();
            this.combBoxCadLink = new System.Windows.Forms.ComboBox();
            this.lblDuctType = new System.Windows.Forms.Label();
            this.combBoxDuctType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // combBoxSysType
            // 
            this.combBoxSysType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBoxSysType.FormattingEnabled = true;
            this.combBoxSysType.Location = new System.Drawing.Point(90, 203);
            this.combBoxSysType.Name = "combBoxSysType";
            this.combBoxSysType.Size = new System.Drawing.Size(243, 24);
            this.combBoxSysType.TabIndex = 35;
            // 
            // lblSysType
            // 
            this.lblSysType.AutoSize = true;
            this.lblSysType.Location = new System.Drawing.Point(9, 206);
            this.lblSysType.Name = "lblSysType";
            this.lblSysType.Size = new System.Drawing.Size(71, 17);
            this.lblSysType.TabIndex = 34;
            this.lblSysType.Text = "Sys. Type";
            // 
            // combBoxLvl
            // 
            this.combBoxLvl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBoxLvl.FormattingEnabled = true;
            this.combBoxLvl.Location = new System.Drawing.Point(90, 293);
            this.combBoxLvl.Name = "combBoxLvl";
            this.combBoxLvl.Size = new System.Drawing.Size(243, 24);
            this.combBoxLvl.TabIndex = 33;
            // 
            // combBoxLayer
            // 
            this.combBoxLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBoxLayer.FormattingEnabled = true;
            this.combBoxLayer.Location = new System.Drawing.Point(90, 67);
            this.combBoxLayer.Name = "combBoxLayer";
            this.combBoxLayer.Size = new System.Drawing.Size(227, 24);
            this.combBoxLayer.TabIndex = 32;
            this.combBoxLayer.SelectedIndexChanged += new System.EventHandler(this.CombBoxLayer_SelectedIndexChanged);
            // 
            // lblRefLvl
            // 
            this.lblRefLvl.AutoSize = true;
            this.lblRefLvl.Location = new System.Drawing.Point(9, 296);
            this.lblRefLvl.Name = "lblRefLvl";
            this.lblRefLvl.Size = new System.Drawing.Size(68, 17);
            this.lblRefLvl.TabIndex = 31;
            this.lblRefLvl.Text = "Ref.Level";
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(10, 346);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(46, 17);
            this.lblOffset.TabIndex = 30;
            this.lblOffset.Text = "Offset";
            // 
            // combBoxUnit
            // 
            this.combBoxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBoxUnit.FormattingEnabled = true;
            this.combBoxUnit.Location = new System.Drawing.Point(258, 342);
            this.combBoxUnit.Name = "combBoxUnit";
            this.combBoxUnit.Size = new System.Drawing.Size(81, 24);
            this.combBoxUnit.TabIndex = 29;
            // 
            // lblUnW
            // 
            this.lblUnW.AutoSize = true;
            this.lblUnW.Location = new System.Drawing.Point(226, 346);
            this.lblUnW.Name = "lblUnW";
            this.lblUnW.Size = new System.Drawing.Size(33, 17);
            this.lblUnW.TabIndex = 26;
            this.lblUnW.Text = "Unit";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(9, 160);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(49, 17);
            this.lblHeight.TabIndex = 25;
            this.lblHeight.Text = "Height";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(9, 111);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(44, 17);
            this.lblWidth.TabIndex = 24;
            this.lblWidth.Text = "Width";
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(90, 342);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(100, 22);
            this.txtOffset.TabIndex = 23;
            this.txtOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtOffset_KeyPress);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(90, 155);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 22);
            this.txtHeight.TabIndex = 22;
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(90, 108);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 22);
            this.txtWidth.TabIndex = 21;
            this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(264, 389);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 29);
            this.btnGenerate.TabIndex = 20;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnSaveInfo
            // 
            this.btnSaveInfo.Location = new System.Drawing.Point(14, 389);
            this.btnSaveInfo.Name = "btnSaveInfo";
            this.btnSaveInfo.Size = new System.Drawing.Size(97, 29);
            this.btnSaveInfo.TabIndex = 19;
            this.btnSaveInfo.Text = "Save Layer Info";
            this.btnSaveInfo.UseVisualStyleBackColor = true;
            this.btnSaveInfo.Click += new System.EventHandler(this.BtnSaveInfo_Click);
            // 
            // lblCadLayers
            // 
            this.lblCadLayers.AutoSize = true;
            this.lblCadLayers.Location = new System.Drawing.Point(11, 70);
            this.lblCadLayers.Name = "lblCadLayers";
            this.lblCadLayers.Size = new System.Drawing.Size(83, 17);
            this.lblCadLayers.TabIndex = 18;
            this.lblCadLayers.Text = "CAD Layers";
            // 
            // lblCadLink
            // 
            this.lblCadLink.AutoSize = true;
            this.lblCadLink.Location = new System.Drawing.Point(12, 31);
            this.lblCadLink.Name = "lblCadLink";
            this.lblCadLink.Size = new System.Drawing.Size(68, 17);
            this.lblCadLink.TabIndex = 36;
            this.lblCadLink.Text = "DWGLink";
            // 
            // combBoxCadLink
            // 
            this.combBoxCadLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBoxCadLink.FormattingEnabled = true;
            this.combBoxCadLink.Location = new System.Drawing.Point(90, 31);
            this.combBoxCadLink.Name = "combBoxCadLink";
            this.combBoxCadLink.Size = new System.Drawing.Size(243, 24);
            this.combBoxCadLink.TabIndex = 37;
            this.combBoxCadLink.SelectedIndexChanged += new System.EventHandler(this.CombBoxCadLink_SelectedIndexChanged);
            // 
            // lblDuctType
            // 
            this.lblDuctType.AutoSize = true;
            this.lblDuctType.Location = new System.Drawing.Point(9, 255);
            this.lblDuctType.Name = "lblDuctType";
            this.lblDuctType.Size = new System.Drawing.Size(73, 17);
            this.lblDuctType.TabIndex = 38;
            this.lblDuctType.Text = "Duct Type";
            // 
            // combBoxDuctType
            // 
            this.combBoxDuctType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBoxDuctType.FormattingEnabled = true;
            this.combBoxDuctType.Location = new System.Drawing.Point(90, 252);
            this.combBoxDuctType.Name = "combBoxDuctType";
            this.combBoxDuctType.Size = new System.Drawing.Size(245, 24);
            this.combBoxDuctType.TabIndex = 39;
            // 
            // PlugInDuctForm
            // 
            this.ClientSize = new System.Drawing.Size(362, 438);
            this.Controls.Add(this.combBoxDuctType);
            this.Controls.Add(this.lblDuctType);
            this.Controls.Add(this.combBoxCadLink);
            this.Controls.Add(this.lblCadLink);
            this.Controls.Add(this.combBoxSysType);
            this.Controls.Add(this.lblSysType);
            this.Controls.Add(this.combBoxLvl);
            this.Controls.Add(this.combBoxLayer);
            this.Controls.Add(this.lblRefLvl);
            this.Controls.Add(this.lblOffset);
            this.Controls.Add(this.combBoxUnit);
            this.Controls.Add(this.lblUnW);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.txtOffset);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSaveInfo);
            this.Controls.Add(this.lblCadLayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlugInDuctForm";
            this.Text = "Duct Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Constructor
        public PlugInDuctForm(Document doc)
        {
            this.doc = doc;
            generationFlag = false;
            layerDetails = new List<DuctLinkLayerDetail>();
            InitializeComponent();
            InitializeFormFromRevit();
            comboBoxCounter = 0;
        }
        #endregion

        #region ComboBoxes changed
        private void CombBoxCadLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comb = sender as ComboBox;
            FillCadLayersFromCadLinks((comb.SelectedItem as RevitImportInstanceStringer).RevitImport);
            FillLevels();
        }
        private void CombBoxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCounter > 0)
            {
                ClearBoxes();
            }
            comboBoxCounter++;
        }
        private void ClearBoxes()
        {
            combBoxLvl.SelectedItem = null;
            txtHeight.Clear();
            txtOffset.Clear();
            txtWidth.Clear();
            combBoxUnit.SelectedItem = null;
            combBoxSysType.SelectedItem = null;
            combBoxDuctType.SelectedItem = null;
        }
        #endregion

        #region Buttons Clicked
        private void BtnSaveInfo_Click(object sender, EventArgs e)
        {
            if (combBoxLvl.SelectedItem == null || combBoxLayer.SelectedItem == null ||
                combBoxCadLink.SelectedItem == null || txtHeight.Text == null || txtOffset.Text == null ||
                txtWidth.Text == null || combBoxUnit.SelectedItem == null || combBoxSysType.SelectedItem == null ||
                combBoxDuctType.SelectedText == null)
            {
                MessageBox.Show("Please enter all the values before proceeding");
            }
            else
            {
                double width = ConvertUnits(combBoxUnit.Text, (double.Parse(txtWidth.Text)));
                double height = ConvertUnits(combBoxUnit.Text, (double.Parse(txtHeight.Text)));
                double offset = ConvertUnits(combBoxUnit.Text, (double.Parse(txtOffset.Text)));

                string nameOfLayer = combBoxLayer.SelectedItem.ToString();
                Category categoryOfLayer = (combBoxLayer.SelectedItem as RevitCategoryStringer).RevitCategory;
                Level reflevel = (combBoxLvl.SelectedItem as RevitLevelStringer).RevitLevel;
                MechanicalSystemType ductType = (combBoxSysType.SelectedItem as RevitDuctSystemTypeStringer).RevitSystemType;

                layerDetails.Add(new DuctLinkLayerDetail(nameOfLayer, width, height, offset, ductType, reflevel, categoryOfLayer));
                cadLink = (combBoxCadLink.SelectedItem as RevitImportInstanceStringer).RevitImport;
                MessageBox.Show("Layer detail saved");
                comboBoxCounter = 0;
                ClearBoxes();
                

            }
        }


        /// <summary>
        /// Converts all units according to the Revit API units (Foot)
        /// </summary>
        /// <param name="unit">Unit used by the user as a string from the units combobox</param>
        /// <param name="value">Double value to be converted</param>
        /// <returns>Converted double value.</returns>
        private double ConvertUnits(string unit, double value)
        {
            if (unit == "mm")
            {
                value = MmToFoot(value);

            }
            if (unit == "m")
            {
                value = MetreToFoot(value);

            }
            if (unit == "inch")
            {
                value = new RevitUnitConverter(value, Unit.Inch).ConvertedValue;
            }
            return value;
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            generationFlag = true;
            this.Close();
        }

        #endregion

        #region Textboxes handling
        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TxtOffset_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point.
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            // only allow one negative sign.
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }


        #endregion

        #region Filling Form
        /// <summary>
        /// Forms a filtered Element collector having all the Cad Links in a project.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private FilteredElementCollector CollectCadLinks(Document doc, string name)
        {
            FilteredElementCollector cadLinksCollector = new FilteredElementCollector(doc);
            cadLinksCollector.OfClass(typeof(ImportInstance)).WhereElementIsNotElementType();

            cadLinksCollector.Where(inst =>
            {
                return (doc.GetElement(inst.GetTypeId()).Name.Contains(name.ToLower())
                     ||
                       doc.GetElement(inst.GetTypeId()).Name.Contains(name.ToUpper()));
            });
            return cadLinksCollector;
        }

        /// <summary>
        /// Fills the combobox of cad links.
        /// </summary>
        private void FillCadLinks()
        {
            ImportInstance instance;
            FilteredElementCollector cadLinksCollector = CollectCadLinks(doc, @".dwg");
            foreach (Element elem in cadLinksCollector)
            {
                instance = elem as ImportInstance;
                combBoxCadLink.Items.Add(new RevitImportInstanceStringer(instance, doc));
            }
        }

        /// <summary>
        /// Fills the combobox of layers based on the cad link.
        /// </summary>
        /// <param name="importedInstance">Cad link of the combobox of links.</param>
        private void FillCadLayersFromCadLinks(ImportInstance importedInstance)
        {
            combBoxLayer.Items.Clear();
            var cadLink = importedInstance;
            var categoryMap = cadLink.Category.SubCategories;

            foreach (Category c in categoryMap)
            {
                combBoxLayer.Items.Add(new RevitCategoryStringer(c));
            }
        }

        /// <summary>
        /// Collecting Levels from the active document.
        /// </summary>
        /// <param name="doc">Active Revit document.</param>
        /// <returns>Collector of levels.</returns>
        private FilteredElementCollector CollectLevels(Document doc)
        {
            FilteredElementCollector levelCollector = new FilteredElementCollector(doc);
            levelCollector.OfClass(typeof(Level)).WhereElementIsNotElementType();
            return levelCollector;
        }

        /// <summary>
        /// Fills the combobox of Levels.
        /// </summary>
        private void FillLevels()
        {
            combBoxLvl.Items.Clear();
            Level lvl;
            var collector = CollectLevels(doc);
            foreach (Element elem in collector)
            {
                lvl = elem as Level;
                combBoxLvl.Items.Add(new RevitLevelStringer(lvl));
            }
            if (combBoxCadLink.SelectedItem != null)
            {
                combBoxLvl.Items.Add(new RevitCadLevelStringer(doc,
                 (combBoxCadLink.SelectedItem as RevitImportInstanceStringer).RevitImport));
            }
        }

        /// <summary>
        /// Collects all the mechanical system types from the active Revit document.
        /// </summary>
        /// <param name="doc">Active Revit document</param>
        /// <returns>System collector.</returns>
        private FilteredElementCollector CollectDuctSystemTypes(Document doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(MechanicalSystemType));
            return collector;
        }

        /// <summary>
        /// Fills the combobox of duct system types.
        /// </summary>
        private void FillDuctSystemTypes()
        {
            MechanicalSystemType sysType;
            var collector = CollectDuctSystemTypes(doc);
            foreach (Element elem in collector)
            {
                sysType = elem as MechanicalSystemType;
                combBoxSysType.Items.Add(new RevitDuctSystemTypeStringer(sysType));
            }
        }

        /// <summary>
        /// Fills the combobox of the units.
        /// </summary>
        private void FillUnits()
        {
            var units = new string[] { "mm", "m", "inch", "ft" };
            combBoxUnit.Items.AddRange(units);
        }

        /// <summary>
        /// Collects all the duct types in the active Revit document.
        /// </summary>
        /// <param name="doc">Active document.</param>
        /// <returns>Duct type collector.</returns>
        private FilteredElementCollector CollectDuctTypes(Document doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(DuctType)).WhereElementIsElementType();

            return collector;
        }

        /// <summary>
        /// Fills the combobox of the duct types.
        /// </summary>
        private void FillDuctTypes()
        {
            DuctType ductType;
            var collector = CollectDuctTypes(doc);
            foreach (Element elem in collector)
            {
                ductType = elem as DuctType;
                combBoxDuctType.Items.Add(new RevitDuctTypeStringer(ductType));
            }
        }

        #endregion

        #region Initialize Form
        /// <summary>
        /// Initializes and fills every combobox interacting with Autodesk Revit.
        /// </summary>
        private void InitializeFormFromRevit()
        {
            FillCadLinks();
            FillLevels();
            FillDuctSystemTypes();
            FillUnits();
            FillDuctTypes();
        }
        #endregion

    }
}
