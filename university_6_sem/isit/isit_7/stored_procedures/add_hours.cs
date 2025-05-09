using System;
using System.Data;
using System.Windows.Forms;

using isit_7.storage;

namespace isit_7.stored_procedures
{
    public class TAddHoursModel
    {
        protected readonly IExamStorage m_exam_storage;

        public TAddHoursModel(IExamStorage exam_storage)
        {
            m_exam_storage = exam_storage ?? throw new ArgumentNullException(nameof(exam_storage));
        }

        public DataTable GetExamsData()
        {
            return m_exam_storage.GetExamsData();
        }

        public void AddHours(in string exam, int hours)
        {
            m_exam_storage.AddHours(exam, hours);
        }

    }

    public class TAddHoursView : UserControl
    {
        private readonly DataGridView dataGridViewExams;
        private readonly TextBox textBoxExam;
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

            textBoxExam = new TextBox
            {
                Dock = DockStyle.Top,
                Text = "Название экзамена"
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
            Controls.Add(textBoxExam);
            Controls.Add(dataGridViewExams);
        }

        // Свойства для доступа к элементам управления
        public DataGridView ExamsGridView => dataGridViewExams;
        public string ExamName => textBoxExam.Text;
        public int Hours => (int)numericUpDownHours.Value;
        public Button AddHoursButton => buttonAddHours;

        // Метод для привязки данных
        public void BindExamsData(DataTable data)
        {
            dataGridViewExams.DataSource = data;
        }

        // Метод для очистки полей
        public void ClearInputs()
        {
            textBoxExam.Text = string.Empty;
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
            LoadExamsData();

            // Подписка на события
            _view.AddHoursButton.Click += OnAddHoursClicked;
        }

        private void LoadExamsData()
        {
            try
            {
                var examsData = _model.GetExamsData(); // Замените "Exams" на вашу таблицу
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
                if (string.IsNullOrWhiteSpace(_view.ExamName))
                {
                    MessageBox.Show("Введите название экзамена", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _model.AddHours(_view.ExamName, _view.Hours);
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
}
