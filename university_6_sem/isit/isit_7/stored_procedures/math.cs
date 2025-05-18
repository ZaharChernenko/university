using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isit_7.stored_procedures
{
    using global::isit_7.storage;
    using System;
    using System.Windows.Forms;

    namespace isit_7.stored_procedures
    {
        public class TMathOperationsModel
        {
            public TMathOperationsModel(IUniversityRepository universityRepository)
            {
                mUniversityRepository = universityRepository ?? throw new ArgumentNullException(nameof(universityRepository));
            }

            public int Factorial(int n) => mUniversityRepository.Factorial(n);
            public int Series(int n) => mUniversityRepository.Series(n);

            protected readonly IUniversityRepository mUniversityRepository;
        }

        public class TMathOperationsTabPage : TabPage
        {
            protected readonly TextBox mTextBoxFactorialInput;
            protected readonly Button mButtonCalculateFactorial;
            protected readonly Label mLabelFactorialResult;

            protected readonly TextBox mTextBoxSeriesN;
            protected readonly Button mButtonCalculateSeries;
            protected readonly Label mLabelSeriesResult;

            public TMathOperationsTabPage()
            {
                Text = "Математические операции";

                var factorialGroup = new GroupBox
                {
                    Text = "Вычисление факториала",
                    Dock = DockStyle.Top,
                    Height = 100
                };

                mTextBoxFactorialInput = new TextBox
                {
                    Dock = DockStyle.Top,
                    Width = 100
                };

                mButtonCalculateFactorial = new Button
                {
                    Dock = DockStyle.Top,
                    Text = "Вычислить факториал"
                };

                mLabelFactorialResult = new Label
                {
                    Dock = DockStyle.Top,
                    Text = "Результат: "
                };

                factorialGroup.Controls.Add(mLabelFactorialResult);
                factorialGroup.Controls.Add(mButtonCalculateFactorial);
                factorialGroup.Controls.Add(mTextBoxFactorialInput);

                var seriesGroup = new GroupBox
                {
                    Text = "Вычисление суммы ряда",
                    Dock = DockStyle.Top,
                    Height = 150
                };

                var labelN = new Label { Text = "n:", Dock = DockStyle.Top };
                mTextBoxSeriesN = new TextBox { Dock = DockStyle.Top, Width = 100 };

                mButtonCalculateSeries = new Button
                {
                    Dock = DockStyle.Top,
                    Text = "Вычислить сумму ряда"
                };

                mLabelSeriesResult = new Label
                {
                    Dock = DockStyle.Top,
                    Text = "Результат: "
                };

                seriesGroup.Controls.Add(mLabelSeriesResult);
                seriesGroup.Controls.Add(mButtonCalculateSeries);
                seriesGroup.Controls.Add(mTextBoxSeriesN);
                seriesGroup.Controls.Add(labelN);

                Controls.Add(seriesGroup);
                Controls.Add(factorialGroup);
            }

            public Button FactorialButton => mButtonCalculateFactorial;
            public Button SeriesButton => mButtonCalculateSeries;

            public string FactorialInput => mTextBoxFactorialInput.Text;
            public string SeriesNInput => mTextBoxSeriesN.Text;

            public void SetFactorialResult(long result)
            {
                mLabelFactorialResult.Text = $"Результат: {result}";
            }

            public void SetSeriesResult(double result)
            {
                mLabelSeriesResult.Text = $"Результат: {result}";
            }

            public void ShowError(string message)
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class TMathOperationsController
        {
            public TMathOperationsController(TMathOperationsModel model, TMathOperationsTabPage view)
            {
                mModel = model ?? throw new ArgumentNullException(nameof(model));
                mView = view ?? throw new ArgumentNullException(nameof(view));

                Initialize();
            }

            private void Initialize()
            {
                mView.FactorialButton.Click += OnCalculateFactorialClicked;
                mView.SeriesButton.Click += OnCalculateSeriesClicked;
            }

            private void OnCalculateFactorialClicked(object sender, EventArgs e)
            {
                try
                {
                    if (int.TryParse(mView.FactorialInput, out int n))
                    {
                        var result = mModel.Factorial(n);
                        mView.SetFactorialResult(result);
                    }
                    else
                    {
                        mView.ShowError("Пожалуйста, введите целое число для вычисления факториала");
                    }
                }
                catch (Exception ex)
                {
                    mView.ShowError(ex.Message);
                }
            }

            private void OnCalculateSeriesClicked(object sender, EventArgs e)
            {
                try
                {
                    if (int.TryParse(mView.SeriesNInput, out int n))
                    {
                        var result = mModel.Series(n);
                        mView.SetSeriesResult(result);
                    }
                    else
                    {
                        mView.ShowError("Пожалуйста, введите целое число для суммы ряда");
                    }
                }
                catch (Exception ex)
                {
                    mView.ShowError(ex.Message);
                }
            }

            protected readonly TMathOperationsModel mModel;
            protected readonly TMathOperationsTabPage mView;
        }
    }
}
