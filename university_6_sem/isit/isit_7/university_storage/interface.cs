using System.Data;

namespace isit_7.storage
{

    public interface IUniversityRepository
    {
        void AddHours(in string exam, int hours);
        DataTable GetExamData();
        string[] GetDisciplineNames();

    }
}
