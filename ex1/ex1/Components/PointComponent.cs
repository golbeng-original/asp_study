using System;
using System.ComponentModel.DataAnnotations;

namespace ex1.Components
{
    public class PointComponent
    {
        public PointComponent()
        {

        }
    }


    // model
    public class Point
    {
        public int id { get; set; }

        [Required]
        public int userId { get; set; }

        [Required]
        public string userName { get; set; }
        public int totalPoint { get; set; }
    }


    // model
    public class PointLog
    {
        public int id { get; set; }

        [Required]
        public int userId { get; set; }
        [Required]
        public string userName { get; set; }

        public int newPoint { get; set; }
        public DateTime created { get; set; }
    }

    public class PointStatus
    {
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Bronze { get; set; }
    }

    // repository
    public interface IPointRepository
    {
        int GetTotalPointByUserId(int userId);
        PointStatus GetPointStatusByUser();
    }

    public class PointRepository : IPointRepository
    {
        public int GetTotalPointByUserId(int userId)
        {
            return 1234;
        }

        public PointStatus GetPointStatusByUser()
        {
            throw new NotImplementedException();
        }
    }

    public class PointRepositoryInMemory : IPointRepository
    {
        public int GetTotalPointByUserId(int userId)
        {
            return 1234;
        }

        public PointStatus GetPointStatusByUser()
        {
            return new PointStatus()
            {
                Gold = 10,
                Silver = 20,
                Bronze = 55
            };
        }
    }

    // repository
    public interface IPointLogRepository
    {

    }

    public class PointLogRepository : IPointLogRepository
    {

    }

}
