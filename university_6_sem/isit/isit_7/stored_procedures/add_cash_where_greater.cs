using isit_7.storage;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace isit_7.stored_procedures
{
    public class TAddCashWhereGreaterModel
    {
        public TAddCashWhereGreaterModel(IUniversityRepository universityRepository)
        {
            mUniversityRepository = universityRepository ?? throw new ArgumentNullException(nameof(universityRepository));
        }

        public DataTable GetStudentData() => mUniversityRepository.GetStudentData();
        public void AddCashWhereHoursGreater(int bound) => mUniversityRepository.AddCashWhereGreater(bound);
        public int GetAverageHours() => mUniversityRepository.GetAverageHours();

        protected readonly IUniversityRepository mUniversityRepository;
    }

    public class TAddCashWhereGreaterTabPage : TabPage
    {
        protected readonly DataGridView mDataGridViewStudents;
        protected readonly Label mLabelAverageHours;
        protected readonly Label mLabelBound;
        protected readonly NumericUpDown mNumericUpDownBound;
        protected readonly Button mButtonAddCash;

        public TAddCashWhereGreaterTabPage()
        {
            Text = "Надбавка при превышении границы среднего количества часов";

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

            mLabelAverageHours = new Label
            {
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(0, 5, 0, 5),
            };

            mLabelBound = new Label
            {
                Text = "Введите верхний порог количества часов:",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(0, 5, 0, 5)
            };
            mNumericUpDownBound = new NumericUpDown
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
            Controls.Add(mNumericUpDownBound);
            Controls.Add(mLabelBound);
            Controls.Add(mLabelAverageHours);
            Controls.Add(mDataGridViewStudents);
        }

        public decimal GetHoursBound => mNumericUpDownBound.Value;
        public Button AddCashButton => mButtonAddCash;

        public void BindStudentsData(DataTable data)
        {
            mDataGridViewStudents.DataSource = data;
        }

        public void SetAverageHours(int averageHours)
        {
            mLabelAverageHours.Text = $"Среднее количество часов по предметам: {averageHours:F2}";
        }

        public void ClearInputs()
        {
            mNumericUpDownBound.Value = 0;
        }
    }

    public class TAddCashWhereGreaterController
    {
        public TAddCashWhereGreaterController(TAddCashWhereGreaterModel model, TAddCashWhereGreaterTabPage view)
        {
            mModel = model ?? throw new ArgumentNullException(nameof(model));
            mView = view ?? throw new ArgumentNullException(nameof(view));

            Initialize();
        }

        private void Initialize()
        {
            LoadStudentsData();
            LoadAverageHours();
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

        private void LoadAverageHours()
        {
            try
            {
                var averageHours = mModel.GetAverageHours();
                mView.SetAverageHours(averageHours);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки среднего количества часов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnAddCashClicked(object sender, EventArgs e)
        {
            try
            {
                if (mView.GetHoursBound <= 0)
                {
                    MessageBox.Show("Порог часов должен быть положительным", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                mModel.AddCashWhereHoursGreater((int)mView.GetHoursBound);
                mView.ClearInputs();
                LoadStudentsData();
                LoadAverageHours();

                MessageBox.Show("Операция успешно добавлена", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении надбавки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected readonly TAddCashWhereGreaterModel mModel;
        protected readonly TAddCashWhereGreaterTabPage mView;
    }
}