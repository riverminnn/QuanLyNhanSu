using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms.Admin
{
    public partial class ReportManagement : Form
    {
        static string stringConnect = "Data Source=DESKTOP-ON61FFC;Initial Catalog=QLNS;Integrated Security=True;";

        public ReportManagement()
        {
            InitializeComponent();
        }

        public void ShowReport(string filterReport, string tableName, string reportName, string reportWriter, string employeeID = null)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(stringConnect))
                {
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandText = tableName;
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add the @sMaNV parameter if an employee ID was provided
                        if (!string.IsNullOrEmpty(employeeID))
                        {
                            cmd.Parameters.AddWithValue("@sMaNV", employeeID);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.SelectCommand = cmd;
                            using (DataTable table = new DataTable())
                            {
                                adapter.Fill(table);
                                ReportDocument reportDocument = new ReportDocument();
                                string path = string.Format("{0}\\Reports\\{1}.rpt", Application.StartupPath, reportName);

                                reportDocument.Load(path);
                                reportDocument.Database.Tables[tableName].SetDataSource(table);
                                reportDocument.SetParameterValue("ReportWriter", reportWriter);
                                // Apply filter condition
                                reportDocument.RecordSelectionFormula = filterReport;

                                // Set the report source
                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
