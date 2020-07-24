using System;
using System.Windows.Forms;

namespace WinformLocalDbSample
{
    public partial class Form1 : Form
    {
        private readonly TestService _testService;

        public Form1()
        {
            _testService = new TestService(new TestRepository());

            InitializeComponent();

            listBox.DisplayMember = nameof(TestDTO.Id);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTestDtosToListBox();
        }

        private void LoadTestDtosToListBox()
        {
            var testDTOs = _testService.Get();
            listBox.DataSource = testDTOs;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var testDTO = new TestDTO
                          {
                              Id   = Int32.Parse(tbxId.Text),
                              Name = tbxName.Text
                          };
            _testService.Add(testDTO);

            LoadTestDtosToListBox();
        }
    }
}
