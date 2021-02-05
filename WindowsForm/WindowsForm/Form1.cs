using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using WEBAPISON.Models;
using Newtonsoft.Json;
using System.Security.Policy;

namespace WindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnvericek_Click(object sender, EventArgs e) // Products Get Values
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            HttpResponseMessage response = await client.GetAsync("api/product");
            string result = await response.Content.ReadAsStringAsync();
            List<Products> jsonList = JsonConvert.DeserializeObject<List<Products>>(result);
            foreach (var item in jsonList)
            {
                string[] veri = { "" + item.id, item.name, "" + item.SupplierID, "" + item.CategoryID, "" + item.QuantityPerUnit, "" + item.UnitPrice, "" + item.UnitsInStock, "" + item.UnitsOnOrder, "" + item.ReorderLevel, "" + item.Discontinued, "" };
                listView1.Items.Add(new ListViewItem(veri));
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.AllowColumnReorder = true;
            listView2.AllowColumnReorder = true;
            listView3.AllowColumnReorder = true;
            listView4.AllowColumnReorder = true;
            listView5.AllowColumnReorder = true;
            listView6.AllowColumnReorder = true;
            listView7.AllowColumnReorder = true;
        }

        private async void btnadd_Click(object sender, EventArgs e)  //Product adding Button
        {
            Products prod = new Products();
            prod.name = txtname.Text;
            prod.SupplierID = Convert.ToInt32(txtsupplierid.Text);
            prod.CategoryID = Convert.ToInt32(txtcategoryid.Text);
            prod.QuantityPerUnit = txtquantity.Text;
            prod.UnitPrice = Convert.ToInt32(txtprice.Text);
            prod.UnitsInStock = Convert.ToInt32(txtstock.Text);
            prod.UnitsOnOrder = Convert.ToInt16(txtorder.Text);
            prod.ReorderLevel = Convert.ToInt16(txtreored.Text);
            prod.Discontinued = Convert.ToBoolean(txtdiscontinued.Text);
            var jsonString = JsonConvert.SerializeObject(prod);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/product", content).Result;
            label20.Text = "" + result;
            MessageBox.Show("Kayıt Eklendi.");


        }

        private async void ordersverilericek_Click(object sender, EventArgs e) //Orders Get values Button
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            HttpResponseMessage response = await client.GetAsync("api/orders");
            string result = await response.Content.ReadAsStringAsync();
            List<Orders> jsonList = JsonConvert.DeserializeObject<List<Orders>>(result);
            foreach (var item in jsonList)
            {
                string[] veri = { "" + item.id, item.customerid, "" + item.employeeid, "" + item.orderdate, "" + item.requireddate, "" + item.shippeddate, "" + item.shipvia, "" + item.freight, "" + item.shipname, "" };
                listView2.Items.Add(new ListViewItem(veri));
            }
        }

        private async void categoriesvericek_Click(object sender, EventArgs e) // Categories Get values Button
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            HttpResponseMessage response = await client.GetAsync("api/categories");
            string result = await response.Content.ReadAsStringAsync();
            List<Categories> jsonList = JsonConvert.DeserializeObject<List<Categories>>(result);
            foreach (var item in jsonList)
            {
                string[] veri = { "" + item.id, item.description, "" + item.name, "" };
                listView3.Items.Add(new ListViewItem(veri));
            }
        }

        private void button5_Click(object sender, EventArgs e) // Add Categories Button
        {
            Categories cat = new Categories();
            cat.description = textBox9.Text;
            cat.name = textBox10.Text;
            var jsonString = JsonConvert.SerializeObject(cat);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/categories", content).Result;
            label21.Text = "" + result;
            MessageBox.Show("Kayıt Eklendi.");

        }

        private async void button4_Click(object sender, EventArgs e)  // Customers Get values Button
        {
            
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            HttpResponseMessage response = await client.GetAsync("api/customers");
            string result = await response.Content.ReadAsStringAsync();
            List<Customers> jsonList = JsonConvert.DeserializeObject<List<Customers>>(result);
            foreach (var item in jsonList)
            {
                string[] veri = { "" + item.id, item.companyname, "" + item.contactname, "" + item.contacttitle, "" };
                listView4.Items.Add(new ListViewItem(veri));
            }
        }

        private async void button11_Click(object sender, EventArgs e)   // Suppliers Get values
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            HttpResponseMessage response = await client.GetAsync("api/suppliers");
            string result = await response.Content.ReadAsStringAsync();
            List<Suppliers> jsonList = JsonConvert.DeserializeObject<List<Suppliers>>(result);
            foreach (var item in jsonList)
            {
                string[] veri = { "" + item.id, item.companyname, "" + item.contactname, "" + item.contacttitle, "" };
                listView5.Items.Add(new ListViewItem(veri));
            }
        }

        private async void button15_Click(object sender, EventArgs e)// Shippers Get Values
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            HttpResponseMessage response = await client.GetAsync("api/shippers");
            string result = await response.Content.ReadAsStringAsync();
            List<Shippers> jsonList = JsonConvert.DeserializeObject<List<Shippers>>(result);
            foreach (var item in jsonList)
            {
                string[] veri = { "" + item.id, item.companyname, "" + item.phone, "" };
                listView6.Items.Add(new ListViewItem(veri));
            }
        }

        private async void button19_Click(object sender, EventArgs e) // Employeees Get values
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            HttpResponseMessage response = await client.GetAsync("api/employess");
            string result = await response.Content.ReadAsStringAsync();
            List<Employess> jsonList = JsonConvert.DeserializeObject<List<Employess>>(result);
            foreach (var item in jsonList)
            {
                string[] veri = { "" + item.id, item.lastname, "" + item.firstname, "" + item.title, "" + item.titleofcourtesy, "" + item.birthdate, "" + item.hiradate, "" + item.notes, "" };
                listView7.Items.Add(new ListViewItem(veri));
            }
        }

        private void btndelete_Click(object sender, EventArgs e)  // Delete Products
        {
            Products prod = new Products();
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            string ID = listView1.SelectedItems[0].Text;
            var result = client.DeleteAsync("api/product/" + ID).Result;
            label20.Text = "" + result;
            MessageBox.Show("Kayıt Silindi.");
        }

        private void button1_Click(object sender, EventArgs e) // Orders add Button
        {
            Orders ord = new Orders();
            ord.customerid = textBox1.Text;
            ord.employeeid = Convert.ToInt32(textBox2.Text);
            ord.orderdate = maskedTextBox2.Text;
            ord.requireddate = maskedTextBox3.Text;
            ord.shippeddate = maskedTextBox4.Text;
            ord.shipvia = Convert.ToInt32(textBox6.Text);
            ord.freight = Convert.ToDouble(textBox7.Text);
            ord.shipname = textBox8.Text;
            var jsonString = JsonConvert.SerializeObject(ord);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/orders", content).Result;
            label37.Text = "" + result;
            MessageBox.Show("Kayıt Eklendi.");
        }

        private void button8_Click(object sender, EventArgs e) // Customers add values
        {
            Customers cus = new Customers();
            cus.companyname = textBox11.Text;
            cus.contactname = textBox12.Text;
            cus.contacttitle = textBox13.Text;
            var jsonString = JsonConvert.SerializeObject(cus);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/customers", content).Result;
            label38.Text = "" + result;
            MessageBox.Show("Kayıt Eklendi.");
        }

        private void button12_Click(object sender, EventArgs e) // Suppliers add Button
        {
            Suppliers cus = new Suppliers();
            cus.companyname = textBox14.Text;
            cus.contactname = textBox15.Text;
            cus.contacttitle = textBox16.Text;
            var jsonString = JsonConvert.SerializeObject(cus);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/suppliers", content).Result;
            label39.Text = "" + result;
            MessageBox.Show("Kayıt Eklendi.");
        }

        private void button16_Click(object sender, EventArgs e) // Shippers add value
        {
            Shippers ship = new Shippers();
            ship.companyname = textBox17.Text;
            ship.phone = maskedTextBox1.Text;
            var jsonString = JsonConvert.SerializeObject(ship);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/shippers", content).Result;
            label40.Text = "" + result;
            MessageBox.Show("Kayıt Eklendi.");
        }

        private void button20_Click(object sender, EventArgs e) // Employees add Button
        {
            Employess emp = new Employess();
            emp.lastname = textBox19.Text;
            emp.firstname = textBox20.Text;
            emp.title = textBox21.Text;
            emp.titleofcourtesy = textBox22.Text;
            emp.birthdate = maskedTextBox5.Text;
            emp.hiradate = maskedTextBox6.Text;
            emp.notes = richTextBox1.Text;
            var jsonString = JsonConvert.SerializeObject(emp);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/employess", content).Result;
            label41.Text = "" + result;
            MessageBox.Show("Kayıt Eklendi.");
        }

        private void button22_Click(object sender, EventArgs e) // Employees Update Button
        {
            Employess emp = new Employess();
            emp.lastname = textBox19.Text;
            emp.firstname = textBox20.Text;
            emp.title = textBox21.Text;
            emp.titleofcourtesy = textBox22.Text;
            emp.birthdate = maskedTextBox5.Text;
            emp.hiradate = maskedTextBox6.Text;
            emp.notes = richTextBox1.Text;
            var jsonString = JsonConvert.SerializeObject(emp);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            string ID = listView7.SelectedItems[0].Text;
            listView7.Items.Clear();
            var result = client.PutAsync("api/employess/" +ID, content).Result;
            label41.Text = "" + result;
            MessageBox.Show("Kayıt Güncellendi.");
        }

        private void btnUpdate_Click(object sender, EventArgs e) // Products Update Button
        {
            Products prod = new Products();
            prod.name = txtname.Text;
            prod.SupplierID = Convert.ToInt32(txtsupplierid.Text);
            prod.CategoryID = Convert.ToInt32(txtcategoryid.Text);
            prod.QuantityPerUnit = txtquantity.Text;
            prod.UnitPrice = Convert.ToInt32(txtprice.Text);
            prod.UnitsInStock = Convert.ToInt32(txtstock.Text);
            prod.UnitsOnOrder = Convert.ToInt16(txtorder.Text);
            prod.ReorderLevel = Convert.ToInt16(txtreored.Text);
            prod.Discontinued = Convert.ToBoolean(txtdiscontinued.Text);
            var jsonString = JsonConvert.SerializeObject(prod);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            string ID = listView1.SelectedItems[0].Text;
            listView1.Items.Clear();
            var result = client.PutAsync("api/product/"+ID, content).Result;
            label20.Text = "" + result;
            MessageBox.Show("Kayıt Güncellendi.");
        }

        private void button2_Click(object sender, EventArgs e)  // Orders Update Button
        {
            Orders ord = new Orders();
            ord.customerid = textBox1.Text;
            ord.employeeid = Convert.ToInt32(textBox2.Text);
            ord.orderdate = maskedTextBox2.Text;
            ord.requireddate = maskedTextBox3.Text;
            ord.shippeddate = maskedTextBox4.Text;
            ord.shipvia = Convert.ToInt32(textBox6.Text);
            ord.freight = Convert.ToDouble(textBox7.Text);
            ord.shipname = textBox8.Text;
            var jsonString = JsonConvert.SerializeObject(ord);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            string ID = listView2.SelectedItems[0].Text;
            listView2.Items.Clear();
            var result = client.PutAsync("api/orders/"+ID, content).Result;
            label37.Text = "" + result;
            MessageBox.Show("Kayıt Güncellendi.");
        }

        private void button7_Click(object sender, EventArgs e) // Categories update Button
        {
            Categories cat = new Categories();
            cat.description = textBox9.Text;
            cat.name = textBox10.Text;
            var jsonString = JsonConvert.SerializeObject(cat);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            string ID = listView3.SelectedItems[0].Text;
            listView3.Items.Clear();
            var result = client.PutAsync("api/categories/"+ID, content).Result;
            label21.Text = "" + result;
            MessageBox.Show("Kayıt Güncellendi.");
        }

        private void button10_Click(object sender, EventArgs e)  // Customers Update Button
        {
            Customers cus = new Customers();
            cus.companyname = textBox11.Text;
            cus.contactname = textBox12.Text;
            cus.contacttitle = textBox13.Text;
            var jsonString = JsonConvert.SerializeObject(cus);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            string ID = listView4.SelectedItems[0].Text;
            listView4.Items.Clear();
            var result = client.PutAsync("api/customers/" +ID, content).Result;
            label38.Text = "" + result;
            MessageBox.Show("Kayıt Güncellendi.");
        }

        private void button14_Click(object sender, EventArgs e) // Suppliers Update Button
        {
            Suppliers cus = new Suppliers();
            cus.companyname = textBox14.Text;
            cus.contactname = textBox15.Text;
            cus.contacttitle = textBox16.Text;
            var jsonString = JsonConvert.SerializeObject(cus);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            string ID = listView5.SelectedItems[0].Text;
            listView5.Items.Clear();
            var result = client.PutAsync("api/suppliers/" +ID, content).Result;
            label39.Text = "" + result;
            MessageBox.Show("Kayıt Güncellendi.");
        }

        private void button18_Click(object sender, EventArgs e)// Shippers Update button
        {
            Shippers ship = new Shippers();
            ship.companyname = textBox17.Text;
            ship.phone = maskedTextBox1.Text;
            var jsonString = JsonConvert.SerializeObject(ship);
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            string ID = listView6.SelectedItems[0].Text;
            listView6.Items.Clear();
            var result = client.PutAsync("api/shippers/" +ID, content).Result;
            label40.Text = "" + result;
            MessageBox.Show("Kayıt Güncellendi.");
        }

        private void button21_Click(object sender, EventArgs e)  // Employees Delete Button
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            string ID = listView7.SelectedItems[0].Text;
            listView7.Items.Clear();
            var result = client.DeleteAsync("api/employess/" + ID).Result;
            label41.Text = "" + result;
            MessageBox.Show("Kayıt Silindi.");
        }

        private void button3_Click(object sender, EventArgs e) // Orders Delete Button
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            string ID = listView2.SelectedItems[0].Text;
            listView2.Items.Clear();
            var result = client.DeleteAsync("api/orders/" + ID).Result;
            label37.Text = "" + result;
            MessageBox.Show("Kayıt Silindi.");
        }

        private void button6_Click(object sender, EventArgs e) // Categories Delete Button
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            string ID = listView3.SelectedItems[0].Text;
            listView3.Items.Clear();
            var result = client.DeleteAsync("api/categories/" + ID).Result;
            label21.Text = "" + result;
            MessageBox.Show("Kayıt Silindi.");
        }

        private void button9_Click(object sender, EventArgs e) // Customers Delete Button
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            string ID = listView4.SelectedItems[0].Text;
            listView4.Items.Clear();
            var result = client.DeleteAsync("api/customers/" + ID).Result;
            label38.Text = "" + result;
            MessageBox.Show("Kayıt Silindi.");
        }

        private void button13_Click(object sender, EventArgs e) // Suppliers Delete Button
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            string ID = listView5.SelectedItems[0].Text;
            listView5.Items.Remove(listView5.SelectedItems[0]);
            listView5.Items.Clear();
            var result = client.DeleteAsync("api/suppliers/" + ID).Result;
            label39.Text = "" + result;
            MessageBox.Show("Kayıt Silindi.");
        }

        private void button17_Click(object sender, EventArgs e) // Shippers Delete Button
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/");
            string ID = listView6.SelectedItems[0].Text;
            listView6.Items.Remove(listView6.SelectedItems[0]);
            listView6.Items.Clear();
            var result = client.DeleteAsync("api/shippers/" + ID).Result;
            label40.Text = "" + result;
            MessageBox.Show("Kayıt Silindi.");
        }
    }
}
