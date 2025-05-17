using System;
using System.Data;
using System.Windows.Forms;

using isit_7.storage;

namespace isit_7.stored_procedures
{
    public class TAddHoursModel
    {
        public TAddHoursModel(IUniversityRepository universityRepository)
        {
            mUniversityRepository = universityRepository ?? throw new ArgumentNullException(nameof(universityRepository));
        }

        public DataTable GetExamWithDisciplineNamesData() => mUniversityRepository.GetExamWithDisciplineNamesData();
        public void AddHours(in string exam, int hours) => mUniversityRepository.AddHours(exam, hours);
        public string[] GetDisciplineNames() => mUniversityRepository.GetDisciplineNames();


        protected readonly IUniversityRepository mUniversityRepository;
    }

    public class TAddHoursTabPage : TabPage
    {
        protected readonly DataGridView mDataGridViewExams;
        protected readonly ComboBox mComboBoxDisciplines;
        protected readonly NumericUpDown mNumericUpDownHours;
        protected readonly Button mButtonAddHours;

        public TAddHoursTabPage()
        {
            Text = "Добавление часов";

            mDataGridViewExams = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 200,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            mComboBoxDisciplines = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            mNumericUpDownHours = new NumericUpDown
            {
                Dock = DockStyle.Top,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Value = 0
            };

            mButtonAddHours = new Button
            {
                Dock = DockStyle.Top,
                Text = "Добавить часы"
            };

            Controls.Add(mButtonAddHours);
            Controls.Add(mNumericUpDownHours);
            Controls.Add(mComboBoxDisciplines);
            Controls.Add(mDataGridViewExams);
        }
        
        // read-only properties
        public string GetSelectedDiscipline => mComboBoxDisciplines.SelectedItem?.ToString();
        public NumericUpDown GetNumericUpDownHours => mNumericUpDownHours;
        public Button GetButtonAddHours => mButtonAddHours;

        public void LoadDisciplines(string[] disciplines)
        {
            mComboBoxDisciplines.Items.Clear();
            mComboBoxDisciplines.Items.AddRange(disciplines);

            if (mComboBoxDisciplines.Items.Count > 0)
                mComboBoxDisciplines.SelectedIndex = 0;
        }

        public void BindExamsData(DataTable data)
        {
            mDataGridViewExams.DataSource = data;
        }

        public void ClearInputs()
        {
            if (mComboBoxDisciplines.Items.Count > 0)
                mComboBoxDisciplines.SelectedIndex = 0;
            mNumericUpDownHours.Value = 0;
        }
    }

    public class TAddHoursController
    {
        private readonly TAddHoursModel mModel;
        private readonly TAddHoursTabPage mView;

        public TAddHoursController(TAddHoursModel model, TAddHoursTabPage view)
        {
            mModel = model ?? throw new ArgumentNullException(nameof(model));
            mView = view ?? throw new ArgumentNullException(nameof(view));

            Initialize();
        }

        private void Initialize()
        {
            LoadDisciplines();
            LoadExamsData();
            mView.GetButtonAddHours.Click += OnAddHoursClicked;
        }

        private void LoadDisciplines()
        {
            try
            {
                var disciplines = mModel.GetDisciplineNames();
                mView.LoadDisciplines(disciplines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка дисциплин: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExamsData()
        {
            try
            {
                var examsData = mModel.GetExamWithDisciplineNamesData();
                mView.BindExamsData(examsData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnAddHoursClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(mView.GetSelectedDiscipline))
                {
                    MessageBox.Show("Выберите дисциплину из списка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                mModel.AddHours(mView.GetSelectedDiscipline, (int)mView.GetNumericUpDownHours.Value);
                mView.ClearInputs();
                LoadExamsData();

                MessageBox.Show("Часы успешно добавлены", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении часов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
