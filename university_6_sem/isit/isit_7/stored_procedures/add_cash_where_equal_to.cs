using isit_7.storage;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace isit_7.stored_procedures
{
    public class TAddCashWhereEqualToModel
    {
        public TAddCashWhereEqualToModel(IUniversityRepository universityRepository)
        {
            mUniversityRepository = universityRepository ?? throw new ArgumentNullException(nameof(universityRepository));
        }
        
        public DataTable GetStudentData() => mUniversityRepository.GetStudentData();
        public void AddCashWhereEqualTo(int equalTo, int addAmount) => mUniversityRepository.AddCashWhereEqualTo(equalTo, addAmount);

        protected readonly IUniversityRepository mUniversityRepository;
    }

    public class TAddCashWhereEqualToTabPage : TabPage
    {
        protected readonly DataGridView mDataGridViewStudents;
        protected readonly Label mLabelCashEqualTo, mLabelCashAmount;
        protected readonly NumericUpDown mNumericUpDownCashEqualTo, mNumericUpDownCashAmount;
        protected readonly Button mButtonAddCash;

        public TAddCashWhereEqualToTabPage()
        {
            Text = "Добавление денег студентам с определенной стипендией";

            mDataGridViewStudents = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 200,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            mLabelCashEqualTo = new Label
            {
                Text = "Введите текущую стипендию:",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(0, 5, 0, 5)
            };
            mNumericUpDownCashEqualTo = new NumericUpDown
            {
                Dock = DockStyle.Top,
                Minimum = int.MinValue,
                Maximum = int.MaxValue,
                Value = 0,
                TextAlign = HorizontalAlignment.Right,
            };

            mLabelCashAmount = new Label
            {
                Text = "Введите надбавку:",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(0, 5, 0, 5)
            };
            mNumericUpDownCashAmount = new NumericUpDown
            {
                Dock = DockStyle.Top,
                Minimum = int.MinValue,
                Maximum = int.MaxValue,
                Value = 0,
                TextAlign = HorizontalAlignment.Right,
            };

            mButtonAddCash = new Button
            {
                Dock = DockStyle.Top,
                Text = "Добавить деньги"
            };

            Controls.Add(mButtonAddCash);
            Controls.Add(mNumericUpDownCashAmount);
            Controls.Add(mLabelCashAmount);
            Controls.Add(mNumericUpDownCashEqualTo);
            Controls.Add(mLabelCashEqualTo);
            Controls.Add(mDataGridViewStudents);
        }

        public decimal GetCashEqualTo => mNumericUpDownCashEqualTo.Value;
        public decimal GetCashAmount => mNumericUpDownCashAmount.Value;
        public Button AddCashButton => mButtonAddCash;

        public void BindStudentsData(DataTable data)
        {
            mDataGridViewStudents.DataSource = data;
        }

        public void ClearInputs()
        {
            mNumericUpDownCashEqualTo.Value = 0;
            mNumericUpDownCashAmount.Value = 0;
        }
    }

    public class TAddCashWhereEqualToController
    {
        public TAddCashWhereEqualToController(TAddCashWhereEqualToModel model, TAddCashWhereEqualToTabPage view)
        {
            mModel = model ?? throw new ArgumentNullException(nameof(model));
            mView = view ?? throw new ArgumentNullException(nameof(view));

            Initialize();
        }

        private void Initialize()
        {
            LoadStudentsData();
            mView.AddCashButton.Click += OnAddCashClicked;
        }

        private void LoadStudentsData()
        {
            try
            {
                var studentData = mModel.GetStudentData();
                mView.BindStudentsData(studentData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных студентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnAddCashClicked(object sender, EventArgs e)
        {
            try
            {
                if (mView.GetCashAmount <= 0)
                {
                    MessageBox.Show("Сумма должна быть положительной", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                mModel.AddCashWhereEqualTo((int)mView.GetCashEqualTo, (int)mView.GetCashAmount);
                mView.ClearInputs();
                LoadStudentsData();

                MessageBox.Show("Деньги успешно добавлены", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении денег: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected readonly TAddCashWhereEqualToModel mModel;
        protected readonly TAddCashWhereEqualToTabPage mView;
    }
}
