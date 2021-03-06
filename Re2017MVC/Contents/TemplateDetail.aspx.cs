﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIChatbot.Classes;
using Ls.Prj.Entity;
using System.Text;
using Ls.Prj.DTO;
using System.Data.Entity;
using System.Collections;
using Ls.Prj.Utility;
using Re2017;
using Re2017.Classes;
using System.Globalization;
using Re2017.Base;

namespace Ls.Re2017.Contents
{
    public partial class TemplateDetail : Re2017BasePage
    {
        #region public propery of page
        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                {
                    return Convert.ToInt32(ViewState["PageNumber"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["PageNumber"] = value; }
        }
        public int TotalNumPages
        {
            get
            {
                if (ViewState["TotalNumPages"] != null)
                {
                    return Convert.ToInt32(ViewState["TotalNumPages"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["TotalNumPages"] = value; }
        }

        public string HidePreviousClass
        {
            get
            {
                if (ViewState["HidePreviousClass"] != null)
                {
                    return ViewState["HidePreviousClass"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set { ViewState["HidePreviousClass"] = value; }
        }
        public string HideNextClass
        {
            get
            {
                if (ViewState["HideNextClass"] != null)
                {
                    return ViewState["HideNextClass"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set { ViewState["HideNextClass"] = value; }
        }
        #endregion

       private  List<EventTypeDTO> LstEvtType;
        private List<HouseDTO> LstHouse;
        private List<LandlordDTO> LstLandlord;
        private List<PartyDTO> LstParty;
        public string MemIdTemp = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                TrackManagement2PageManager ObjTrackManagement2PageManager = new TrackManagement2PageManager();
                LstEvtType = ObjTrackManagement2PageManager.GetEventsType();
                LstHouse = ObjTrackManagement2PageManager.GetHouse();
                LstLandlord = ObjTrackManagement2PageManager.GetLandlords();
                LstParty = ObjTrackManagement2PageManager.GetParties();

                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["Id"]==null)
                    {
                      
                        LitTitle.Text = "Create new template";
                    }
                    else
                    {
                        LitTitle.Text = "Update template";
                        MemIdTemp = Request.QueryString["Id"].ToString();
                        ViewState["MemIdTemp"]= Request.QueryString["Id"].ToString();
                        
                        PnlSplitting.Visible = true;
                        PnlBtnCreateTemplate.Visible = false;

                    }
                    BindEvts();


                    //aggiunge il tag script con il path del file jquery con la validazione della pagina nella masterpage
                    Literal LitPathFormScriptValidation = (Literal)Master.FindControl("LitPathFormScriptValidation");

                    //LitPathFormScriptValidation.Text = "<script src='../js/TrackManagement.js'></script>";
                    //LitRe2017ScriptInject.Text= "<script src='../js/TrackManagement.js'></script>";
                    // ViewState["LstEvtType"] = LstEvtType;
                }
              
                
               

               
            }
            catch (Exception ex)
            {
                PrintError(ex);
            }

        }



        protected void BtnClose_Click(object sender, EventArgs e)
        {
            DivError.Attributes.Add("Class", "ParentDivDeleting Disattivato");

        }
        protected void BtnCloseInformation_Click(object sender, EventArgs e)
        {
            DivInformation.Attributes.Add("Class", "ParentDivDeleting Disattivato");

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Templates.aspx");
        }

        protected void LnkBtnApplyTemplate_Click(object sender, EventArgs e)
        {

        }

        protected void LnkBtnSplit_Click(object sender, EventArgs e)
        {
            TemplateDetailPageManager ObjTemplateDetailPageManager = new TemplateDetailPageManager();
           

            Evento ObjEvento = new Evento();
            try
            {
               // ObjEvento = ObjTemplateDetailPageManager.GetAsyncEvento("events/templates/" + Request.QueryString["evtId"].ToString()).Result;

          
            Evento ObjInsertEvtInput = new Evento(); //data = "{'id': 99,'houseId':6}";
            //ObjInsertEvtInput.amount = ObjEvento.amount;
            //ObjInsertEvtInput.bankReportEntryId = ObjEvento.bankReportEntryId;
            //ObjInsertEvtInput.date = ObjEvento.date;  //.ToString("yyyy-MM-dd");  //2018-10-04T07:11:09.833+0000
            //ObjInsertEvtInput.description = ObjEvento.description;
            //ObjInsertEvtInput.eventTypeId = ObjEvento.eventTypeId;
            //ObjInsertEvtInput.filePath = ObjEvento.filePath;
            //ObjInsertEvtInput.houseId = ObjEvento.houseId;
            //ObjInsertEvtInput.id = 0;
            //ObjInsertEvtInput.invoiceId = ObjEvento.invoiceId;
            //ObjInsertEvtInput.reminderDate = ObjEvento.reminderDate;
            //ObjInsertEvtInput.reminderMessage = ObjEvento.reminderMessage;

            //inserisce i nuovi eventi
            int NumberEvtToCreate =Convert.ToInt32(CboSplitNumber.Value);
            for (int i = 0; i < NumberEvtToCreate; i++)
            {
                    ObjTemplateDetailPageManager.NewTemplateEvt(ObjInsertEvtInput,Convert.ToInt32(ViewState["MemIdTemp"]));
            }

                BindEvts();
           
            }
            catch (Exception ex)
            {
                PrintError(ex);
    }

}

        protected void LnkBtnCreateTemplate_Click(object sender, EventArgs e)
        {
            TemplateDetailPageManager ObjTemplateDetailPageManager = new TemplateDetailPageManager();


            //Evento ObjEvento = new Evento();
            try
            {
                if (TxtTemplatesName.Text != "")
                {
                    Template ObjTemplate = new Template();
                    ObjTemplate.description = TxtTemplatesName.Text;
                    ObjTemplate.eventTypeId = 0;
                    ObjTemplate.disabled = false;
                   // ObjTemplateDetailPageManager.NewTemplate(ObjTemplate);
                  Template ObjNewTemplate=  ObjTemplateDetailPageManager.NewTemplate(ObjTemplate);
                    ViewState["MemIdTemp"]  = ObjNewTemplate.id;
                    BtnChkOk.Attributes.Add("style", "display:inline");
                    PnlSplitting.Visible = true;
                }
               
                //BindEvts();

            }
            catch (Exception ex)
            {
                BtnChkOk.Attributes.Add("style", "display:none");
                PrintError(ex);
            }

        }

        //protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        DropDownList CboEventi = e.Item.FindControl("CboEventi") as DropDownList;
        //        PopolaCboEventi(CboEventi);
        //        DropDownList CboCase = e.Item.FindControl("CboCase") as DropDownList;
        //        PopolaCboCase(CboCase);
        //        DropDownList CboLandlord = e.Item.FindControl("CboLandlord") as DropDownList;
        //        PopolaCboLandlord(CboLandlord);
        //        DropDownList CboParty = e.Item.FindControl("CboParty") as DropDownList;
        //        PopolaCboParty(CboParty);

        //        Ls.Prj.DTO.EventoDTO drv = (Ls.Prj.DTO.EventoDTO)e.Item.DataItem;

        //        CboCase.Attributes.Add("onchange", "UpdateHouse(this)");
        //        CboEventi.Attributes.Add("onchange", "UpdateEvtType(this)");
        //        CboLandlord.Attributes.Add("onchange", "UpdateLandlord(this)");
        //        CboParty.Attributes.Add("onchange", "UpdateParty(this)");
        //        //DataRowView drv = e.Row.DataItem as DataRowView;
        //        Utility.SetDropByValue(CboEventi, CboEventi.Attributes["MemId"]);
        //        Utility.SetDropByValue(CboCase, CboCase.Attributes["MemId"]);
        //        Utility.SetDropByValue(CboLandlord, CboLandlord.Attributes["MemId"]);
        //        Utility.SetDropByValue(CboParty, CboParty.Attributes["MemId"]);

        //        if (CboEventi.Attributes["MemId"] == "0")
        //        {
        //            CboEventi.Attributes.Add("style", "font-weight:bold");
        //        }

        //        if (CboCase.Attributes["MemId"] == "0")
        //        {
        //            CboCase.Attributes.Add("style", "font-weight:bold");
        //        }

        //        if (CboLandlord.Attributes["MemId"] == "0")
        //        {
        //            CboLandlord.Attributes.Add("style", "font-weight:bold");
        //        }
        //        if (CboParty.Attributes["MemId"] == "0")
        //        {
        //            CboParty.Attributes.Add("style", "font-weight:bold");
        //        }
        //    }
        //}

        protected void RptSelEvt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList CboEventi = e.Item.FindControl("CboEventi") as DropDownList;
                PopolaCboEventi(CboEventi);
                DropDownList CboCase = e.Item.FindControl("CboCase") as DropDownList;
                PopolaCboCase(CboCase);
                DropDownList CboLandlord = e.Item.FindControl("CboLandlord") as DropDownList;
                PopolaCboLandlord(CboLandlord);
                DropDownList CboParty = e.Item.FindControl("CboParty") as DropDownList;
                PopolaCboParty(CboParty);

                //Evento drv = (Evento)e.Item.DataItem;

                CboCase.Attributes.Add("onchange", "TmpUpdateHouse(this)");
                CboEventi.Attributes.Add("onchange", "TmpUpdateEvtType(this)");
                CboLandlord.Attributes.Add("onchange", "TmpUpdateLandlord(this)");
                CboParty.Attributes.Add("onchange", "TmpUpdateParty(this)");
                //DataRowView drv = e.Row.DataItem as DataRowView;
                Utility.SetDropByValue(CboEventi, CboEventi.Attributes["MemId"]);
                Utility.SetDropByValue(CboCase, CboCase.Attributes["MemId"]);
                Utility.SetDropByValue(CboLandlord, CboLandlord.Attributes["MemId"]);
                Utility.SetDropByValue(CboParty, CboParty.Attributes["MemId"]);

                if (CboEventi.Attributes["MemId"] == "0")
                {
                    CboEventi.Attributes.Add("style", "font-weight:bold");
                }

                if (CboCase.Attributes["MemId"] == "0")
                {
                    CboCase.Attributes.Add("style", "font-weight:bold");
                }

                if (CboLandlord.Attributes["MemId"] == "0")
                {
                    CboLandlord.Attributes.Add("style", "font-weight:bold");
                }
                if (CboParty.Attributes["MemId"] == "0")
                {
                    CboParty.Attributes.Add("style", "font-weight:bold");
                }
            }
        }

        #region Gestione lightbox

        protected void BtnCancelDeleting_Click(object sender, EventArgs e)
        {
            DivDelete.Attributes.Add("Class", "ParentDivDeleting Disattivato");
        }
        protected void BtnUpdateAllBrothers_Click(object sender, EventArgs e)
        {
            
            TemplateDetailPageManager ObjTemplateDetailPageManager = new TemplateDetailPageManager();
          
            try
            {
                //aggiorna la description del template
                UpdateTemplateDTO ObjUpdateTemplateDTO = new UpdateTemplateDTO();
                ObjUpdateTemplateDTO.id =Convert.ToInt32(ViewState["MemIdTemp"]);
                ObjUpdateTemplateDTO.description = TxtTemplatesName.Text;

                ObjUpdateTemplateDTO.disabled =!(Convert.ToBoolean(CboEnable.SelectedValue));
                ObjTemplateDetailPageManager.UpdateTemplate(ObjUpdateTemplateDTO);
                BtnChkOk.Attributes.Add("style", "display:inline");
                //si scorre il repeater ed aggiorna i dati
                foreach (RepeaterItem item in RptSelEvt.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var TxtAmount = (TextBox)item.FindControl("TxtAmount");
                        var TxtDescription = (TextBox)item.FindControl("TxtDescription");
                        DropDownList CboCase = (DropDownList)item.FindControl("CboCase");
                        int idEvt =Convert.ToInt32(CboCase.Attributes["MemIdEvt"]);
                        //MemIdEvt
                        //fa il put del dato
                        UpdateBrotherEvtDto ObjUpdateBrotherEvtDto = new UpdateBrotherEvtDto();
                        ObjUpdateBrotherEvtDto.id = idEvt;
                        ObjUpdateBrotherEvtDto.amount =Convert.ToDouble(TxtAmount.Text);
                        ObjUpdateBrotherEvtDto.description = TxtDescription.Text;
                        ObjTemplateDetailPageManager.UpdateAllTemplateEvt(ObjUpdateBrotherEvtDto, Convert.ToInt32(ViewState["MemIdTemp"]));
                    


                    }
                }
                //messaggio di conferma salvataggio
                LitMessaggioInformativo.Text = "Events update successfully completed.";
                DivInformation.Attributes.Add("Class", "ParentDivDeleting Attivo");
            }
            catch (Exception ex)
            {
                PrintError(ex);
            }
        }
        

        protected void BtnConfirmDeleting_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 IdToDelete = Convert.ToInt32(HydIdToDelete.Value);
                //TrackManagement2PageManager ObjTrackManagement2PageManager = new TrackManagement2PageManager();
                //ObjTrackManagement2PageManager.DeleteEvt(IdToDelete);
                TemplateDetailPageManager ObjTemplateDetailPageManager = new TemplateDetailPageManager();
                ObjTemplateDetailPageManager.DeleteTemplateEvt(IdToDelete,Convert.ToInt32(MemIdTemp));
                BindEvts();

                DivDelete.Attributes.Add("Class", "ParentDivDeleting Disattivato");
            }
            catch (Exception ex)
            {
                PrintError(ex);
            }

        }

       
        #endregion



        #region routine private alla pagina

        private void BindEvts()
        {
            if (ViewState["MemIdTemp"] != null)
            { 
            TemplateDetailPageManager ObjTemplateDetailPageManager = new TemplateDetailPageManager();
            //recupera il template
            TemplateDTO ObjTemplateDTO; 
            ObjTemplateDTO = ObjTemplateDetailPageManager.GetTemplate(Convert.ToInt32(ViewState["MemIdTemp"].ToString()));
                string CboAbilitato="";
                if (ObjTemplateDTO.enabled.ToString() == "NO")
                {
                    CboAbilitato = "False";
                }
                else
                {
                    CboAbilitato = "True";
                }
                    Utility.SetDropByValue(CboEnable, CboAbilitato);
            TxtTemplatesName.Text = ObjTemplateDTO.description;
            //Recupera gli eventi del template
            List<EventoDTO> LstEvtDto = ObjTemplateDetailPageManager.GetTemplateEvents(ObjTemplateDTO.id);
            //List<Evento> Lst = ObjEvtDto.modelEvents.ToList();
            RptSelEvt.DataSource = LstEvtDto;
            RptSelEvt.DataBind();
            }



        }
        private void BindRepeater()
        {
        }

       
        private void PrintError(Exception ex)
        {
            LitError.Text = "An unhandled error occurred:<br>" + ex.Message;
            DivError.Attributes.Add("Class", "ParentDivDeleting Attivo");
        }

        private void PopolaCboEventi(DropDownList drop)
        {
           
            if (LstEvtType != null)
            { 
                foreach (EventTypeDTO Curr in LstEvtType)
                {
                    var listItem = new ListItem();
                    listItem.Value = Curr.id.ToString();
                    listItem.Text = Curr.displayValue;
                    drop.Items.Add(listItem);
              
                }
            }
            //drop.Items.Add(new ListItem("--Select event type--", "0"));
            Utility.SetDropByValue(drop, "0");
        }

        private void PopolaCboCase(DropDownList drop)
        {
            if (LstHouse != null)
            {
           
                foreach (HouseDTO Curr in LstHouse)
                {
                    var listItem = new ListItem();
                    listItem.Value = Curr.id.ToString();
                    listItem.Text = Curr.nickname;
                    drop.Items.Add(listItem);

                }
            }
            drop.Items.Add(new ListItem("--Select house--", "0"));
            Utility.SetDropByValue(drop, "0");
        }

        private void PopolaCboLandlord(DropDownList drop)
        {
            if (LstLandlord != null)
            {

                foreach (LandlordDTO Curr in LstLandlord)
                {
                    var listItem = new ListItem();
                    listItem.Value = Curr.id.ToString();
                    listItem.Text = Curr.name;
                    drop.Items.Add(listItem);

                }
            }
            drop.Items.Add(new ListItem("--Select landlord--", "0"));
            Utility.SetDropByValue(drop, "0");
        }
        private void PopolaCboParty(DropDownList drop)
        {
            if (LstParty != null)
            {

                foreach (PartyDTO Curr in LstParty)
                {
                    var listItem = new ListItem();
                    listItem.Value = Curr.id.ToString();
                    listItem.Text = Curr.name;
                    drop.Items.Add(listItem);

                }
            }
            drop.Items.Add(new ListItem("--Select party--", "0"));
            Utility.SetDropByValue(drop, "0");
        }

        private void PopolaCboTemplate(DropDownList drop)
        {
            TrackManagement2PageManager ObjTrackManagement2PageManager = new TrackManagement2PageManager();
            List<Template> LstTemplate;
            LstTemplate = ObjTrackManagement2PageManager.GetTemplate();
            if (LstTemplate != null)
            {

                foreach (Template Curr in LstTemplate)
                {
                    var listItem = new ListItem();
                    listItem.Value = Curr.id.ToString();
                    listItem.Text = Curr.description;
                    drop.Items.Add(listItem);

                }
            }
            drop.Items.Add(new ListItem("--Select template--", "0"));
            Utility.SetDropByValue(drop, "0");
        }

        #endregion



    }
}