using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;


namespace ITNepal.SMSIntegration.Forms
{
    [FormAttribute("183", "Forms/Print Preferences.b1f")]
    class Print_Preferences : SystemFormBase
    {
    //////    public Print_Preferences()
    //////    {
    //////    }

    //////    /// <summary>
    //////    /// Initialize components. Called by framework after form created.
    //////    /// </summary>
    //////    public override void OnInitializeComponent()
    //////    {
    //////        this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_1").Specific));
    //////        this.Folder0.PressedAfter += new SAPbouiCOM._IFolderEvents_PressedAfterEventHandler(this.Folder0_PressedAfter);
    //////        this.Folder0.GroupWith("234000011");
    //////        this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
    //////        this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
    //////        this.CheckBox0 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_5").Specific));
    //////        this.txtSmsBody = ((SAPbouiCOM.EditText)(this.GetItem("Item_8").Specific));
    //////        this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
    //////        this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
    //////        this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
    //////        this.EditText2.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText2_ChooseFromListAfter);
    //////        this.txtObjCode = ((SAPbouiCOM.EditText)(this.GetItem("Item_0").Specific));
    //////        this.txtObjCode.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtObjCode_ChooseFromListAfter);
    //////        this.txtObjName = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
    //////        this.oForm = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
    //////        this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("43").Specific));
    //////        this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
    //////        this.Button1.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button1_PressedAfter);

    //////        this.OnCustomInitialize();

    //////    }

    //////    /// <summary>
    //////    /// Initialize form event. Called by framework before form creation.
    //////    /// </summary>
    //////    public override void OnInitializeFormEvents()
    //////    {
    //////    }

    //////    private void OnCustomInitialize()
    //////    {
    //////        Folder1.Item.Click();
    //////    }

    //////    private SAPbouiCOM.Folder Folder0;
    //////    private SAPbouiCOM.StaticText StaticText1;
    //////    private SAPbouiCOM.StaticText StaticText2;
    //////    private SAPbouiCOM.CheckBox CheckBox0;
    //////    private SAPbouiCOM.EditText txtSmsBody;
    //////    private SAPbouiCOM.StaticText StaticText4;
    //////    private SAPbouiCOM.StaticText StaticText5;
    //////    private SAPbouiCOM.EditText EditText2;
    //////    private SAPbobsCOM.Recordset Rec;
    //////    private SAPbouiCOM.Form oForm;
    //////    private SAPbouiCOM.Button Button1;
    //////    private SAPbouiCOM.Folder Folder1;
    //////    private SAPbouiCOM.EditText txtObjCode;
    //////    private SAPbouiCOM.EditText txtObjName;


    //////    private void Folder0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
    //////    {
    //////        this.UIAPIRawForm.PaneLevel = 90;
    //////    }
    //////    private void Button1_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
    //////    {
    //////        try
    //////        {
    //////            string active = CheckBox0.Checked ? "Y" : "N";
    //////            string query = "update ADP1 set \"U_ITN_SMSACTIVE\"='" + active + "',\"U_ITN_SMSBODY\"='" + txtSmsBody.Value + "' where \"ObjType\"='" + txtObjCode.Value + "'";
    //////            Rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);                
    //////            Rec.DoQuery(query);
    //////        }
    //////        catch (Exception ex)
    //////        {
    //////            Program.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
    //////        }
    //////    }


    //////    private void EditText2_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
    //////    {
    //////        try
    //////        {
    //////            SAPbouiCOM.ISBOChooseFromListEventArg cflist = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
    //////            SAPbouiCOM.DataTable oTable = cflist.SelectedObjects;
    //////            txtSmsBody.Value = oTable.GetValue("Text", 0).ToString();
    //////        }
    //////        catch
    //////        {
    //////        }

    //////    }



    //////    private void txtObjCode_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
    //////    {
    //////        SAPbouiCOM.ISBOChooseFromListEventArg cflist = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
    //////        SAPbouiCOM.DataTable oTable = cflist.SelectedObjects;
    //////        try
    //////        {
    //////            txtObjCode.Value = oTable.GetValue("Code", 0).ToString();
    //////        }
    //////        catch
    //////        {
    //////        }
    //////        try
    //////        {
    //////            this.GetItem("Item_3").Enabled = true;
    //////            txtObjName.Value = oTable.GetValue("Name", 0).ToString();
    //////            this.GetItem("Item_0").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
    //////            this.GetItem("Item_3").Enabled = false;
    //////            LoadSmsDetails();
    //////        }
    //////        catch
    //////        {
    //////        }
    //////    }

    //////    private void LoadSmsDetails()
    //////    {
    //////        try
    //////        {
    //////            txtSmsBody.Value = "";
    //////            CheckBox0.Checked = false;
    //////            string query = "Select \"U_ITN_SMSACTIVE\",\"U_ITN_SMSBODY\" from ADP1 where \"ObjType\"='" + txtObjCode.Value + "'";
    //////            Rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
    //////            Rec.DoQuery(query);
    //////            if (Rec.RecordCount > 0)
    //////            {
    //////                bool Active=(Rec.Fields.Item("U_ITN_SMSACTIVE").Value.ToString()=="Y")?true:false;
    //////                txtSmsBody.Value = Rec.Fields.Item("U_ITN_SMSBODY").Value.ToString();
    //////                CheckBox0.Checked = Active; 
    //////            }
    //////        }
    //////        catch (Exception ex)
    //////        {
    //////            Program.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
    //////        }
    //////    }


    }
}
