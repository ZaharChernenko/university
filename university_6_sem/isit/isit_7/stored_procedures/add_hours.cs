using System;
using System.Data;
using System.Windows.Forms;

using isit_7.storage;

namespace isit_7.stored_procedures
{
    /*
    public class TAddHoursModel
    {
        public TAddHoursModel(IDisciplineStorage discipline_storage, IExamStorage exam_storage)
        {
            m_discipline_storage = discipline_storage ?? throw new ArgumentNullException(nameof(discipline_storage));
            m_exam_storage = exam_storage ?? throw new ArgumentNullException(nameof(exam_storage));
        }

        public DataTable GetExamData() => m_exam_storage.GetExamData();
        public void AddHours(in string exam, int hours) => m_exam_storage.AddHours(exam, hours);
        public string[] GetDisciplineNames() => m_discipline_storage.GetDisciplineNames();


        protected readonly IDisciplineStorage m_discipline_storage;
        protected readonly IExamStorage m_exam_storage;
    }

    public class TAddHoursView : UserControl
    {
        private readonly DataGridView dataGridViewExams;
        private readonly ComboBox comboBoxDisciplines; // Заменяем TextBox на ComboBox
        private readonly NumericUpDown numericUpDownHours;
        private readonly Button buttonAddHours;

        public TAddHoursView()
        {
            // Инициализация компонентов
            dataGridViewExams = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 200,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            comboBoxDisciplines = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList // Делаем выпадающий список нередактируемым
            };

            numericUpDownHours = new NumericUpDown
            {
                Dock = DockStyle.Top,
                Minimum = 1,
                Maximum = 100,
                Value = 1
            };

            buttonAddHours = new Button
            {
                Dock = DockStyle.Top,
                Text = "Добавить часы"
            };

            // Компоновка элементов
            Controls.Add(buttonAddHours);
            Controls.Add(numericUpDownHours);
            Controls.Add(comboBoxDisciplines);
            Controls.Add(dataGridViewExams);
        }

        // Свойства для доступа к элементам управления
        public DataGridView ExamsGridView => dataGridViewExams;
        public string SelectedDiscipline => comboBoxDisciplines.SelectedItem?.ToString();
        public int Hours => (int)numericUpDownHours.Value;
        public Button AddHoursButton => buttonAddHours;

        // Метод для загрузки дисциплин в выпадающий список
        public void LoadDisciplines(string[] disciplines)
        {
            comboBoxDisciplines.Items.Clear();
            comboBoxDisciplines.Items.AddRange(disciplines);

            if (comboBoxDisciplines.Items.Count > 0)
                comboBoxDisciplines.SelectedIndex = 0;
        }

        // Метод для привязки данных
        public void BindExamsData(DataTable data)
        {
            dataGridViewExams.DataSource = data;
        }

        // Метод для очистки полей
        public void ClearInputs()
        {
            if (comboBoxDisciplines.Items.Count > 0)
                comboBoxDisciplines.SelectedIndex = 0;
            numericUpDownHours.Value = numericUpDownHours.Minimum;
        }
    }

    public class TAddHoursController
    {
        private readonly TAddHoursModel _model;
        private readonly TAddHoursView _view;

        public TAddHoursController(TAddHoursModel model, TAddHoursView view)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));

            Initialize();
        }

        private void Initialize()
        {
            // Загрузка данных при инициализации
            LoadDisciplines();
            LoadExamsData();

            // Подписка на события
            _view.AddHoursButton.Click += OnAddHoursClicked;
        }

        private void LoadDisciplines()
        {
            try
            {
                var disciplines = _model.GetDisciplineNames();
                _view.LoadDisciplines(disciplines);
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
                var examsData = _model.GetExamData();
                _view.BindExamsData(examsData);
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
                if (string.IsNullOrWhiteSpace(_view.SelectedDiscipline))
                {
                    MessageBox.Show("Выберите дисциплину из списка", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _model.AddHours(_view.SelectedDiscipline, _view.Hours);
                _view.ClearInputs();
                LoadExamsData(); // Обновляем данные после добавления

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
    */
}
