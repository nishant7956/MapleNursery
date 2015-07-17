using JustTest1.DataModel;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Parse;
using maplenursery.DataModel;
using Newtonsoft.Json;
using GoogleMaps.LocationServices;
using JustTest1.Controller;
namespace maplenursery.admin
{
    public partial class addjob : System.Web.UI.Page
    {


       public  static List<content> allcontent = new List<content>();
        List<EmpJobRelation> empjobrel=new List<EmpJobRelation>();
       public static List<string> selected = new List<string>();
        
        public string clientid;
   public  string jobids;
      
        protected async void Page_Load(object sender, EventArgs e)
        {
            
            
            //selectplant.Visible = false;
            //Session["pid"] = "_addjob";
            if (Session["clientid"] == null)
            {

                Response.Redirect("selectclient.aspx", false);
            }
            else
            {
                 clientid = (string)(Session["clientid"]);
                
            
                
            }
        
            if(!IsPostBack)
            {
                //else
                //{
                //    Lblerror.Text = "please select an item";
                //}
                //addjobs.Visible = false;
                //clientcontrols.Visible = false;
                //search.Visible = false;
              
                //listofplants.Visible = false;
                await RefreshTodoItems();
                //this.Button2.Attributes.Add("onclick", "javascript:return OpenPopup()");
            }
            

        }
        protected void btnHidden_Click(object sender, EventArgs e)
        {
            // Bind GridTwo only(after the modification of table in pop-up window
            // This button click event is performed by Javascript function in pop-up window
            RefreshContentList(); 
        }

        private void RefreshContentList()
        {
            selectedplant.DataSource = allcontent;
            selectedplant.DataBind(); 
            foreach (ListViewItem selecteditem in selectedplant.Items)
            {
                Label selectedid = (Label)selecteditem.FindControl("Label5");

                selected.Add(selectedid.Text);
                 

            }
            //bool result = selectplant.ids.Intersect(selected).Count() == selectplant.ids.Count;
            //if (!result) 
            //{
            //    selectedplant.DataSource = allcontent;
            //    selectedplant.DataBind(); 
            //}
            //else
            //{
            //    Lblerror.Text = "already selected";
            //}
            
        }
        

     
        private async Task  RefreshTodoItems()
        {

            DateTime today = DateTime.Today;
            Calendar1.TodaysDate = today;
            Calendar1.SelectedDate = Calendar1.TodaysDate;
            List<User> all=new List<User>();
            var idleuser = await ParseObject.GetQuery("CurrentUserStatus")
                                .WhereEqualTo("status", UserControlls.statusCode[0])
                                .FindAsync();
            
            List<User> current = new List<User>();
            foreach (ParseObject obj in idleuser)
            {
                current.Add(new User()
                {
                    Id = obj.Get<string>("userId"),
                    status = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new User().status)),

                });
            }
            var temp = current.Select(a => a.Id).ToList();
          //  var sat = current.Select(s => s.status).ToList();
            IEnumerable<ParseUser> idleusers = await ParseUser.Query
                              .WhereContainedIn("objectId", temp)
                              .WhereNotEqualTo(MemberInfoGetting.GetMemberName(() => new User().username), "admin")
                              .FindAsync();

            foreach (ParseObject obj in idleusers)
            {
                all.Add(new User()
                {
                    Id = obj.ObjectId,
                    username = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new User().username))
                } );
            }
               
                LiEmployee.DataSource = all;
                LiEmployee.DataTextField = MemberInfoGetting.GetMemberName(() => new User().username);
                LiEmployee.DataValueField = MemberInfoGetting.GetMemberName(() => new User().Id);
                LiEmployee.DataBind();

                LiEmployee.EnableViewState = true;
            
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            if(allcontent.Count()==0)
            {
                Lblerror.Text = "please add content";
            }
            ParseObject job = new ParseObject(typeof(Job).Name);
            ParseObject empjob = new ParseObject(typeof(EmpJobRelation).Name);
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(txtlocation.Text);
            DateTime selected=Calendar1.SelectedDate;

            DateTime dt = new DateTime(selected.Year, selected.Month, selected.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            //var latitude = point.Latitude;
            //var longitude = point.Longitude;
            //Response.Write(latitude + "" + longitude);
            var addpoint = new ParseGeoPoint(point.Latitude, point.Longitude);
            try
            {
                var selectedValue = LiEmployee.SelectedItem;
                //User userObject = items[selectedValue];
                //Response.Write((selectedValue.Value));

                job[MemberInfoGetting.GetMemberName(() => new Job().ClientId)] = clientid;
                job[MemberInfoGetting.GetMemberName(() => new Job().name)] = JobTitle.Text;
                job[MemberInfoGetting.GetMemberName(() => new Job().description)] = JobDescription.Text;
                job[MemberInfoGetting.GetMemberName(() => new Job().EmployeeId)] = selectedValue.Value;
                job[MemberInfoGetting.GetMemberName(() => new Job().content)] = JsonConvert.SerializeObject(allcontent);
                job[MemberInfoGetting.GetMemberName(() => new Job().Status)] = JobControlls.JobStatusCode[0];
                job[MemberInfoGetting.GetMemberName(() => new Job().jobDate)] = dt;
                job[MemberInfoGetting.GetMemberName(() => new Job().location)]=txtlocation.Text;
                job[MemberInfoGetting.GetMemberName(() => new Job().locCoordinate)]=addpoint;
                empjob[MemberInfoGetting.GetMemberName(() => new EmpJobRelation().EmployeeId)] = selectedValue.Value;
                await job.SaveAsync();
                IEnumerable<ParseObject> jobid = await ParseObject.GetQuery(typeof(Job).Name)
                    .WhereEqualTo(MemberInfoGetting.GetMemberName(() => new Job().jobDate), dt).FindAsync();
                
                await empjob.SaveAsync();
               
                foreach(ParseObject obj in jobid)
                {
                    empjob[MemberInfoGetting.GetMemberName(() => new EmpJobRelation().JobId)] = obj.ObjectId;
                    
                }
                
                 var ids = jobid.Select(s => s.ObjectId).ToList();
                await empjob.SaveAsync();
                IEnumerable<ParseObject> query = await ParseObject.GetQuery(typeof(EmpJobRelation).Name)
                   .WhereContainedIn(MemberInfoGetting.GetMemberName(() => new EmpJobRelation().JobId), ids).FindAsync();
                foreach (ParseObject obj in query)
                {
                    empjobrel.Add(new EmpJobRelation()
                    {
                        Id = obj.ObjectId
                    }
                        );

                }
                //ParseObject p;
                //var relaiton = p.GetRelation<ParseObject>("UserRelation");
                foreach(var a in empjobrel)
                {

                    job[MemberInfoGetting.GetMemberName(() => new Job().UserRelation)] = a.Id;
                }
                
                await job.SaveAsync();
                Lblerror.Text = "Saved Successfully";
                

            }
            catch(Exception en)
            {
                Lblerror.Text = en.Message;
            }
            //var newJob = new Job { JobName = JobTitle.Text, JobDesc = JobDescription.Text, AssignedUser = selectedValue.Value };
            ////Debug.WriteLine("" + selectedValue.Id);
            // await InsertnewJob(newJob);
        }
        //public async void bindlist()
        //{

        //    List<content> all = new List<content>();
        //    IEnumerable<ParseObject> users = await ParseObject.GetQuery(typeof(Plant).Name).FindAsync();

        //    foreach (ParseObject obj in users)
        //    {
        //        ParseFile img = obj.Get<ParseFile>(MemberInfoGetting.GetMemberName(() => new Plant().image));
        //        //Console.Write("" + img.Url); 
        //        all.Add(new content()
        //        {
        //            Id = obj.ObjectId,

        //            name = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Plant().name)),
        //            description = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Plant().description)),
        //            image = img.Url,
        //            price = obj.Get<double>(MemberInfoGetting.GetMemberName(() => new Plant().price)),
        //            Quantity = 1
        //        });
        //    }
        //    ListView1.DataSource = all;
        //    ListView1.DataBind();
        //    //DataList1.DataSource = all;
        //    //DataList1.DataBind();
        //}
        
         protected  void addplant_Click(object sender, EventArgs e)
        {
            
            try
            {
                //Response.Write("<script language=javascript>child=window.open('selectplant.aspx','TheNewpop','width=400,height=400,left=300,top=150')</script>");
                   string popupScript = "<script language=javascript>"
                +"var Popup; "+ 

                      "  Popup = window.open('selectplant.aspx', 'bpPopup', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,width=420,height=300,left = 490,top = 262');" +

                      "  Popup.focus();"+

                       " </script>";
                   Page.ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

                 
                  //string popupScript = "<script language=javascript>" +
                  //      "var childWindow =  window.open('selectplant.aspx', 'Select Contents', " +
                  //      "'left = 300, top=150, width=400, height=300, " +
                  //      "menubar=no, scrollbars=no, resizable=yes'); childWindow.focus();" +
                  //      "</script>";
                //Page.ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);


                //listofplants.Visible = true;
                //Response.Redirect("selectplant.aspx",false);
               
                //ListView1.Visible = false;
                //ParseQuery<ParseObject> query = ParseObject.GetQuery("Plant");

                //var queryTask = query.FirstAsync();
                //ParseObject obj = queryTask.Result;
                //ParseFile applicantResumeFile = obj.Get<ParseFile>("image");

                //string assd = applicantResumeFile.Url + "";
                //bindlist();
                //selectplant.Visible = true;

            }
            catch (Exception err)
            {
                Lblerror.Text = err.Message;
            }
           
        }

     

        //protected async void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        //{
           
        //}

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{

        //    LinkButton btn = (LinkButton)sender;
        //    DataListItem item = (DataListItem)btn.NamingContainer;
        //    Label lblId = (Label)item.FindControl("LblID");
            
        //    string ID = lblId.Text;

        //    List<content> ids = new List<content>();
            
            
        //    ids.Add(new content(){ Id=ID}
        //        );
        //    selectedplant.DataSource = ids;
        //    selectedplant.DataBind();
        //}

        //protected void selectplant_Click(object sender, EventArgs e)
        //{
        //    //Button btn=(Button)sender; 
        //    select_plant();
        //    ListView1.Visible = false;
        //    //addjobs.Visible = true;
        //}
        //public void select_plant()
        //{
        //    foreach (ListViewItem selecteditem in selectedplant.Items)
        //    {
        //        Label selectedid = (Label)selecteditem.FindControl("Label5");
               
        //        selected.Add(selectedid.Text);
        //    }
            
        //    //foreach (DataListItem items in DataList1.Items)
        //    //{
               
        //    //    TextBox quantity = (TextBox)items.FindControl("lblquantity");
        //    //    Label price = (Label)items.FindControl("lblprice1");
        //    //    CheckBox cb = (CheckBox)items.FindControl("CheckBox1");
        //    //    Label lblId = (Label)items.FindControl("LblID"); 
        //    //    Image i = (Image)items.FindControl("Image1");
        //    //    Label desc = (Label)items.FindControl("description");
        //    //    List<string> ids=new List<string>();
        //    //    ids.Add(lblId.Text);
        //    //    int q = Convert.ToInt16(quantity.Text);
        //    //    double p = Convert.ToDouble(price.Text);

        //    //    double totol = q * p;
        //    //    if ((items.FindControl("CheckBox1") as CheckBox).Checked)
        //    //    {
        //    //        bool result = ids.Intersect(selected).Count() == ids.Count;
                    
        //    //        if (!result)
        //    //        {
        //    //            allcontent.Add(new content()
        //    //            {
        //    //                Id = lblId.Text,
        //    //                name = cb.Text,
        //    //                image = new Uri(i.ImageUrl),
        //    //                price = Convert.ToDouble(price.Text),
        //    //                description=desc.Text,
        //    //                Quantity = Convert.ToInt16(quantity.Text),
        //    //                Total=totol
        //    //            });
        //    //        }
        //    //        else
        //    //        {
        //    //            Lblerror.Text = "already selected";
        //    //        }
        //    //    }
                 
        //    //}
        //    foreach(ListViewItem items in ListView1.Items)
        //    {
        //        Label qn = (Label)items.FindControl("Label4");
               
        //            TextBox quantity = (TextBox)items.FindControl("TextBox1");
                    
                
        //        Label price = (Label)items.FindControl("lblprice1");
        //        CheckBox cb = (CheckBox)items.FindControl("CheckBox1");
        //        Label lblId = (Label)items.FindControl("LblID");
        //        Image i = (Image)items.FindControl("Image1");
        //        Label desc = (Label)items.FindControl("description");
        //        List<string> ids = new List<string>();
        //        ids.Add(lblId.Text);
        //       // int q = Convert.ToInt16(quantity.Text);
        //        double p = Convert.ToDouble(price.Text);

        //       // double totol = q * p;
        //        if ((items.FindControl("CheckBox1") as CheckBox).Checked)
        //        {
        //            bool result = ids.Intersect(selected).Count() == ids.Count;

        //            if (!result)
        //            {
        //                allcontent.Add(new content()
        //                {
        //                    Id = lblId.Text,
        //                    name = cb.Text,
        //                    image = new Uri(i.ImageUrl),
        //                    price = Convert.ToDouble(price.Text),
        //                    description = desc.Text,
        //                   // Quantity = Convert.ToInt16(quantity.Text),
        //                    //Total = totol
        //                });
        //            }
        //            else
        //            {
        //                Lblerror.Text = "already selected";
        //            }
        //        }

        //    }
        //    selectedplant.DataSource = allcontent;
        //    selectedplant.DataBind();
            
        //    //selectplant.Visible = false;
        //}

        

        //protected void ListView1_PagePropertiesChanged(object sender, EventArgs e)
        //{
        //    bindlist();
        //}

        //protected async void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        //{

        //    if (e.CommandArgument == "search")
        //    {
        //        TextBox searchitem = (TextBox)ListView1.FindControl("txtsearch");
        //        //Button search = (Button)e.Item.FindControl("btnsearch");
        //        IEnumerable<ParseObject> query = await ParseObject.GetQuery(typeof(Plant).Name).WhereContains
        //            (MemberInfoGetting.GetMemberName(() => new Plant().name), searchitem.Text).FindAsync();
        //        List<content> all = new List<content>();
        //        //IEnumerable<ParseObject> users = await ParseObject.GetQuery(typeof(Plant).Name).FindAsync();

        //        foreach (ParseObject obj in query)
        //        {
        //            ParseFile img = obj.Get<ParseFile>(MemberInfoGetting.GetMemberName(() => new Plant().image));
        //            //Console.Write("" + img.Url); 
        //            all.Add(new content()
        //            {
        //                Id = obj.ObjectId,

        //                name = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Plant().name)),
        //                description = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Plant().description)),
        //                image = img.Url,
        //                price = obj.Get<double>(MemberInfoGetting.GetMemberName(() => new Plant().price)),
        //                Quantity = 1
        //            });
        //        }

        //        ListView1.DataSource = all;
        //        ListView1.DataBind();
        //    }
        //}

        protected void selectedplant_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandArgument == "Delete")
            {
                //ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                //ListView1.Items.Remove(dataItem);
                allcontent.RemoveAt(e.Item.DataItemIndex);
                allcontent.Count();
                selected.RemoveAt(e.Item.DataItemIndex);
                selected.Count();
                RefreshContentList(); 
            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }
        //protected void RadioButton_CheckedChanged(object sender, System.EventArgs e)
        //{
        //    if(radioexist.Checked)
        //    {
        //        search.Visible = true;
        //        clientcontrols.Visible = false;
                
                
        //    }
        //    else
        //    {
        //        clientcontrols.Visible = true;
        //        search.Visible = false;
        //    }
        //}

        //protected void next_Click(object sender, EventArgs e)
        //{
        //    addjobs.Visible = true;
        //}

        //protected async void searchclient_Click(object sender, EventArgs e)
        //{
        //    try 
        //    { 
        //       IEnumerable<ParseObject> query= await ParseObject.GetQuery(typeof(Client).Name)
        //            .WhereEqualTo(MemberInfoGetting.GetMemberName(()=>new Client().name),txtsearchclient.Text).FindAsync();
        //       if (query.Count() != 0)
        //       {
        //           List<Client> all = new List<Client>();
        //          foreach(ParseObject obj in query)
        //          {
        //              clientcontrols.Visible = true;
        //              clientname.Text=obj.Get<string>(MemberInfoGetting.GetMemberName(()=>new Client().name));
        //              clientaddress.Text = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Client().address));
        //              clientcontact.Text = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Client().contactnumber));
        //              clientemail.Text = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Client().email));
        //          }
        //       }
        //       else
        //       {
        //           Lblerror.Text = "Client Does Not Exist";
        //       }
              
        //    }
        //    catch(Exception en)
        //    {
        //        Lblerror.Text = en.Message;
        //    }
        //}

       

       

        

        

        //protected void DLselectedplant_EditCommand(object source, DataListCommandEventArgs e)
        //{
        //    //if(e.CommandName=="Edit")
        //    DLselectedplant.EditItemIndex = e.Item.ItemIndex;
        //    select_plant();
        //    //DLselectedplant.DataBind();
        //}

        //protected void DLselectedplant_CancelCommand(object source, DataListCommandEventArgs e)
        //{
        //    DLselectedplant.EditItemIndex = -1;
        //    select_plant();
        //}

//        protected void DLselectedplant_UpdateCommand(object source, DataListCommandEventArgs e)
//        {
//            TextBox quantity = (TextBox)e.Item.FindControl("txtquantity");
//            Label price = (Label)e.Item.FindControl("lblprice2");
//            Label id = (Label)e.Item.FindControl("lblID");
//            int q = Convert.ToInt16(quantity.Text);
//            double p = Convert.ToDouble(price.Text);
            
//            double totol = q * p;
            
//            allcontent.Add(new content
//                {
//                    Id=id.Text,
//                    Quantity = q,
//                    Price = p,
//                    Total = totol
//                });
//            DLselectedplant.EditItemIndex = -1;
           
//                select_plant();
           
           
////            List<Plant> rows = new List<Plant>();
////            //Label quantity = (Label)items.FindControl("lblquantity");

////            Label name = (Label)e.Item.FindControl("lblname");
////            Label lblId = (Label)e.Item.FindControl("lblID");
////            Image i = (Image)e.Item.FindControl("Image3");
////            Uri convertedUri = new Uri(i.ImageUrl);
            
//////            var query =
//////    from ord in ParseObject.GetQuery("Job")
//////    where ord.ObjectId ==lblId.Text
//////    select ord;

//////// Execute the query, and change the column values 
//////// you want to change. 
//////foreach (ParseObject ord in query)
//////{
//////    ord.Get<double>("total") = "Mariner";
    
//////    // Insert any additional changes to column values.
//////}

////            foreach (DataListItem items in DLselectedplant.Items)
////            {
////                rows.Add(new Plant()
////                {
////                    Id = lblId.Text,
////                    Name = name.Text,
////                    imagePath = convertedUri,
////                    Price = c.Price,
////                    Total = c.Total,
////                    Quantity = c.Quantity
////                });

////            }
////            DLselectedplant.DataSource = rows;
////            DLselectedplant.DataBind();
//            //IEnumerable<ParseObject> users = await ParseObject.GetQuery("Plant").FindAsync();
//            //try
//            //{
//            //    ParseObject job = new ParseObject("Job");
//            //    job["quantity"] = Convert.ToInt32( quantity.Text);
//            //    await job.SaveAsync();
//            //    DLselectedplant.EditItemIndex = -1;
//            //    select_plant();
//            //}
//            //catch (Exception en)
//            //{
//            //    Lblerror.Text = en.Message;
//            //}




//            //private async void SaveaJob(object sender, EventArgs e)
//            //{


//            //}


//            //private async Task InsertnewJob(Job newJob)
//            //{
//            //    await jobTable.InsertAsync(newJob);
//            //    Lblerror.Text = "saved";
//            //    //items.Add(newJob); 
//            //}
//        }
       
         
    }
}