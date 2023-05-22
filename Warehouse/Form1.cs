using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Warehouse;
using System.Runtime.Remoting.Contexts;

namespace Warehouse
{

    public partial class Form1 : Form
    {
        Context context = new Context();
        List<ItemsPer> inserted_Items;
        List<string> nms = new List<string>();
        List<string> nms2 = new List<string>();
        Boolean flag;
        Boolean flag2;
        public Form1()
        {
            InitializeComponent();

           
            flag = true;
            flag2 = true;
            var whs = from d in context.Warehouses
                      select d.WH_Name;
            foreach (var i in whs)
            {
                comboBox1.Items.Add(i);
            }
            var suppemails = from s in context.Suppliers
                             select s.Supplier_Email;
            foreach (var ss in suppemails)
            {
                comboBox3.Items.Add(ss);
            }

            var item = from s in context.Items
                       select s.I_Code;
            foreach (var ii in item)
            {
                comboBox2.Items.Add(ii);
            }
            var cusmails = from cus in context.Customers
                           select cus.Customer_Email;
            foreach (var cc in cusmails)
            {
                comboBox4.Items.Add(cc);
            }

            var itemName = from s in context.Items
                           select s.I_Name;
            foreach (var ii in itemName)
            {
                comboBoxI_nm.Items.Add(ii);
            }
            inserted_Items = new List<ItemsPer>();
        }

        //ADD Warehourse
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != null & textBox2.Text != null & textBox3.Text != null)
            {

                var whname = context.Warehouses.Find(textBox1.Text);
                if (whname == null)
                {
                    WareHouse wh = new WareHouse();
                    wh.WH_Name = textBox1.Text;
                    wh.WH_Address = textBox2.Text;
                    wh.WH_Manager = textBox3.Text;
                    context.Warehouses.Add(wh);
                    context.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = "";
                    MessageBox.Show("the warehouse inserted");
                }
                else
                {
                    MessageBox.Show("the warehouse name is exist");
                }
            }
        }
        //select warehouse that we need to change it
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();

            var wareInfo = (from d in context.Warehouses
                            where d.WH_Name == selectedItem
                            select d).First();
            textBox5.Text = wareInfo.WH_Address;
            textBox4.Text = wareInfo.WH_Manager;
        }
        //Update Warehouse

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "")
            {
                // WareHouse warehouse = new WareHouse();
                WareHouse w = context.Warehouses.Find(comboBox1.SelectedItem);
                w.WH_Manager = textBox4.Text;
                w.WH_Address = textBox5.Text;
                context.SaveChanges();
                MessageBox.Show("Edit succeeded");
            }
            else
            {
                MessageBox.Show("Please Complete all info about WareHouse");
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {


        }
        //ADD Items
        private void AddItem_btn_Click(object sender, EventArgs e)
        {
            if (textBox_I_Code.Text != "" & textBoxI_Name.Text != "")
            {
                Item I = new Item();
                var ICode = context.Items.Find(int.Parse(textBox_I_Code.Text));

                if (ICode == null)
                {
                    I.I_Code = int.Parse(textBox_I_Code.Text);
                    I.I_Name = textBoxI_Name.Text;
                    foreach (var m in checkedListBox2.CheckedItems)
                    {
                        Item_Measure p = new Item_Measure();
                        p.I_Code = int.Parse(textBox_I_Code.Text);
                        MessageBox.Show(m.ToString());
                        p.Measure = m.ToString();
                        context.Item_Measures.Add(p);
                    }

                    context.Items.Add(I);
                    context.SaveChanges();
                    MessageBox.Show("item inserted");
                    textBox_I_Code.Text = textBoxI_Name.Text = "";
                    comboBox2.Items.Clear();
                    var item = from i in context.Items
                               select i.I_Code;
                    foreach (var ii in item)
                    {
                        comboBox2.Items.Add(ii);
                    }
                }
                else
                {
                    MessageBox.Show("the Item id is exist");
                }
            }
        }
        //select item to be updated
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox2.SelectedItem.ToString();
            int selectedItem2 = int.Parse(selectedItem);
            var iteminfo = (from d in context.Items
                            where d.I_Code == selectedItem2
                            select d).First();
            textBox10.Text = iteminfo.I_Name;

            CheckBox[] ch = new CheckBox[5];

            ch[0] = checkBox1;
            ch[1] = checkBox2;
            ch[2] = checkBox3;
            ch[3] = checkBox4;
            ch[4] = checkBox5;
        }
        //Update Item
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "" && textBox10.Text != "")
            {
                Item I = context.Items.Find(comboBox2.SelectedItem);
                I.I_Name = textBox10.Text;
                context.SaveChanges();
                MessageBox.Show("Edit succeeded");
            }
            else
            {
                MessageBox.Show("Please Complete all info about Item");
            }
        }
        //ADD Supplier
        private void AddSupp_Click(object sender, EventArgs e)
        {
            string supEmail = textSuppEmail.Text;
            string supName = textBoxSuppName.Text;
            string supPhone = textSuppPhone.Text;
            string supMobile = textSuppMobile.Text;
            string supFax = textSuppFax.Text;
            string supSite = textSuppSite.Text;
            if (supEmail != "" && supName != "" && supMobile != "" && supFax != "" && supSite != "")
            {
                var subFound = context.Suppliers.Find(supEmail);
                if (subFound == null)// PK not founded
                {
                    Supplier s = new Supplier();
                    s.Supplier_Email = supEmail;
                    s.Supplier_Name = supName;
                    s.Supplier_Fax = supPhone;
                    s.Supplier_Website = supSite;
                    s.Supplier_Mobile = int.Parse(supMobile);
                    s.Supplier_phone = int.Parse(supPhone);
                    context.Suppliers.Add(s);
                    context.SaveChanges();
                    MessageBox.Show("Supplier added succesfully");
                    textSuppEmail.Text = textBoxSuppName.Text = textSuppPhone.Text = textSuppMobile.Text = textSuppFax.Text = textSuppSite.Text = "";

                    comboBox3.Items.Clear();
                    var supmails = from sup in context.Suppliers
                                   select sup.Supplier_Email;
                    foreach (var ss in supmails)
                    {
                        comboBox3.Items.Add(ss);
                    }
                }
                else
                {
                    MessageBox.Show("The PK is duplicated");
                }
            }
            else
            {
                MessageBox.Show("some info is missed ,please complete them");
            }


        }
        //select supplier to be updated
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                var selected = context.Suppliers.Find(comboBox3.SelectedItem);
                text_suppName.Text = selected.Supplier_Name;
                text_suppMob.Text = selected.Supplier_Mobile.ToString();
                text_suppSite.Text = selected.Supplier_Website;
                textBox_suppPhone.Text = selected.Supplier_phone.ToString();
                text_suppFax.Text = selected.Supplier_Fax;
            }
        }
        //update selected supplier
        private void UpdateSupp_Click(object sender, EventArgs e)
        {
            if (text_suppName.Text != "" && textBox_suppPhone.Text != "" && text_suppMob.Text != "" && text_suppSite.Text != "" && text_suppFax.Text != "")
            {
                var supplier = context.Suppliers.Find(comboBox3.SelectedItem);  // using email PK
                supplier.Supplier_Name = text_suppName.Text;
                supplier.Supplier_phone = int.Parse(textBox_suppPhone.Text);
                supplier.Supplier_Mobile = int.Parse(text_suppMob.Text);
                supplier.Supplier_Website = text_suppSite.Text;
                supplier.Supplier_Fax = text_suppFax.Text;
                context.SaveChanges();
                MessageBox.Show("Edit succeeded");
                text_suppName.Text = textBox_suppPhone.Text = text_suppMob.Text = text_suppSite.Text = text_suppFax.Text = "";
            }
            else
            {
                MessageBox.Show("Please Complete all info about Supplier");
            }
        }

        //ADD Customer
        private void AddCus_Click(object sender, EventArgs e)
        {
            string cusEmail = textcusEmail.Text;
            string cusName = textcusName.Text;
            string cusPhone = textcusPhone.Text;
            string cusMobile = textcusMob.Text;
            string cusFax = textcusFax.Text;
            string cusSite = textcusSite.Text;
            if (cusEmail != "" & cusFax != "" & cusMobile != "" & cusName != "" & cusPhone != "" & cusSite != "")
            {
                var customerEmail = context.Customers.Find(cusEmail);
                if (customerEmail == null)
                {
                    Customer customer = new Customer();
                    customer.Customer_Email = cusEmail;
                    customer.Customer_Name = cusName;
                    customer.Customer_Phone = int.Parse(cusPhone);
                    customer.Customer_Mobile = int.Parse(cusMobile);
                    customer.Customer_Fax = cusFax;
                    customer.Customer_Website = cusSite;
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    MessageBox.Show("inserted successfully");

                }
            }
        }
        //select customer to be updated
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem != null)
            {
                var selected = context.Customers.Find(comboBox4.SelectedItem);
                text_cusName.Text = selected.Customer_Name;
                text_cusMob.Text = selected.Customer_Mobile.ToString();
                text_cusSite.Text = selected.Customer_Website;
                text_cusPhone.Text = selected.Customer_Phone.ToString();
                text_cusFax.Text = selected.Customer_Fax;
            }
        }
        //update customer selected
        private void UpdateCus_Click(object sender, EventArgs e)
        {
            if (text_cusName.Text != "" && text_cusMob.Text != "" && text_cusSite.Text != "" && text_cusFax.Text != "")
            {
                var cust = context.Customers.Find(comboBox4.SelectedItem);  // using email PK
                cust.Customer_Name = text_cusName.Text;
                cust.Customer_Phone = int.Parse(text_cusPhone.Text);
                cust.Customer_Mobile = int.Parse(text_cusMob.Text);
                cust.Customer_Website= text_cusSite.Text;
                cust.Customer_Fax = text_cusFax.Text;
                context.SaveChanges();
                MessageBox.Show("Edit succeeded");
                text_cusName.Text = text_cusPhone.Text = text_cusMob.Text = text_cusSite.Text = text_cusFax.Text = "";
            }
            else
            {
                MessageBox.Show("Please Complete all info about Customer");
            }
        }

        /************************** import permission ****************************/

       //show details in import permetion
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.TabIndex == 5)
            {
                var whs = from d in context.Warehouses
                          select d.WH_Name;

                var item = from i in context.Items
                           select i.I_Name;

                var suppemails = from s in context.Suppliers
                                 select s.Supplier_Name;

                comboBoxP.Items.Clear();
                comboBox13.Items.Clear();
                comboBox14.Items.Clear();
                comboBoxPerNumI.Items.Clear();
                var pernum = (from p in context.Permetion_Imports
                              select p.Permetion_Num_Imp).Distinct();

                foreach (var pp in pernum)
                {
                    comboBoxPerNumI.Items.Add(pp);
                }

                foreach (var i in whs)
                {
                    comboBox14.Items.Add(i);
                }
                foreach (var ii in item)
                {
                    comboBoxP.Items.Add(ii);
                }
                foreach (var ss in suppemails)
                {
                    comboBox13.Items.Add(ss);
                }
            }

            if (tabControl1.SelectedIndex == 5) // out from our warehouse
            {
                var whs = from d in context.Warehouses
                          select d.WH_Name;


                var suppNms = from s in context.Customers
                              select s.Customer_Name;

                comboBoxWH_NME.Items.Clear();
                comboBoxSuppE.Items.Clear();


                var pernum = (from p in context.Permetion_Exports
                              select p.Permetion_Num_Exp).Distinct();

                foreach (var pp in pernum)
                {
                    comboBoxPerNumE.Items.Add(pp);
                }

                foreach (var i in whs)
                {
                    comboBoxWH_NME.Items.Add(i);
                }
                foreach (var ss in suppNms)
                {
                    comboBoxSuppE.Items.Add(ss);
                }
            }

            if (tabControl1.SelectedIndex == 6) // 
            {
                from.Items.Clear();
                to.Items.Clear();
                pro.Items.Clear();
                Qty.Text = "";
                var whs = from d in context.Warehouses
                          select d.WH_Name;

                foreach (var i in whs)
                {
                    from.Items.Add(i);
                }
            }
        }
        //to add items
        private void button5_Click_1(object sender, EventArgs e)
        {
            if (textPerNum.Text != "" && comboBox13.Text != "" && comboBox14.Text != "")
            {
                panel2.Enabled = true;
            }
            else
            {
                panel2.Enabled = false;
            }
        }
        //add items
        private void AddI_Click_1(object sender, EventArgs e)
        {
            var found = context.Permetion_Imports.Select(i => i.Permetion_Num_Imp == int.Parse(textPerNum.Text));

            if (found != null)
            {
                if (comboBoxP.Text != "" && textBox6.Text != "")
                {
                    ItemsPer ii = new ItemsPer();
                    ii.ProductName = comboBoxP.SelectedItem.ToString();
                    ii.ItemQuantity = int.Parse(textBox6.Text);
                    ii.ProdDate = dateTimePicker1.Value;
                    ii.ExpiDate = dateTimePicker2.Value;
                    listBox1.Items.Add(ii.ProductName + " : " + ii.ItemQuantity);
                    inserted_Items.Add(ii);
                    textBox6.Text = comboBoxP.Text = "";
                }
                else
                {
                    MessageBox.Show(" missing fields required !! ");
                }
            }
            else
            {
                MessageBox.Show(" permission number is exist ! ");
            }
        }
        //Add Import Permission to import items
        private void AddImpPer_Click(object sender, EventArgs e)
        {
            if (textPerNum.Text != "" && comboBox13.Text != "" && comboBox14.Text != "" && listBox1.Items.Count != 0)
            {

                foreach (var d in inserted_Items)
                {
                    var emailSupp = context.Suppliers.Where(i => i.Supplier_Name == comboBox13.Text).Select(i => i.Supplier_Email);
                    int I_ID = context.Items.Where(i => i.I_Name == d.ProductName).Select(i => i.I_Code).First();

                    Permetion_Import PI = new Permetion_Import();
                    PI.Permetion_Num_Imp = int.Parse(textPerNum.Text);
                    PI.Supp_Email = emailSupp.First();
                    PI.I_Code = I_ID;
                    PI.WH_Name = comboBox14.Text;
                    PI.Permetion_Date_I = dateTimePicker5.Value;
                    context.Permetion_Imports.Add(PI);

                    Import_Quantity IQ = new Import_Quantity();
                    IQ.Permetion_Num_I = int.Parse(textPerNum.Text);
                    IQ.Supp_Email = emailSupp.First();
                    IQ.WH_Name = comboBox14.Text;
                    IQ.I_Code = I_ID;
                    IQ.In_Quantity = d.ItemQuantity;
                    IQ.Prod_Date = d.ProdDate;
                    IQ.Expi_Date = d.ExpiDate;
                    context.Import_Quantities.Add(IQ);

                    var found2 = (from dd in context.Item_WareHouses
                                  where (dd.I_Code == I_ID && dd.WH_Name == comboBox14.Text)
                                  select dd).FirstOrDefault();


                    var found = context.Item_WareHouses.Where(i => i.I_Code == I_ID && i.WH_Name == comboBox14.Text).Select(i => i).FirstOrDefault();

                    if (found != null)
                    {
                        int q = found.Quantity.Value;
                        context.Item_WareHouses.Remove(found);
                        item_WareHouse IWH = new item_WareHouse();
                        IWH.I_Code = I_ID;
                        IWH.WH_Name = comboBox14.Text;
                        IWH.Quantity = d.ItemQuantity + q;
                        context.Item_WareHouses.Add(IWH);
                    }
                    else
                    {
                        item_WareHouse IWH = new item_WareHouse();
                        IWH.I_Code = I_ID;
                        IWH.WH_Name = comboBox14.Text;
                        IWH.Quantity = d.ItemQuantity;
                        context.Item_WareHouses.Add(IWH);
                    }
                }
                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show(" mmm ");
                }

                MessageBox.Show("Permission added succesfully");
                textPerNum.Text = comboBoxP.Text = comboBox13.Text = comboBox14.Text = "";
                inserted_Items.Clear();
                listBox1.Items.Clear();

                comboBoxPerNumI.Items.Clear();
                var pernum = (from p in context.Permetion_Imports
                              select p.Permetion_Num_Imp);
                var filtered = pernum.Distinct();
                foreach (var pp in filtered)
                {
                    comboBoxPerNumI.Items.Add(pp);
                }
                

            }
            else
            {
                MessageBox.Show("missing field ");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (textPerNum.Text != "" && comboBox13.Text != "" && comboBox14.Text != "")
            {
                panel2.Enabled = true;
            }
            else
            {
                panel2.Enabled = false;
            }
        }
        //choose permmtion to be updated
       
        //update item in import permetion
        private void EditI_Click_1(object sender, EventArgs e)
        {
            if (flag)
            {
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    nms.Add(listBox2.Items[i].ToString());
                }
                flag = false;
            }

            string perNum = comboBoxPerNumI.SelectedItem.ToString();
            if (perNum != "")
            {
                if (comboBox5.Text != "" && textBox8.Text != "")
                {
                    int p = 0;
                    ItemsPer ii = new ItemsPer();
                    ii.ProductName = comboBox5.SelectedItem.ToString();
                    ii.ItemQuantity = int.Parse(textBox8.Text);
                    ii.ProdDate = dateTimePicker4.Value;
                    ii.ExpiDate = dateTimePicker3.Value;
                    ii.oldRecord = listBox2.SelectedItem.ToString();
                    p = listBox2.SelectedIndex;
                    listBox2.Items[p] = comboBox5.SelectedItem.ToString();
                    inserted_Items.Add(ii);
                    textBox8.Text = comboBox5.Text = "";
                }
                else
                {
                    MessageBox.Show(" missing fields required !! ");
                }
            }
            else
            {
                MessageBox.Show(" permission number is exist ! ");
            }
        }
        //Updat import Permetion

        private void updatePerI_Click(object sender, EventArgs e)
        {
            if (comboBoxPerNumI.Text != "" && comboBox8.Text != "" && comboBox9.Text != "")
            {
                flag = true;

                int x = 0;
                foreach (var u in inserted_Items)// inserted item have the value i made change on it
                {
                    //his for  warhouse_Item
                    int iCode = (context.Items.Where(i => i.I_Name == u.ProductName).Select(i => i.I_Code)).First();
                    var there = context.Item_WareHouses.Where(i => i.I_Code == iCode && i.WH_Name == comboBox9.Text).Select(i => i).FirstOrDefault();
                    string edit = listBox2.SelectedItem.ToString();
                    var oldIcode = context.Items.Where(i => i.I_Name == u.oldRecord).Select(i => i.I_Code).First();
                    var oldRecord = context.Item_WareHouses.Where(i => i.I_Code == oldIcode && i.WH_Name == comboBox9.Text).Select(i => i).First();
                    context.Item_WareHouses.Remove(oldRecord);

                    if (there != null)   //there is element ..
                    {
                        var oldQ = context.Item_WareHouses.Where(i => i.I_Code == iCode).Select(i => i.Quantity).First();
                        int newQ = u.ItemQuantity + (int)oldQ;
                        there.Quantity = newQ;
                    }
                    else
                    {
                        item_WareHouse newRecord = new item_WareHouse();
                        newRecord.I_Code = iCode;
                        newRecord.WH_Name = comboBox9.Text;
                        newRecord.Quantity = u.ItemQuantity;
                        context.Item_WareHouses.Add(newRecord);
                    }

                    // QI

                    var prevRecord = context.Import_Quantities.AsEnumerable().Where(i => i.I_Code == oldIcode && i.Permetion_Num_I == int.Parse(comboBoxPerNumI.Text)).Select(i => i).FirstOrDefault();
                    context.Import_Quantities.Remove(prevRecord);
                    Import_Quantity NewRec = new Import_Quantity();
                    NewRec.In_Quantity += u.ItemQuantity;
                    NewRec.I_Code = iCode;
                    NewRec.WH_Name = comboBox9.Text;
                    string email = context.Suppliers.Where(i => i.Supplier_Name == comboBox8.Text).Select(i => i.Supplier_Email).FirstOrDefault();
                    NewRec.Supp_Email = email;
                    NewRec.Permetion_Num_I = int.Parse(comboBoxPerNumI.Text);
                    NewRec.Expi_Date = u.ExpiDate;
                    NewRec.Prod_Date = u.ProdDate;
                    context.Import_Quantities.Add(NewRec);

                    // PI

                    var PIPrev = context.Permetion_Imports.AsEnumerable().Where(i => i.I_Code == oldIcode && i.Permetion_Num_Imp== int.Parse(comboBoxPerNumI.Text)).Select(i => i).FirstOrDefault();
                    context.Permetion_Imports.Remove(PIPrev);
                    Permetion_Import NewPer = new Permetion_Import();
                    NewPer.Supp_Email = email;
                    NewPer.Permetion_Num_Imp = int.Parse(comboBoxPerNumI.Text);
                    NewPer.I_Code = iCode;
                    NewPer.WH_Name = comboBox9.Text;
                    NewPer.Permetion_Date_I = dateTimePicker6.Value;
                    context.Permetion_Imports.Add(NewPer);
                    x++;
                }
                context.SaveChanges();
                inserted_Items.Clear();
                nms.Clear();
                x = 0;
            }
        }
        //show details about permetion to update items in
        private void comboBoxPerNumI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPerNumI.SelectedItem != null)
            {
                comboBox5.Items.Clear();
                comboBox8.Items.Clear();
                comboBox9.Items.Clear();

                var whs = from d in context.Warehouses
                          select d.WH_Name;

                var suppemails = from s in context.Suppliers
                                 select s.Supplier_Name;

                foreach (var i in whs)
                {
                    comboBox9.Items.Add(i);
                }
                foreach (var ss in suppemails)
                {
                    comboBox8.Items.Add(ss);
                }

                int per_id = (int)comboBoxPerNumI.SelectedItem;
                MessageBox.Show(comboBoxPerNumI.SelectedItem.ToString());
                var suppEmail = (from ii in context.Permetion_Imports
                                 where ii.Permetion_Num_Imp == per_id
                                 select ii.Supp_Email).First();

                string suppNm = (context.Suppliers.Find(suppEmail)).Supplier_Name.ToString();
                string WH_NM = context.Permetion_Imports.Where(i => i.Permetion_Num_Imp == per_id).Select(i => i.WH_Name).First();
                var PerDate = context.Permetion_Imports.Where(i => i.Permetion_Num_Imp == per_id).Select(i => i.Permetion_Date_I).First();
                var dataInfo = context.Import_Quantities.Where(i => i.Permetion_Num_I == per_id).Select(i => i.I_Code);

                comboBox8.Text = suppNm;
                comboBox9.Text = WH_NM;
                dateTimePicker6.Value = PerDate.Value;

                listBox2.Items.Clear();
                foreach (var d in dataInfo)
                {
                    var dd = context.Items.Find(d).I_Name;
                    listBox2.Items.Add(dd);
                }
            }
        }
        //
        /************************** Export permission ****************************/
        private void AE_Click(object sender, EventArgs e)
        {
            if (textBoxPerNE.Text != "" && comboBoxWH_NME.Text != "" && comboBoxSuppE.Text != "")
            {
                panel5.Enabled = true;
            }
            else
            {
                panel5.Enabled = false;
            }
        }
        private void AddPerL_Click(object sender, EventArgs e)
        {
            var found = context.Permetion_Exports.Select(i => i.Permetion_Num_Exp == int.Parse(textBoxPerNE.Text));
            if (found != null)
            {
                if (comboBoxINM_E.Text != "" && textBoxQE.Text != "")
                {
                    ItemsPer ii = new ItemsPer();
                    ii.ProductName = comboBoxINM_E.SelectedItem.ToString();
                    ii.ItemQuantity = int.Parse(textBoxQE.Text);
                    ii.ProdDate = dateTimePicker11.Value;
                    ii.ExpiDate = dateTimePicker10.Value;
                    listBox4.Items.Add(ii.ProductName + " : " + ii.ItemQuantity);
                    inserted_Items.Add(ii);
                    textBoxQE.Text = comboBoxINM_E.Text = "";
                }
                else
                {
                    MessageBox.Show(" missing fields required !! ");
                }
            }
            else
            {
                MessageBox.Show(" permission number is exist ! ");
            }
        }
        private void AddPerE_Click(object sender, EventArgs e)
        {
            if (inserted_Items.Count > 0 && textBoxPerNE.Text != "" && comboBoxWH_NME.Text != "" && comboBoxSuppE.Text != "" && listBox4.Items.Count != 0)
            {
                foreach (var d in inserted_Items)
                {
                    var emailCus = context.Customers.Where(i => i.Customer_Name == comboBoxSuppE.Text).Select(i => i.Customer_Email);
                    int I_ID = context.Items.AsEnumerable().Where(i => i.I_Name == d.ProductName).Select(i => i.I_Code).First();

                    var QuantityFounded = (context.Item_WareHouses.Find(comboBoxWH_NME.Text, I_ID).Quantity);
                    if (QuantityFounded != null)     // there are items in wh
                    {
                        if (QuantityFounded.Value > d.ItemQuantity)
                        {
                            Permetion_Export PE = new Permetion_Export();
                            PE.Permetion_Num_Exp = int.Parse(textBoxPerNE.Text);
                            PE.Customer_Email = emailCus.First();
                            PE.I_Code = I_ID;
                            PE.WH_Name = comboBoxWH_NME.Text;
                            PE.Permetion_Date_Exp = dateTimePicker12.Value;
                            context.Permetion_Exports.Add(PE);

                            Export_Quantity EQ = new Export_Quantity();
                            EQ.Permetion_Num_Exp = int.Parse(textBoxPerNE.Text);
                            EQ.Customer_Email = emailCus.First();
                            EQ.WH_Name = comboBoxWH_NME.Text;
                            EQ.I_Code = I_ID;
                            EQ.Out_Quantity = d.ItemQuantity;
                            EQ.Prod_Date = d.ProdDate;
                            EQ.Expi_Date = d.ExpiDate;
                            context.Export_Quantities.Add(EQ);

                            var found = context.Item_WareHouses.Where(i => i.I_Code == I_ID && i.WH_Name == comboBoxWH_NME.Text).Select(i => i).First();

                            //if (found != null)
                            //{
                            int q = found.Quantity.Value;  // old quantity 
                            context.Item_WareHouses.Remove(found);
                            item_WareHouse IWH = new item_WareHouse();
                            IWH.I_Code = I_ID;
                            IWH.WH_Name = comboBoxWH_NME.Text;
                            if (q > d.ItemQuantity)
                            {
                                IWH.Quantity = q - d.ItemQuantity;
                            }
                            context.Item_WareHouses.Add(IWH);


                        }
                        else
                        {
                            MessageBox.Show(" there are no enouph items in the warehouse !! ");
                        }
                    }
                    else // no items
                    {
                        MessageBox.Show(" NOT FOUND !! ");
                    }







                }
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Permission added succesfully");
                }
                catch
                {
                    MessageBox.Show(" Can't Add to Database ");
                }
                textBoxPerNE.Text = comboBoxINM_E.Text = comboBoxWH_NME.Text = comboBoxSuppE.Text = "";
                inserted_Items.Clear();
                listBox4.Items.Clear();

                comboBoxPerNumE.Items.Clear();
                var pernum = (from p in context.Permetion_Exports
                              select p.Permetion_Num_Exp);
                var filtered = pernum.Distinct();
                foreach (var pp in filtered)
                {
                    comboBoxPerNumE.Items.Add(pp);
                }
            }
            else
            {
                MessageBox.Show("missing field ");
            }
        }

        private void comboBoxWH_NME_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxINM_E.Items.Clear();
            var item = from i in context.Item_WareHouses
                       where i.WH_Name == comboBoxWH_NME.Text
                       select i.Item.I_Name;
            foreach (var ii in item)
            {
                comboBoxINM_E.Items.Add(ii);
            }
            comboBoxPerNumE.Items.Clear();
        }

        //
        private void comboBox_WHNM_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxINM_E.Items.Clear();
            var item = from i in context.Item_WareHouses
                       where i.WH_Name == comboBoxWH_NME.Text
                       select i.Item.I_Name;
            foreach (var ii in item)
            {
                comboBoxINM_E.Items.Add(ii);
            }
            comboBoxPerNumE.Items.Clear();
        }

        private void comboBoxPerNumE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPerNumE.SelectedItem != null)
            {
                comboBox_CusNM.Items.Clear();
                comboBox_WHNM.Items.Clear();
                comboBoxI_nm.Items.Clear();

                var whs = from d in context.Warehouses
                          select d.WH_Name;

                var suppemails = from s in context.Customers
                                 select s.Customer_Name;

                foreach (var i in whs)
                {
                    comboBox_WHNM.Items.Add(i);
                }
                foreach (var ss in suppemails)
                {
                    comboBox_CusNM.Items.Add(ss);
                }

                int per_id = (int)comboBoxPerNumE.SelectedItem;

                var suppEmail = (from ii in context.Permetion_Exports
                                 where ii.Permetion_Num_Exp == per_id
                                 select ii.Customer_Email).First();

                string suppNm = (context.Customers.Find(suppEmail)).Customer_Name.ToString();
                string WH_NM = context.Permetion_Exports.Where(i => i.Permetion_Num_Exp == per_id).Select(i => i.WH_Name).First();
                var PerDate = context.Permetion_Exports.Where(i => i.Permetion_Num_Exp == per_id).Select(i => i.Permetion_Date_Exp).First();
                var dataInfo = context.Export_Quantities.Where(i => i.Permetion_Num_Exp == per_id).Select(i => i.I_Code);

                comboBox_CusNM.Text = suppNm;
                comboBox_WHNM.Text = WH_NM;
                dateTimePicker9.Value = PerDate.Value;

                listBox3.Items.Clear();
                foreach (var d in dataInfo)
                {
                    var dd = context.Items.Find(d).I_Name;
                    listBox3.Items.Add(dd);
                }
            }
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem == null)
            {
            }
            else
            {
                string selected = listBox3.SelectedItem.ToString();
                int pernum = (int)comboBoxPerNumE.SelectedItem;
                int id = (context.Items.Where(i => i.I_Name == selected).Select(i => i.I_Code)).First();
                var OutQ = from d in context.Export_Quantities
                           where (d.Permetion_Num_Exp == pernum && d.I_Code == id)
                           select d.Out_Quantity;

                var outdate = from d in context.Export_Quantities
                              where (d.Permetion_Num_Exp == pernum && d.I_Code == id)
                              select d.Expi_Date;

                var indate = from d in context.Export_Quantities
                             where (d.Permetion_Num_Exp == pernum && d.I_Code == id)
                             select d.Prod_Date;


                comboBoxI_nm.Items.Clear();

                var items = (from ii in context.Item_WareHouses
                             where ii.WH_Name == comboBox_WHNM.Text
                             select ii.Item.I_Name);

                List<string> item = new List<string>();
                foreach (var i in items)
                {
                    item.Add(i.ToString());
                }

                HashSet<string> hs = new HashSet<string>();
                for (int i = 0; i < listBox3.Items.Count; i++)
                {
                    hs.Add(listBox3.Items[i].ToString());
                }

                for (int i = 0; i < item.Count; i++)
                {
                    if (!hs.Contains(item[i]))        // false true 
                    {
                        comboBoxI_nm.Items.Add(item[i]);
                    }
                }
                comboBoxI_nm.Text = selected;
                if (OutQ.FirstOrDefault() != 0 && indate.FirstOrDefault() != null && outdate.FirstOrDefault() != null)
                {
                    textBoxQunE.Text = (OutQ.FirstOrDefault()).ToString();
                    dateTimePicker8.Value = (indate.FirstOrDefault()).Value;
                    dateTimePicker7.Value = (outdate.FirstOrDefault()).Value;
                }
            }
        }
        private void AddLE_Click(object sender, EventArgs e)
        {
            if (flag2)
            {
                for (int i = 0; i < listBox3.Items.Count; i++)
                {
                    nms2.Add(listBox3.Items[i].ToString());
                }
                flag2 = false;
            }

            string perNum = comboBoxPerNumE.SelectedItem.ToString();
            if (perNum != "")
            {
                if (comboBoxI_nm.Text != "" && textBoxQunE.Text != "")
                {
                    int p = 0;
                    ItemsPer ii = new ItemsPer();
                    ii.ProductName = comboBoxI_nm.SelectedItem.ToString();
                    ii.ItemQuantity = int.Parse(textBoxQunE.Text);
                    ii.ProdDate = dateTimePicker8.Value;
                    ii.ExpiDate = dateTimePicker7.Value;
                    ii.oldRecord = listBox3.SelectedItem.ToString();
                    p = listBox3.SelectedIndex;
                    listBox3.Items[p] = comboBoxI_nm.SelectedItem.ToString();
                    inserted_Items.Add(ii);
                    textBoxQunE.Text = comboBoxI_nm.Text = "";
                }
                else
                {
                    MessageBox.Show(" missing fields required !! ");
                }
            }
            else
            {
                MessageBox.Show(" permission number is exist ! ");
            }
        }
        private void UpdatePerE_Click(object sender, EventArgs e)
        {
            if (comboBoxPerNumI.Text != "" && comboBox8.Text != "" && comboBox9.Text != "")
            {
                flag = true;

                int x = 0;
                foreach (var u in inserted_Items)// inserted item have the value i made change on it
                {
                    //his for  warhouse_Item
                    int iCode = (context.Items.Where(i => i.I_Name == u.ProductName).Select(i => i.I_Code)).First();
                    var there = context.Item_WareHouses.Where(i => i.I_Code == iCode && i.WH_Name == comboBox9.Text).Select(i => i).FirstOrDefault();
                    string edit = listBox2.SelectedItem.ToString();
                    var oldIcode = context.Items.Where(i => i.I_Name == u.oldRecord).Select(i => i.I_Code).First();
                    var oldRecord = context.Item_WareHouses.Where(i => i.I_Code == oldIcode && i.WH_Name == comboBox9.Text).Select(i => i).First();
                    context.Item_WareHouses.Remove(oldRecord);

                    if (there != null)   //there is element ..
                    {
                        var oldQ = context.Item_WareHouses.Where(i => i.I_Code == iCode).Select(i => i.Quantity).First();
                        int newQ = u.ItemQuantity + (int)oldQ;
                        there.Quantity = newQ;
                    }
                    else
                    {
                        item_WareHouse newRecord = new item_WareHouse();
                        newRecord.I_Code = iCode;
                        newRecord.WH_Name = comboBox9.Text;
                        newRecord.Quantity = u.ItemQuantity;
                        context.Item_WareHouses.Add(newRecord);
                    }

                    // QI

                    var prevRecord = context.Import_Quantities.AsEnumerable().Where(i => i.I_Code == oldIcode && i.Permetion_Num_I == int.Parse(comboBoxPerNumI.Text)).Select(i => i).FirstOrDefault();
                    context.Import_Quantities.Remove(prevRecord);
                    Import_Quantity NewRec = new Import_Quantity();
                    NewRec.In_Quantity += u.ItemQuantity;
                    NewRec.I_Code = iCode;
                    NewRec.WH_Name = comboBox9.Text;
                    string email = context.Suppliers.Where(i => i.Supplier_Name == comboBox8.Text).Select(i => i.Supplier_Email).FirstOrDefault();
                    NewRec.Supp_Email = email;
                    NewRec.Permetion_Num_I = int.Parse(comboBoxPerNumI.Text);
                    NewRec.Expi_Date = u.ExpiDate;
                    NewRec.Prod_Date = u.ProdDate;
                    context.Import_Quantities.Add(NewRec);

                    // PI

                    var PIPrev = context.Permetion_Imports.AsEnumerable().Where(i => i.I_Code == oldIcode && i.Permetion_Num_Imp == int.Parse(comboBoxPerNumI.Text)).Select(i => i).FirstOrDefault();
                    context.Permetion_Imports.Remove(PIPrev);
                    Permetion_Import NewPer = new Permetion_Import();
                    NewPer.Supp_Email = email;
                    NewPer.Permetion_Num_Imp = int.Parse(comboBoxPerNumI.Text);
                    NewPer.I_Code = iCode;
                    NewPer.WH_Name = comboBox9.Text;
                    NewPer.Permetion_Date_I = dateTimePicker6.Value;
                    context.Permetion_Imports.Add(NewPer);
                    x++;
                }
                context.SaveChanges();
                inserted_Items.Clear();
                nms.Clear();
                x = 0;
            }
        }

        private void comboBoxI_nm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void from_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_whs = from.SelectedItem.ToString();
            to.Items.Clear();
            to.Text = "";
            pro.Items.Clear();
            Qty.Text = pro.Text = "";
            var All_whs = (from ii in context.Warehouses
                           select ii.WH_Name);

            var All_Items = (from ii in context.Item_WareHouses
                             where ii.WH_Name == selected_whs
                             select ii.Item.I_Name);

            foreach (var d in All_whs)
            {
                if (selected_whs != d)
                {
                    to.Items.Add(d);
                }
            }
            foreach (var d in All_Items)
            {
                pro.Items.Add(d);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (to.Text != "" && from.Text != "" && Qty.Text != "" && pro.Text != "")
            {
                var iCode = context.Items.Where(i => i.I_Name == pro.Text).Select(i => i.I_Code).FirstOrDefault();
                var StoreQ = context.Item_WareHouses.Where(i => i.WH_Name == from.Text && i.I_Code == iCode).Select(i => i.Quantity).FirstOrDefault();
                if (int.Parse(Qty.Text) < StoreQ)
                {
                    Move_To mv = new Move_To();
                    mv.I_Code = iCode;
                    mv.ToWH_Nm = to.Text;
                    mv.FromWH_Nm = from.Text;
                    mv.Quantity = int.Parse(Qty.Text);
                    mv.Move_Date = dateTimePicker13.Value;
                    mv.Production_Date = dateTimePicker14.Value;
                    mv.Expire_Date = dateTimePicker15.Value;
                    context.Move_Tos.Add(mv);

                    var FromWh = context.Item_WareHouses.Where(i => i.I_Code == iCode && i.WH_Name == from.Text).Select(i => i).First();
                    FromWh.Quantity = StoreQ - int.Parse(Qty.Text);

                    var ToWh = context.Item_WareHouses.Where(i => i.I_Code == iCode && i.WH_Name == to.Text).Select(i => i).First();
                    if (ToWh != null)  // founded item 
                    {
                        int q = ToWh.Quantity.Value;
                        ToWh.Quantity = int.Parse(Qty.Text) + q;
                    }
                    else
                    {
                        item_WareHouse newRecord = new item_WareHouse();
                        newRecord.I_Code = iCode;
                        newRecord.WH_Name = to.Text;
                        newRecord.Quantity = int.Parse(Qty.Text);
                        context.Item_WareHouses.Add(newRecord);
                    }
                    context.SaveChanges();
                    MessageBox.Show("successfully");
                }
                else
                {
                    MessageBox.Show(" no enouph quantity !!");
                }
            }
            else
            {
                MessageBox.Show(" Missing fields  ");
            }
        }

        private void pro_SelectedIndexChanged(object sender, EventArgs e)
        {
            var iCode = context.Items.Where(i => i.I_Name == pro.Text).Select(i => i.I_Code).FirstOrDefault();
            var rec = context.Import_Quantities.Where(i => i.WH_Name == from.Text && i.I_Code == iCode).Select(i => i).First();
            dateTimePicker14.Value = rec.Prod_Date.Value;
            dateTimePicker15.Value = rec.Expi_Date.Value;
        }

      
    }
}

