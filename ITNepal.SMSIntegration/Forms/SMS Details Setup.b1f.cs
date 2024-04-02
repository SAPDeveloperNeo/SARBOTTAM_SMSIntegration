using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using ITNepal.MainLibrary.SAPB1;


namespace ITNepal.SMSIntegration.Forms
{
    [FormAttribute("ITNepal.SMSIntegration.Forms.SMS_Details_Setup", "Forms/SMS Details Setup.b1f")]
    class SMS_Details_Setup : UserFormBase
    {
        public SMS_Details_Setup()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.txtObjCode = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.txtObjCode.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.txtObjCode_ChooseFromListAfter);
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_2").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.Button0_PressedBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.txtObjName = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.txtDocNo = ((SAPbouiCOM.EditText)(this.GetItem("Item_6").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.oForm = ((SAPbouiCOM.Form)(this.UIAPIRawForm));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }



        private void OnCustomInitialize()
        {
            Program.SBO_Application.MenuEvent += this.SBO_Application_MenuEvent;
            oForm.EnableMenu("1292", true);
            oForm.EnableMenu("1288", true);
            oForm.EnableMenu("1289", true);
            oForm.EnableMenu("1290", true);
            oForm.EnableMenu("1291", true);
        
            if (!oForm.Menu.Exists("12931"))
                UIAPIRawForm.Menu.Add("12931", "Delete Row", SAPbouiCOM.BoMenuType.mt_STRING, 5);
            txtDocNo.Value = B1Helper.GetNextDocNum("@ITN_OSMS").ToString();
            Extentions.AddLine(Matrix0);
            Extentions.SetLineId(Matrix0);
            Matrix0.AutoResizeColumns();



        }

        private SAPbouiCOM.EditText txtObjCode;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.EditText txtObjName;
        private SAPbouiCOM.EditText txtDocNo;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.Form oForm;
        private SAPbobsCOM.Recordset Rec;


        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (pVal.BeforeAction)
                {

                    if (pVal.MenuUID == "1292")
                    {
                        try
                        {
                            Extentions.AddLine(Matrix0);
                            Extentions.SetLineId(Matrix0);
                            BubbleEvent = false;
                        }
                        catch (Exception ex)
                        { }

                    }
                    if (pVal.MenuUID == "12931")
                    {
                        int vrowcount = Matrix0.VisualRowCount;

                        for (int i = vrowcount; i >= 1; i--)
                        {
                            if (Matrix0.IsRowSelected(i))
                            {
                                Matrix0.DeleteRow(i);
                            }
                        }
                        if (UIAPIRawForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                            UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                        try
                        {
                            for (int j = 1; j <= Matrix0.VisualRowCount; j++)
                            {
                                ((SAPbouiCOM.EditText)Matrix0.Columns.Item("#").Cells.Item(j).Specific).Value = j.ToString();
                            }
                        }
                        catch
                        {

                        }
                    }
                }

            }
            catch
            {

            }
        }

        private void txtObjCode_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg cflist = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable oTable = cflist.SelectedObjects;
            try
            {
                txtObjCode.Value = oTable.GetValue("Code", 0).ToString();
            }
            catch
            {
            }
            try
            {
                this.GetItem("Item_5").Enabled = true;
                txtObjName.Value = oTable.GetValue("Name", 0).ToString();
                this.GetItem("Item_1").Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                this.GetItem("Item_5").Enabled = false;
            }
            catch
            {
            }

        }

        private void DeleteBlankRow()
        {
            for (int Row = Matrix0.RowCount; Row >= 1; Row--)
            {
                SAPbouiCOM.EditText Code = Matrix0.GetCellSpecific("Col_0", Matrix0.RowCount) as SAPbouiCOM.EditText;
                if (string.IsNullOrEmpty(Code.Value))
                {
                    Matrix0.DeleteRow(Row);
                }
                else
                {
                    break;
                }
            }
        }

        private void Button0_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (!Validate())
                    BubbleEvent = false;
            }
            catch (Exception ex)
            {
                Program.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtObjName.Value))
            {
                Program.SBO_Application.SetStatusBarMessage("Object Code is mandatory", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return false;
            }
            if (oForm.Mode==SAPbouiCOM.BoFormMode.fm_ADD_MODE
                && DocAlreadyExists() )
            {
                Program.SBO_Application.SetStatusBarMessage("Document Already Exists", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                return false;
            }
            return true;
        }

        private bool DocAlreadyExists()
        {
            string query="Select * from \"@ITN_OSMS\" where U_ITN_OBJLST='"+txtObjCode.Value+"'";
            Rec = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            Rec.DoQuery(query);
            if (Rec.RecordCount > 0)
            {
                return true;
            }
          
            return false;
           
        }






    }
}
