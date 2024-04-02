using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using SMS;
using System.Windows.Forms;
using ITNepal.MainLibrary.SAPB1;
using System.Globalization;


namespace ITNepal.SMSIntegration.Forms
{
    [FormAttribute("133", "Forms/AR Invoice.b1f")]
    class AR_Invoice : SystemFormBase
    {
        private static Log.Logger _Logger;
        private static SPARROWSMS _SparrowSMS;

        //private SAPbouiCOM.Button AddButton;
        //private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.EditText CardCode { get; set; }
        private SAPbouiCOM.EditText CardName { get; set; }
        private SAPbouiCOM.EditText DocDate { get; set; }
        //private SAPbouiCOM.EditText VhclNo { get; set; }
        //private SAPbouiCOM.EditText DrivNo { get; set; }
        //private SAPbouiCOM.EditText TransName { get; set; }
        private SAPbouiCOM.EditText DocNum { get; set; }
        
        

        SAPbouiCOM.Application oApp = SAPbouiCOM.Framework.Application.SBO_Application;
        private SAPbobsCOM.Recordset recordSet = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);


        public AR_Invoice()
        {
            _Logger = new Log.Logger();
            _SparrowSMS = new SPARROWSMS();
        }



        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            //   this.AddButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            //   this.AddButton.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.AddButton_ClickAfter);
            this.CardCode = ((SAPbouiCOM.EditText)(this.GetItem("4").Specific));
            this.CardName = ((SAPbouiCOM.EditText)(this.GetItem("54").Specific));
            this.DocDate = ((SAPbouiCOM.EditText)(this.GetItem("10").Specific));

            //this.VhclNo = ((SAPbouiCOM.EditText)(this.GetItem("U_T2").Specific));
            //this.DrivNo = ((SAPbouiCOM.EditText)(this.GetItem("U_T4").Specific));
            //this.TransName = ((SAPbouiCOM.EditText)(this.GetItem("U_T1").Specific));

            this.DocNum = ((SAPbouiCOM.EditText)(this.GetItem("8").Specific));
            //this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("6").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("7").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("40").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("41").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("43").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("44").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("61").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("92").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("93").Specific));
            this.CheckBox0 = ((SAPbouiCOM.CheckBox)(this.GetItem("104").Specific));
            this.CheckBox1 = ((SAPbouiCOM.CheckBox)(this.GetItem("106").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("121").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("122").Specific));
            this.CheckBox2 = ((SAPbouiCOM.CheckBox)(this.GetItem("126").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("131").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("130").Specific));
            this.OptionBtn0 = ((SAPbouiCOM.OptionBtn)(this.GetItem("132").Specific));
            this.OptionBtn1 = ((SAPbouiCOM.OptionBtn)(this.GetItem("133").Specific));
            this.CheckBox3 = ((SAPbouiCOM.CheckBox)(this.GetItem("136").Specific));
            this.CheckBox4 = ((SAPbouiCOM.CheckBox)(this.GetItem("137").Specific));
            this.CheckBox5 = ((SAPbouiCOM.CheckBox)(this.GetItem("144").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("145").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("146").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("154").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("155").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("168").Specific));
            this.ComboBox3 = ((SAPbouiCOM.ComboBox)(this.GetItem("169").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("223").Specific));
            this.ComboBox4 = ((SAPbouiCOM.ComboBox)(this.GetItem("224").Specific));
            this.ComboBox5 = ((SAPbouiCOM.ComboBox)(this.GetItem("226").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("233").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("234").Specific));
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("238").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("240").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("241").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("242").Specific));
            this.ComboBox6 = ((SAPbouiCOM.ComboBox)(this.GetItem("243").Specific));
            this.ComboBox7 = ((SAPbouiCOM.ComboBox)(this.GetItem("244").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("245").Specific));
            this.ComboBox8 = ((SAPbouiCOM.ComboBox)(this.GetItem("246").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("247").Specific));
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("249").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("250").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("251").Specific));
            this.ComboBox9 = ((SAPbouiCOM.ComboBox)(this.GetItem("216").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("217").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("218").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("219").Specific));
            this.ComboBox10 = ((SAPbouiCOM.ComboBox)(this.GetItem("220").Specific));
            this.ComboBox11 = ((SAPbouiCOM.ComboBox)(this.GetItem("294").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("295").Specific));
            this.ComboBox12 = ((SAPbouiCOM.ComboBox)(this.GetItem("296").Specific));
            this.Button5 = ((SAPbouiCOM.Button)(this.GetItem("10002101").Specific));
            this.Button6 = ((SAPbouiCOM.Button)(this.GetItem("10002102").Specific));
            this.CheckBox6 = ((SAPbouiCOM.CheckBox)(this.GetItem("1320002125").Specific));
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("1720002172").Specific));
            this.Button7 = ((SAPbouiCOM.Button)(this.GetItem("1720002173").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("1320002174").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("1320002175").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("1320002176").Specific));
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("1320002177").Specific));
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("1320002178").Specific));
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("1320002179").Specific));
            this.EditText13 = ((SAPbouiCOM.EditText)(this.GetItem("1320002180").Specific));
            this.LinkedButton2 = ((SAPbouiCOM.LinkedButton)(this.GetItem("1320002181").Specific));
            this.StaticText19 = ((SAPbouiCOM.StaticText)(this.GetItem("1320002182").Specific));
            this.StaticText20 = ((SAPbouiCOM.StaticText)(this.GetItem("1470002189").Specific));
            this.ComboBox13 = ((SAPbouiCOM.ComboBox)(this.GetItem("1470002190").Specific));
            this.StaticText21 = ((SAPbouiCOM.StaticText)(this.GetItem("1980000524").Specific));
            this.Button8 = ((SAPbouiCOM.Button)(this.GetItem("1980000525").Specific));
            this.StaticText22 = ((SAPbouiCOM.StaticText)(this.GetItem("253000600").Specific));
            this.EditText14 = ((SAPbouiCOM.EditText)(this.GetItem("253000601").Specific));
            this.StaticText23 = ((SAPbouiCOM.StaticText)(this.GetItem("253000602").Specific));
            this.EditText15 = ((SAPbouiCOM.EditText)(this.GetItem("253000603").Specific));
            this.CheckBox7 = ((SAPbouiCOM.CheckBox)(this.GetItem("254000001").Specific));
            this.StaticText24 = ((SAPbouiCOM.StaticText)(this.GetItem("242000599").Specific));
            this.EditText16 = ((SAPbouiCOM.EditText)(this.GetItem("242000600").Specific));
            this.CheckBox8 = ((SAPbouiCOM.CheckBox)(this.GetItem("254000066").Specific));
            this.StaticText25 = ((SAPbouiCOM.StaticText)(this.GetItem("254000064").Specific));
            this.StaticText26 = ((SAPbouiCOM.StaticText)(this.GetItem("256000007").Specific));
            this.Button9 = ((SAPbouiCOM.Button)(this.GetItem("256000008").Specific));
            this.StaticText27 = ((SAPbouiCOM.StaticText)(this.GetItem("256000004").Specific));
            this.ComboBox14 = ((SAPbouiCOM.ComboBox)(this.GetItem("256000005").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("38").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataAddAfter += new SAPbouiCOM.Framework.FormBase.DataAddAfterHandler(this.Form_DataAddAfter);
            //this.DataUpdateAfter += new DataUpdateAfterHandler(this.Form_DataUpdateAfter);

        }

        private void OnCustomInitialize() { }

        /// <summary>
        /// This event is called once the A/R invoice Form is created
        /// Sends SMS to the user 
        /// Logs error to a file if Failed to send SMS 
        /// </summary>   


        private void Form_DataAddAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SendSMS();

        }



        private void SendSMS()
        {
            //build sql query    

            //string query = "SELECT ";
            //query += "  T0.\"U_ITN_DrivNum\" AS \"Driver License Number\" ";
            //query += ", REPLACE(IFNULL(T0.\"U_ITN_TransPhone\", '' ),'+977','') AS \"Driver Phone Number\" ";
            //query += ", T0.\"U_ITN_TtlFr\" AS \"Freight To Pay\" ";
            //query += ", T1.\"Dscription\" AS \"Item Description\" ";
            //query += ", T1.\"Quantity\" AS \"Quantity\" ";
            //query += ", T0.\"DocTotal\" AS \"Balance Due\" ";
            //query += ", REPLACE(IFNULL(T2.\"Cellular\", '' ),'+977','')   AS \"Customer Phone Number\" ";
            //query += "  FROM OINV T0 ";
            //query += "  INNER JOIN INV1 T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
            //query += "  INNER JOIN OCRD T2 ON T0.\"CardCode\" = T2.\"CardCode\" ";
            //query += "  WHERE T0.\"CardCode\"= '" + this.CardCode.Value + "'";
            //query += "  AND T0.\"DocNum\" ='" + this.DocNum.Value + "' ";
            //query += "AND T0.\"DocEntry\" =(SELECT \"DocEntry\" FROM OINV WHERE \"DocNum\" = '" + this.DocNum.Value + "')";

            string query = "SELECT TOP 1 \"Cellular\" FROM OCRD WHERE \"CardCode\"= '" + this.CardCode.Value + "' ";

            try
            {
                //create variables to hold data
                var itemDescription = string.Empty;
                var quantity = string.Empty;
                var CardName = this.CardName.Value;
                var DocDate = this.DocDate.Value;
                //var VhclNo  =this.VhclNo.Value;
                //var DrivNo = this.DrivNo.Value;
                //var TransName = this.TransName.Value;

                //var vehicleLicensePlate = string.Empty;
                //var driverMobileNumber = string.Empty;
                var VhclNo  = string.Empty;
                var DrivNo = string.Empty;
                var TransName = string.Empty;
                var customerMobileNumber = string.Empty;
                var docNum = this.DocNum.Value;
                var totalBalanceDue = string.Empty;
                var UOM = string.Empty;
                //var freightToPay = string.Empty;
                docNum = this.DocNum.Value;
                StringBuilder messageSb = new StringBuilder();


                #region fetch data
                recordSet.DoQuery(query);
                #endregion fetch data
                int count = Matrix0.RowCount;
                var Desc=string.Empty;
                var Desc1 = string.Empty;
                decimal TotalQty = 0; 
                for (int i = 1; i < count; i++)
                {

                    itemDescription = Matrix0.GetCellValue("3", i).ToString();
                    quantity = Matrix0.GetCellValue("11", i).ToString();
                    VhclNo = UIAPIRawForm.DataSources.DBDataSources.Item(0).GetValue("U_T2", 0);//((SAPbouiCOM.EditText)(this.GetItem("U_CANCELED").Specific)).Value;//(this.GetItem("U_T2").Specific)).Value;
                    DrivNo = UIAPIRawForm.DataSources.DBDataSources.Item(0).GetValue("U_T4", 0);//((SAPbouiCOM.EditText)(this.GetItem("U_WAYBILNO").Specific)).Value;//(this.GetItem("U_T4").Specific)).Value;
                    TransName = UIAPIRawForm.DataSources.DBDataSources.Item(0).GetValue("U_T1", 0);
                    //((SAPbouiCOM.EditText)(this.GetItem("U_THOKANO").Specific)).Value;//(this.GetItem("U_T1").Specific)).Value;
                    customerMobileNumber = recordSet.Fields.Item("Cellular").Value.ToString();
                    totalBalanceDue = ((SAPbouiCOM.EditText)(this.GetItem("29").Specific)).Value;
                    UOM = Matrix0.GetCellValue("1470002145", i).ToString();
                    // freightToPay = (((SAPbouiCOM.EditText)(this.GetItem("U_ITN_TtlFr").Specific)).Value);
                    Desc = itemDescription + " : " + Math.Round(Convert.ToDouble(quantity), 2) + UOM +" " ;
                    Desc1 = Desc + Desc1;
                    TotalQty = Convert.ToDecimal(quantity) + Convert.ToDecimal(TotalQty);
                }
                //decimal freight;
                //decimal.TryParse(freightToPay, out freight);
                //freightToPay = String.Format("{0:0.00}", freight);

                //######## build message ############
                //var message = string.Format(
                //              "Pls find info of dispatch from MIPL: Bill#: {0}, Truck#: {1}, Mob#: {2}, Total Rs.: {3}, Freight To Pay: {4}.Thanks.",
                //               docNum, vehicleLicensePlate, driverMobileNumber, totalBalanceDue, freightToPay);
                //DateTime DTDoc = Convert.ToDateTime(DocDate);
                //string Date = DocDate.ToString("yyyy/MM/dd");

                var message = string.Format(
                             "Sarbottam Steel:\n{0} - {1} {2} sold on {3}.\nSize Details: {4}\nOther Details: BillNo: {5}, VehNo: {6}, DRVNo: {7},Rs: {8}\nSite: {9}\nClaim nondelivery within5 Days,if not,claim won't be accepted.\nSSL Tinkune, 01 - 4117506",
                             CardName, Math.Round(TotalQty, 2),UOM, DocDate, Desc1,docNum, VhclNo, DrivNo, totalBalanceDue,TransName);

                

                messageSb.AppendLine(message);

                #region send sms
                if (!string.IsNullOrEmpty(customerMobileNumber)) // if we have mobile number -- send sms 
                {
                    var SMSmessage = messageSb.ToString(); //"Test Demo SMS"; //

                    try
                    {
                        var response = _SparrowSMS.SendSMS(customerMobileNumber, SMSmessage);

                        if (!response)
                            oApp.MessageBox(string.Format("Sorry unable to send notification via sms to {0}.", customerMobileNumber));
                        else
                            oApp.MessageBox(string.Format("Notification sent successfully to {0} via SMS.", customerMobileNumber));
                    }
                    catch (Exception ex)
                    {
                        oApp.MessageBox(string.Format("Sorry unable to send notification via sms to {0}.", customerMobileNumber));
                    }
                }
                else // no mobile number found -- show message
                {
                    oApp.MessageBox(string.Format("Sorry could not send notification via sms because no mobile number is found for Business # {0}.", this.CardCode.Value));
                }

                #endregion send sms
            }
            catch (Exception ex)
            {
                oApp.MessageBox(string.Format("Sorry unable to send notification via sms.Error encountered : ", ex));
            }
        }


        

        private void Form_DataUpdateAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SendSMS();
        }


        #region declaration
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.ComboBox ComboBox0;
       // private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.CheckBox CheckBox0;
        private SAPbouiCOM.CheckBox CheckBox1;
        private SAPbouiCOM.ComboBox ComboBox2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.CheckBox CheckBox2;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.OptionBtn OptionBtn0;
        private SAPbouiCOM.OptionBtn OptionBtn1;
        private SAPbouiCOM.CheckBox CheckBox3;
        private SAPbouiCOM.CheckBox CheckBox4;
        private SAPbouiCOM.CheckBox CheckBox5;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.ComboBox ComboBox3;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.ComboBox ComboBox4;
        private SAPbouiCOM.ComboBox ComboBox5;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.ComboBox ComboBox6;
        private SAPbouiCOM.ComboBox ComboBox7;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.ComboBox ComboBox8;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.Button Button4;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.ComboBox ComboBox9;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.ComboBox ComboBox10;
        private SAPbouiCOM.ComboBox ComboBox11;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.ComboBox ComboBox12;
        private SAPbouiCOM.Button Button5;
        private SAPbouiCOM.Button Button6;
        private SAPbouiCOM.CheckBox CheckBox6;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.Button Button7;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.EditText EditText12;
        private SAPbouiCOM.LinkedButton LinkedButton1;
        private SAPbouiCOM.StaticText StaticText18;
        private SAPbouiCOM.EditText EditText13;
        private SAPbouiCOM.LinkedButton LinkedButton2;
        private SAPbouiCOM.StaticText StaticText19;
        private SAPbouiCOM.StaticText StaticText20;
        private SAPbouiCOM.ComboBox ComboBox13;
        private SAPbouiCOM.StaticText StaticText21;
        private SAPbouiCOM.Button Button8;
        private SAPbouiCOM.StaticText StaticText22;
        private SAPbouiCOM.EditText EditText14;
        private SAPbouiCOM.StaticText StaticText23;
        private SAPbouiCOM.EditText EditText15;
        private SAPbouiCOM.CheckBox CheckBox7;
        private SAPbouiCOM.StaticText StaticText24;
        private SAPbouiCOM.EditText EditText16;
        private SAPbouiCOM.CheckBox CheckBox8;
        private SAPbouiCOM.StaticText StaticText25;
        private SAPbouiCOM.StaticText StaticText26;
        private SAPbouiCOM.Button Button9;
        private SAPbouiCOM.StaticText StaticText27;
        private SAPbouiCOM.ComboBox ComboBox14;
        private SAPbouiCOM.Matrix Matrix0;

        #endregion

    }
}
