using isit_7.storage;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace isit_7.stored_procedures
{
    public class TAddCashWhere5Model
    {
        public TAddCashWhere5Model(IUniversityRepository universityRepository)
        {
            mUniversityRepository = universityRepository ?? throw new ArgumentNullException(nameof(universityRepository));
        }

        public DataTable GetStudentData() => mUniversityRepository.GetStudentData();
        public void AddCashWhere5(int addAmount) => mUniversityRepository.AddCashWhere5(addAmount);

        protected readonly IUniversityRepository mUniversityRepository;
    }

    public class TAddCashWhere5TabPage : TabPage
    {
        protected readonly DataGridView mDataGridViewStudents;
        protected readonly Label mLabelCashAmount;
        protected readonly NumericUpDown mNumericUpDownCashAmount;
        protected readonly Button mButtonAddCash;

        public TAddCashWhere5TabPage()
        {
            Text = "Повышение стипендии для отличников";

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

            mLabelCashAmount = new Label
            {
                Text = "Введите размер надбавки:",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(0, 5, 0, 5)
            };
            mNumericUpDownCashAmount = new NumericUpDown
            {
                Dock = DockStyle.Top,
                Minimum = 0,
                Maximum = int.MaxValue,
                Value = 0,
                TextAlign = HorizontalAlignment.Right,
            };

            mButtonAddCash = new Button
            {
                Dock = DockStyle.Top,
                Text = "Добавить надбавку"
            };

            Controls.Add(mButtonAddCash);
            Controls.Add(mNumericUpDownCashAmount);
            Controls.Add(mLabelCashAmount);
            Controls.Add(mDataGridViewStudents);
        }

        public decimal GetCashAmount => mNumericUpDownCashAmount.Value;
        public Button AddCashButton => mButtonAddCash;

        public void BindStudentsData(DataTable data)
        {
            mDataGridViewStudents.DataSource = data;
        }

        public void ClearInputs()
        {
            mNumericUpDownCashAmount.Value = 0;
        }
    }

    public class TAddCashWhere5Controller
    {
        public TAddCashWhere5Controller(TAddCashWhere5Model model, TAddCashWhere5TabPage view)
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

                mModel.AddCashWhere5((int)mView.GetCashAmount);
                mView.ClearInputs();
                LoadStudentsData();

                MessageBox.Show("Надбавка успешно добавлена отличникам", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении надбавки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected readonly TAddCashWhere5Model mModel;
        protected readonly TAddCashWhere5TabPage mView;
    }
}