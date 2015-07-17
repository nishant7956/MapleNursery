using JustTest1.Controller;
using maplenursery.DataModel;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maplenursery.admin
{
    public partial class selectplant : System.Web.UI.Page
    {
    //   public static List<content> allcontent = new List<content>();
       
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
        {
            bindlist();
        }
        }
        public async void bindlist()
        {

            List<content> all = new List<content>();
            IEnumerable<ParseObject> users = await ParseObject.GetQuery(typeof(Plant).Name).FindAsync();

            foreach (ParseObject obj in users)
            {
                ParseFile img = obj.Get<ParseFile>(MemberInfoGetting.GetMemberName(() => new Plant().image));
                //Console.Write("" + img.Url); 
                all.Add(new content()
                {
                    Id = obj.ObjectId,

                    name = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Plant().name)),
                    description = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Plant().description)),
                    image = img.Url,
                    price = obj.Get<double>(MemberInfoGetting.GetMemberName(() => new Plant().price)),
                    Quantity = 1
                });
            }
            ListView1.DataSource = all;
            ListView1.DataBind();
            //DataList1.DataSource = all;
            //DataList1.DataBind();
        }
        protected void selectplant_Click(object sender, EventArgs e)
        {
            //Button btn=(Button)sender; 
            select_plant();
            if (Lblerror.Text != "1")
            {
                Response.Write("<script>window.close()</script>");
            }
            else
            {
                Lblerror.Text = "already selected";
            }
            //Response.Write("<script type='text/javascript'>"+
            //    "window.opener.document.getElementById('btnHidden').click();}</script>");


            //Response.Write("<script type=\"text/javascript\">window.onunload = function (e) {opener.document.getElementById('ContentPlaceHolder1_btnHidden').click();};</script> ");
            //addjob.ReloadItems();
            //addjobs.Visible = true;
        }
        public static List<string> ids = new List<string>();
        public void select_plant()
        {
            //foreach (ListViewItem selecteditem in selectedplant.Items)
            //{
            //    Label selectedid = (Label)selecteditem.FindControl("Label5");

            //    selected.Add(selectedid.Text);
            //}

            //foreach (DataListItem items in DataList1.Items)
            //{

            //    TextBox quantity = (TextBox)items.FindControl("lblquantity");
            //    Label price = (Label)items.FindControl("lblprice1");
            //    CheckBox cb = (CheckBox)items.FindControl("CheckBox1");
            //    Label lblId = (Label)items.FindControl("LblID"); 
            //    Image i = (Image)items.FindControl("Image1");
            //    Label desc = (Label)items.FindControl("description");
            //    List<string> ids=new List<string>();
            //    ids.Add(lblId.Text);
            //    int q = Convert.ToInt16(quantity.Text);
            //    double p = Convert.ToDouble(price.Text);

            //    double totol = q * p;
            //    if ((items.FindControl("CheckBox1") as CheckBox).Checked)
            //    {
            //        bool result = ids.Intersect(selected).Count() == ids.Count;

            //        if (!result)
            //        {
            //            allcontent.Add(new content()
            //            {
            //                Id = lblId.Text,
            //                name = cb.Text,
            //                image = new Uri(i.ImageUrl),
            //                price = Convert.ToDouble(price.Text),
            //                description=desc.Text,
            //                Quantity = Convert.ToInt16(quantity.Text),
            //                Total=totol
            //            });
            //        }
            //        else
            //        {
            //            Lblerror.Text = "already selected";
            //        }
            //    }

            //}
            
            foreach (ListViewItem items in ListView1.Items)
            {
                

                TextBox quantity = (TextBox)items.FindControl("TextBox1");


                Label price = (Label)items.FindControl("lblprice1");
                CheckBox cb = (CheckBox)items.FindControl("CheckBox1");
                Label lblId = (Label)items.FindControl("LblID");
                Image i = (Image)items.FindControl("Image1");
                Label desc = (Label)items.FindControl("description");

               
                int q = Convert.ToInt16(quantity.Text);
                double p = Convert.ToDouble(price.Text);
                //string count;
                 double totol = q * p;
                if ((items.FindControl("CheckBox1") as CheckBox).Checked)
                {
                    ids.Add(lblId.Text);
                    List<string> distinct = ids.Distinct().ToList();
                   // var DeletedItems = distinct.Except(addjob.selected);
                   //count =DeletedItems.Count().ToString();
                    List<string> dis = addjob.selected.Distinct().ToList();
                    bool result = distinct.Intersect(dis).Count() == distinct.Count;
                  
                    if (!result)
                    {
                        //Session["id"] = lblId.Text;
                        //Session["name"] = cb.Text;
                        //Session["image"] = new Uri(i.ImageUrl);
                        //Session["price"] = Convert.ToDouble(price.Text);
                        //Session["desc"] = desc.Text;
                        //Session["quantity"] = Convert.ToInt16(quantity.Text);
                        addjob.allcontent.Add(new content()
                        {

                            Id = lblId.Text,
                            name = cb.Text,
                            image = new Uri(i.ImageUrl),
                            price = Convert.ToDouble(price.Text),
                            description = desc.Text,
                            Quantity = q,
                            Total = totol
                        });
                    }
                    else
                    {
                        Lblerror.Text = "1";
                    }
                }

            }
        
            //selectedplant.DataSource = allcontent;
            //selectedplant.DataBind();

            //selectplant.Visible = false;
        }



        protected void ListView1_PagePropertiesChanged(object sender, EventArgs e)
        {
            bindlist();
        }

        protected async void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (e.CommandArgument == "search")
            {
                TextBox searchitem = (TextBox)ListView1.FindControl("txtsearch");
                //Button search = (Button)e.Item.FindControl("btnsearch");
                IEnumerable<ParseObject> query = await ParseObject.GetQuery(typeof(Plant).Name).WhereContains
                    (MemberInfoGetting.GetMemberName(() => new Plant().name), searchitem.Text).FindAsync();
                List<content> all = new List<content>();
                //IEnumerable<ParseObject> users = await ParseObject.GetQuery(typeof(Plant).Name).FindAsync();

                foreach (ParseObject obj in query)
                {
                    ParseFile img = obj.Get<ParseFile>(MemberInfoGetting.GetMemberName(() => new Plant().image));
                    //Console.Write("" + img.Url); 
                    all.Add(new content()
                    {
                        Id = obj.ObjectId,

                        name = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Plant().name)),
                        description = obj.Get<string>(MemberInfoGetting.GetMemberName(() => new Plant().description)),
                        image = img.Url,
                        price = obj.Get<double>(MemberInfoGetting.GetMemberName(() => new Plant().price)),
                        Quantity = 1
                    });
                }

                ListView1.DataSource = all;
                ListView1.DataBind();
            }
        }
    }
}