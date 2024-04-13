﻿namespace trainTicketApp.DTOs
{
    public class CourseAddDTO
    {
        public string ArrivingCity { get; set; }

        public string LeavingCity { get; set; }

        public DateTime ArivingTime { get; set; }

        public DateTime LeavingTime { get; set; }
        public Guid TrainId { get; set; }
        public Guid PlatformId { get; set; }
    }
}
