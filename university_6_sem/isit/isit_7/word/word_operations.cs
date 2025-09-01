using isit_7.storage;
using isit_7.stored_procedures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace isit_7.word
{
    public class TWordModel
    {
        public TWordModel(IUniversityRepository universityRepository)
        {
            mUniversityRepository = universityRepository ?? throw new ArgumentNullException(nameof(universityRepository));
        }

        public System.Data.DataTable GetExcellentStudentsOnly() => mUniversityRepository.GetExcellentStudentsOnly();

        protected readonly IUniversityRepository mUniversityRepository;
    }

    public class TWordTabPage : TabPage
    {
        public TWordTabPage()
        {
            Text = "Операции с word";

            mButtonExportExcellentStudents = new Button
            {
                Dock = DockStyle.Top,
                Text = "Вывести всех отличников"
            };

            Controls.Add(mButtonExportExcellentStudents);
        }

        public Button ButtonExportExcellentStudents => mButtonExportExcellentStudents;

        protected readonly Button mButtonExportExcellentStudents;
    }

    public class TWordController
    {
        public TWordController(TWordModel model, TWordTabPage view)
        {
            mModel = model ?? throw new ArgumentNullException(nameof(model));
            mView = view ?? throw new ArgumentNullException(nameof(view));

            Initialize();
        }

        protected void Initialize()
        {
            mView.ButtonExportExcellentStudents.Click += OnExportExcellentStudentsClicked;
        }

        protected void OnExportExcellentStudentsClicked(object sender, EventArgs e)
        {
            System.Data.DataTable studentsTable = mModel.GetExcellentStudentsOnly();
            MessageBox.Show("Отличники записаны в файл", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;
            Document wordDoc = wordApp.Documents.Add();

            Paragraph title = wordDoc.Paragraphs.Add();
            title.Range.Text = "Список отличников";
            title.Range.Font.Bold = 1;
            title.Range.Font.Size = 16;
            title.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            title.Range.InsertParagraphAfter();

            int rows = studentsTable.Rows.Count + 1; // +1 для заголовков
            int columns = studentsTable.Columns.Count;

            Table wordTable = wordDoc.Tables.Add(
                wordDoc.Range(wordDoc.Content.End - 1, wordDoc.Content.End),
                rows,
                columns
            );

            wordTable.Borders.Enable = 1;

            for (int i = 0; i < columns; i++)
            {
                wordTable.Cell(1, i + 1).Range.Text = studentsTable.Columns[i].ColumnName;
                wordTable.Cell(1, i + 1).Range.Font.Bold = 1;
                wordTable.Cell(1, i + 1).Range.Font.Size = 12;
            }

            for (int row = 0; row < studentsTable.Rows.Count; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    object value = studentsTable.Rows[row][col];
                    wordTable.Cell(row + 2, col + 1).Range.Text = value?.ToString() ?? "";
                    wordTable.Cell(row + 2, col + 1).Range.Font.Bold = 0;
                    wordTable.Cell(row + 2, col + 1).Range.Font.Size = 12;
                }
            }

            wordTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);

            string fileName = $"Отличники_{DateTime.Now:yyyyMMdd_HHmmss}.docx";
            wordDoc.SaveAs2(fileName);
        }

        protected readonly TWordModel mModel;
        protected readonly TWordTabPage mView;
    }
}
