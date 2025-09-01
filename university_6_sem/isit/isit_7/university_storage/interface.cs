using System.Data;

namespace isit_7.storage
{

    public interface IUniversityRepository
    {
        void AddHours(in string exam, int hours);

        void AddCash();
        void AddCashWhereEqualTo(int equalTo, int addAmount);
        void AddCashWhere5(int addAmount);
        void AddCashWhereGreater(int bound);
        DataTable GetExamData();

        DataTable GetStudentData();
        DataTable GetExamWithDisciplineNamesData();
        string[] GetDisciplineNames();

        int GetAverageHours();

        int Factorial(int n);
        int Series(int n);

        DataTable GetExcellentStudentsOnly();
    }
}
