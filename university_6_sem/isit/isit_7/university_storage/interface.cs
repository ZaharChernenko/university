using System.Data;

namespace isit_7.storage
{
    public interface IExamStorage
    {
        void AddHours(in string exam, int hours);
        DataTable GetExamsData();
    }
}
