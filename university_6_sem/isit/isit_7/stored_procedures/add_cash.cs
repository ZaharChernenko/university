using isit_7.storage;
using System;
using System.Data;
using System.Windows.Forms;

namespace isit_7.stored_procedures
{
    public class TAddCashModel
    {
        public TAddCashModel(IUniversityRepository universityRepository)
        {
            mUniversityRepository = universityRepository ?? throw new ArgumentNullException(nameof(universityRepository));
        }

        public DataTable GetStudentData() => mUniversityRepository.GetStudentData();
        public void AddCash() => mUniversityRepository.AddCash();

        protected readonly IUniversityRepository mUniversityRepository;
    }

    public class TAddCashTabPage : TabPage
    {
        protected readonly DataGridView mDataGridViewStudents;
        protected readonly Button mButtonAddCash;

        public TAddCashTabPage()
        {
            Text = "Увеличение стипендии всем студентам";

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

            mButtonAddCash = new Button
            {
                Dock = DockStyle.Top,
                Text = "Увеличить стипендию"
            };

            Controls.Add(mButtonAddCash);
            Controls.Add(mDataGridViewStudents);
        }

        public Button AddCashButton => mButtonAddCash;

        public void BindStudentsData(DataTable data)
        {
            mDataGridViewStudents.DataSource = data;
        }
    }

    public class TAddCashController
    {
        public TAddCashController(TAddCashModel model, TAddCashTabPage view)
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
                mModel.AddCash();
                LoadStudentsData();

                MessageBox.Show($"Стипендия успешно увеличена", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при увеличении стипендии: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected readonly TAddCashModel mModel;
        protected readonly TAddCashTabPage mView;
    }
}