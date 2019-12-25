using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace TraceTimingCapitalflow
{
    public partial class Form1 : Form
    {
        public static IWebDriver driver;
        public string strdate;
        public Form1()
        {
            InitializeComponent();
        }


        private void LoopCollect()
        {
            strdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string strtime = "14:30到15:00资金流向";
            for (int i = 0; i < Convert.ToInt32(textBox1.Text.Trim()); i++)
            {
                DateTime curdate = Convert.ToDateTime(strdate).AddDays(-i);
                CollectData(curdate, strtime,21,2);
            }
        }

        private void IntervalCollect()
        {
            string starttime = txtstart.Text.Trim();
            DateTime timepart = Convert.ToDateTime(starttime);
            strdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            //for (int i = 0; i < 335; i=i+5) //5分钟
            for (int i = 0; i < 355; i = i + 3)
                {
                DateTime curtime = timepart.AddMinutes(i);
                if ((DateTime.Compare(Convert.ToDateTime(txtend.Text.Trim()), Convert.ToDateTime("11:32:00")) < 0))
                   {
                    //if  (((DateTime.Compare(curtime, Convert.ToDateTime("09:30:00")) > 0) && ((DateTime.Compare(curtime, Convert.ToDateTime(txtend.Text.Trim())) < 0))) || ((DateTime.Compare(curtime, Convert.ToDateTime(txtend.Text.Trim())) < 0) && ((DateTime.Compare(curtime, Convert.ToDateTime("13:00:00")) > 0))))
                    if ((DateTime.Compare(curtime, Convert.ToDateTime("09:30:00")) > 0) && ((DateTime.Compare(curtime, Convert.ToDateTime(txtend.Text.Trim())) < 0)))
                    {
                        string time2 = curtime.ToShortTimeString().ToString();
                        string time1 = curtime.AddMinutes(-3).ToShortTimeString().ToString();
                        string strtime= time1 + "到" + time2 + "资金流向";
                        CollectData(dateTimePicker1.Value, strtime, 21, 1);
                     }
                    }
                 else if ((DateTime.Compare(Convert.ToDateTime(txtend.Text.Trim()), Convert.ToDateTime("13:05:00")) > 0))
                {
                    if (((DateTime.Compare(curtime, Convert.ToDateTime("09:30:00")) > 0) && ((DateTime.Compare(curtime, Convert.ToDateTime("11:31:00")) < 0))) || ((DateTime.Compare(curtime, Convert.ToDateTime(txtend.Text.Trim())) < 0) && ((DateTime.Compare(curtime, Convert.ToDateTime("13:00:00")) > 0))))
                    {
                        string time2 = curtime.ToShortTimeString().ToString();
                        string time1 = curtime.AddMinutes(-3).ToShortTimeString().ToString();
                        string strtime = time1 + "到" + time2 + "资金流向";
                        // CollectData(dateTimePicker1.Value, strtime, 19, 1); //5分钟频率
                        CollectData(dateTimePicker1.Value, strtime, 21, 1); //3分钟频率
                    }
                }
        }
        }
        private void CollectData(DateTime argdate, string argtime,int recordnum, int oprtype)
        {


            //IWebDriver driver = new FirefoxDriver();
            //INavigation navigation = driver.Navigate();
            //navigation.GoToUrl("http://www.dingniugu.com/ddetop.php");
            //Thread.Sleep(6000);
            //driver.Manage().Window.Maximize();
            //Thread.Sleep(1000);
            //strdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement Txtinput = wait.Until<IWebElement>(d => d.FindElement(By.Id("auto")));
            Txtinput.Clear();
            Txtinput.SendKeys(argdate.ToShortDateString() +"日"+ " "+ argtime);

            driver.FindElement(By.Id("qs-enter")).Click();
            Thread.Sleep(4500);

            IWebElement Spannum = wait.Until<IWebElement>(d => d.FindElement(By.ClassName("num")));
            //DateTime inputdate = Convert.ToDateTime(strdate);
            int nums = Convert.ToInt32(Spannum.Text.Trim());
            if (nums <= 0) //(DateTime.Compare(ConvertcellDate, inputdate)<0)
            {
                OutLog(System.DateTime.Now.ToString() + "  当日查询记录为0，跳出不采集。");
                return;
            }

            IWebElement Spandur = wait.Until<IWebElement>(d => d.FindElement(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[1]/div/div/div[1]/ul/li[3]/div[1]/span")));

            string colduration = Spandur.Text;
            string[] Stringcol = Regex.Split(colduration, "\n", RegexOptions.IgnoreCase);
            string strduraction = Stringcol[1].Trim();
            string[] String1 = Regex.Split(strduraction, " ", RegexOptions.IgnoreCase);
            string getcelldate = String1[0].Trim();
            DateTime ConvertcellDate = DateTime.ParseExact(getcelldate, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
            string puredate = argdate.ToShortDateString();

            if (DateTime.Compare(ConvertcellDate, Convert.ToDateTime(puredate)) < 0) //(DateTime.Compare(ConvertcellDate, inputdate)<0)
            { 
                OutLog(System.DateTime.Now.ToString() + "  输入日期" + strdate + "大于数据日期" + getcelldate + "当天为，跳出不采集。");
                return;
            }
            string[] String2 = Regex.Split(strduraction, " ", RegexOptions.IgnoreCase);
            string strtime = String2[2].Trim();

            //double dbnet = Getvalue(driver.FindElement(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[1]/div/div/div[2]/table/tbody/tr[1]/td[3]/div")).Text);
            //double dbin = Getvalue(driver.FindElement(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[1]/div/div/div[2]/table/tbody/tr[1]/td[4]/div")).Text);
            //double dbout = Getvalue(driver.FindElement(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[1]/div/div/div[2]/table/tbody/tr[1]/td[5]/div")).Text);

            //MessageBox.Show(strduraction);
            //MessageBox.Show(Convert.ToString(rows.Count()));

            //string connString = "SERVER=.;DATABASE=CapitalFlow;UID=sa;PWD=115656";
            string connString = "Data Source = ." + "\\" + "SQLExpress;Initial Catalog = CapitalFlow;User Id = sa;Password = 115656;";

            //生成DataTable表
            DataTable dt = new DataTable();
            dt.Columns.Add("stockid");
            dt.Columns.Add("stockname");
            dt.Columns.Add("price");
            dt.Columns.Add("increasePCT");
            dt.Columns.Add("netvalue");
            dt.Columns.Add("outvalue");
            dt.Columns.Add("invalue");
            dt.Columns.Add("duration");
            dt.Columns.Add("datadate");
            dt.Columns.Add("datatime");
            dt.Columns.Add("systime");
            dt.Columns.Add("oprtype");

            IList<IWebElement> rows = driver.FindElements(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[2]/div/table/tbody/tr"));

            int countrows = (rows.Count() > recordnum) ? recordnum : rows.Count() + 1;

            for (int i = 1; i < countrows; i++)
            {
                //MessageBox.Show(driver.FindElement(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[2]/div/table/tbody/tr[" + j + "]/td[4]/div/a")).Text);


                DataRow row = dt.NewRow();
                row["stockid"] = (wait.Until<IWebElement>(d => d.FindElement(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[2]/div/table/tbody/tr[" + i + "]/td[3]/div")))).Text;
                row["stockname"] = (wait.Until<IWebElement>(d => d.FindElement(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[2]/div/table/tbody/tr[" + i + "]/td[4]/div/a")))).Text;
                string strprice = (wait.Until<IWebElement>(d => d.FindElement(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[1]/div/div/div[2]/table/tbody/tr[" + i + "]/td[1]/div")))).Text.Trim();
                double dbi = 0.0;
                double dbj = 0.0;
                row["price"] = (Double.TryParse(strprice, out dbi)) ? dbi : 0;
                string strPCT = (wait.Until<IWebElement>(d => d.FindElement(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[1]/div/div/div[2]/table/tbody/tr[" + i + "]/td[2]/div")))).Text.Trim();
                row["increasePCT"] = (Double.TryParse(strPCT, out dbj)) ? dbj : 0;
                row["netvalue"] = Getvalue((wait.Until<IWebElement>(d => d.FindElement(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[1]/div/div/div[2]/table/tbody/tr[" + i + "]/td[3]/div")))).Text.Trim());
                row["outvalue"] = Getvalue((wait.Until<IWebElement>(d => d.FindElement(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[1]/div/div/div[2]/table/tbody/tr[" + i + "]/td[4]/div")))).Text.Trim());
                row["invalue"] = Getvalue((wait.Until<IWebElement>(d => d.FindElement(By.XPath(".//*[@id='tableWrap']/div[2]/div/div[1]/div/div/div[2]/table/tbody/tr[" + i + "]/td[5]/div")))).Text.Trim());
                row["duration"] = "temp";
                row["datadate"] = argdate;
                row["datatime"] = strtime;
                row["systime"] = System.DateTime.Now; //.ToLongTimeString().ToString()
                row["oprtype"] = oprtype;
                dt.Rows.Add(row);


            }

            SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(connString, SqlBulkCopyOptions.UseInternalTransaction);
            sqlbulkcopy.DestinationTableName = "tbl_CapitalFlow"; //目标表，即数据要插入到哪个表去
            sqlbulkcopy.ColumnMappings.Add("stockid", "stockid"); //数据源列名与目标表的属性的映射关系   数据源是DataTable，目标表即数据库表
            sqlbulkcopy.ColumnMappings.Add("stockname", "stockname");
            sqlbulkcopy.ColumnMappings.Add("price", "price");
            sqlbulkcopy.ColumnMappings.Add("increasePCT", "increasePCT");
            sqlbulkcopy.ColumnMappings.Add("netvalue", "netvalue");
            sqlbulkcopy.ColumnMappings.Add("outvalue", "outvalue");
            sqlbulkcopy.ColumnMappings.Add("invalue", "invalue");
            sqlbulkcopy.ColumnMappings.Add("duration", "duration");
            sqlbulkcopy.ColumnMappings.Add("datadate", "datadate");
            sqlbulkcopy.ColumnMappings.Add("datatime", "datatime");
            sqlbulkcopy.ColumnMappings.Add("systime", "systime");
            sqlbulkcopy.ColumnMappings.Add("oprtype", "oprtype");
            sqlbulkcopy.WriteToServer(dt); //数据源数据写入目标表
            OutLog(System.DateTime.Now.ToString() + "  " + argdate.ToShortDateString() + " " + argtime + "数据采集完毕");

        }
        private static double Getvalue(string strcell)
        {

            if (strcell.Contains("万"))
            {
                string[] Stringc = Regex.Split(strcell, "万", RegexOptions.IgnoreCase);
                return double.Parse(Stringc[0].Trim());
            }
            else if (strcell.Contains("亿"))
            {
                string[] Stringc = Regex.Split(strcell, "亿", RegexOptions.IgnoreCase);
                return double.Parse(Stringc[0].Trim()) * 10000;
            }
            else
                return 0;
        }
        private void OutLog(string s)
        {
            txtinfo.AppendText(s + Environment.NewLine);
            txtinfo.ScrollToCaret();
        }
        public bool IsNumeric(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i]))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            radio2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            driver = new FirefoxDriver();
            INavigation navigation = driver.Navigate();
            navigation.GoToUrl("http://www.iwencai.com/stockpick/search?typed=1&preParams=&ts=1&f=1&qs=index_rewrite&selfsectsn=&querytype=&searchfilter=&tid=stockpick&w=macd");
            Thread.Sleep(4000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(600);
            if (radio1.Checked)
            {
                LoopCollect();
            }
            else if (radio2.Checked)
            {
                IntervalCollect();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str1= (IsNumeric("19.5")) ? "真" : "假";
            MessageBox.Show(str1);
        }
    }
}
