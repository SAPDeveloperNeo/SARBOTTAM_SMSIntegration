using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using SMS;

namespace ITNepal.SMSIntegration.Forms
{
    [FormAttribute("426", "Forms/Outgoing Payments.b1f")]
    public class Outgoing_Payments : SystemFormBase
    {
        //////private static Log.Logger _Logger;
        //////private static SPARROWSMS _SparrowSMS;


        //////private SAPbouiCOM.Button AddButton;
        //////private SAPbouiCOM.EditText CardCode { get; set; }
        //////private SAPbouiCOM.EditText DocNum { get; set; }
        //////private SAPbouiCOM.EditText TransId { get; set; }

        //////SAPbouiCOM.Application oApp = SAPbouiCOM.Framework.Application.SBO_Application;
        //////private SAPbobsCOM.Recordset recordSet = (SAPbobsCOM.Recordset)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

        //////public Outgoing_Payments()
        //////{
        //////    _Logger = new Log.Logger();
        //////    _SparrowSMS = new SPARROWSMS();
        //////}


        ///////// <summary>
        ///////// Initialize components. Called by framework after form created.
        ///////// </summary>
        //////public override void OnInitializeComponent()
        //////{
        //////    //this.AddButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
        //////    //this.AddButton.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.AddButton_ClickAfter);
        //////    this.CardCode = ((SAPbouiCOM.EditText)(this.GetItem("5").Specific));
        //////    this.DocNum = ((SAPbouiCOM.EditText)(this.GetItem("3").Specific));
        //////    this.TransId = ((SAPbouiCOM.EditText)(this.GetItem("52").Specific));
        //////    this.OnCustomInitialize();
        //////}

        ///////// <summary>
        ///////// Initialize form event. Called by framework before form creation.
        ///////// </summary>
        //////public override void OnInitializeFormEvents()
        //////{
        //////    this.DataAddAfter += new DataAddAfterHandler(this.Form_DataAddAfter);
        //////}
        //////private void OnCustomInitialize() { }


        ///////// <summary>
        ///////// Ths events gets called after Outgoing Payments Form Creation
        ///////// Sends SMS to the user 
        ///////// Logs error to a file if Failed to send SMS 
        ///////// </summary>

        //////private void Form_DataAddAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        //////{
        //////    //build sql query
           
        //////    string DocEntry = UIAPIRawForm.DataSources.DBDataSources.Item("OVPM").GetValue("DocEntry", 0);

        //////    string query = "SELECT";
        //////    query += "   T0.\"CardName\"        AS \"Customer Name\" ";
        //////    query += " , T1.\"U_ITN_VHNO\"      AS \"RV Number\" ";
        //////    query += " , REPLACE(IFNULL(T0.\"Cellular\", '' ),'+977','')       AS \"Customer Mobile Number\" ";
        //////    query += " , T1.\"DocTotal\"        AS \"Total Amount Due\" ";
        //////    query += " , CASE ";
        //////    query += "  WHEN IFNULL(T1.\"CashSum\",0)  > 0  THEN 'Cash' ";
        //////    query += "  WHEN IFNULL(T1.\"CheckSum\",0) > 0  THEN 'Cheque' ";
        //////    query += "  WHEN IFNULL(T1.\"TrsfrSum\",0) > 0  THEN 'Bank Transfer' ";
        //////    query += "  WHEN IFNULL(T1.\"CreditSum\",0) > 0 THEN 'EFTPOS' ";
        //////    query += "  END AS \"Payment Method Type\" ";
        //////    query += ", CASE  ";
        //////    query += "  WHEN IFNULL(T1.\"CashSum\",0)>0 THEN T1.\"CashSum\" ";
        //////    query += "  WHEN IFNULL(T1.\"CheckSum\",0)>0 THEN T1.\"CheckSum\" ";
        //////    query += "  WHEN IFNULL(T1.\"TrsfrSum\",0)>0 THEN T1.\"TrsfrSum\" ";
        //////    query += "  WHEN IFNULL(T1.\"CreditSum\",0)>0 THEN T1.\"CreditSum\" ";
        //////    query += "  END AS \"Payment Amount\" ";
        //////    query += " FROM OCRD T0  ";
        //////    query += " INNER JOIN  OVPM T1 ON T1.\"CardCode\" = T0.\"CardCode\"  ";
        //////    query += " WHERE T0.\"CardCode\" = '" + this.CardCode.Value + "' ";
        //////    query += "  AND T1.\"DocNum\" = " + this.DocNum.Value + " ";
        //////    query += "  AND T1.\"TransId\" = (SELECT \"TransId\" FROM OVPM WHERE \"DocEntry\" = '"+ DocEntry+"')";

        //////    try
        //////    {
        //////        #region fetch data
        //////        recordSet.DoQuery(query);

        //////        var customerName = recordSet.Fields.Item("Customer Name").Value.ToString();
        //////        var rvNumber = recordSet.Fields.Item("RV Number").Value.ToString();
        //////        var customerMobileNumber = recordSet.Fields.Item("Customer Mobile Number").Value.ToString();
        //////        var totalAmountDue = recordSet.Fields.Item("Total Amount Due").Value.ToString();
        //////        var paymentMethodType = recordSet.Fields.Item("Payment Method Type").Value.ToString();
                             
                  
        //////        #endregion fetch data


        //////        #region send sms

        //////        if (!string.IsNullOrEmpty(customerMobileNumber)) // if we have mobile number -- send sms 
        //////        {
        //////            var message = string.Format(
        //////                "We have remitted Rs. {0}/- to {1} in {2} | RV#{3}. Thank you"
        //////                , totalAmountDue, customerName, paymentMethodType, rvNumber
        //////                );

        //////            try
        //////            {
        //////                var response = _SparrowSMS.SendSMS(customerMobileNumber, message);
        //////                if (!response)
        //////                    oApp.MessageBox(string.Format("Sorry, unable to send notification via sms to {0}.", customerMobileNumber));
        //////                else
        //////                    oApp.MessageBox(string.Format("Notification sent successfully to {0} via SMS.", customerMobileNumber));
        //////            }
        //////            catch (Exception ex)
        //////            {
        //////                oApp.MessageBox(string.Format("Sorry, unable to send notification via sms to {0}.", customerMobileNumber));
        //////            }
        //////        }
        //////        else // no mobile number found -- show message
        //////        {
        //////            oApp.MessageBox(string.Format("Sorry, could not send notification via sms because no mobile number is found for Business # {0}.", this.CardCode.Value));
        //////        }

        //////        #endregion send sms
        //////    }
        //////    catch (Exception ex)
        //////    {
        //////        oApp.MessageBox(string.Format("Sorry, unable to send notification via sms.Error encountered : ", ex.Message));
        //////    }
        //////}

    }
}

