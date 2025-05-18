using System.Data;

namespace isit_7.storage
{

    public interface IUniversityRepository
    {
        void AddHours(in string exam, int hours);

        void AddCash();
        void AddCashWhereEqualTo(int equalTo, int addAmount);
        DataTable GetExamData();

        DataTable GetStudentData();
        DataTable GetExamWithDisciplineNamesData();
        string[] GetDisciplineNames();

    }
}
