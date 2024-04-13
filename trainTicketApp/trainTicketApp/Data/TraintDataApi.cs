using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using trainTicketApp.Model;

namespace trainTicketApp.Data
{
    public class TraintDataApi
    {
        public class TrainDbContext : IdentityDbContext
        {
            public DbSet<Profile> User { get; set; } = default!;

            public DbSet<Ticket> Ticket { get; set; } = default!;

            public DbSet<Train> Train { get; set; } = default!;

            public DbSet<Carrige> Carrige { get; set; } = default!;

            public DbSet<Seat> Seat { get; set; } = default!;

            public DbSet<Course> Course { get; set; } = default!;

            public DbSet<TrainPlatforms> TrainPlatforms { get; set; }

            public DbSet<TrainCourse> TrainCourses { get; set; } = default!;
            public TrainDbContext(DbContextOptions<TrainDbContext> options) : base(options) { }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder
                    .Entity<Profile>()
                    .HasKey(r => r.ID);

                modelBuilder
                    .Entity<Ticket>()
                    .HasKey(r => r.TicketID);

                modelBuilder
                    .Entity<TrainPlatforms>()
                    .HasKey(r => r.PlatformID);

                modelBuilder
                    .Entity<Train>()
                    .HasKey(r => r.TrainID); ;

                modelBuilder
                    .Entity<Carrige>()
                    .HasKey(r => r.CarrigeID); ;

                modelBuilder
                    .Entity<Seat>()
                    .HasKey(r => r.SeatID);

                modelBuilder
                    .Entity<Course>()
                    .HasKey(r => r.CourseID);

                modelBuilder
                    .Entity<TrainCourse>()
                    .HasNoKey();

                base.OnModelCreating(modelBuilder);


                Guid Train1 = Guid.Parse("21E9557F-99D2-40B2-B0E1-2BCF97B226D5");
                Guid Train2 = Guid.Parse("006E9D56-99D2-43F2-A231-DB7197CDF6D5");
                Guid Train3 = Guid.Parse("D5FC5911-B45E-4134-ACC0-8A35531FAEE8");



                Train[] trains = new Train[3] {

                    new Train {TrainID = Train1,TrainName ="Model X",TrainType = TrainCategories.Highspeed, NumberOfSeats = 9},
                    new Train { TrainID = Train2, TrainName = "Model Y", TrainType = TrainCategories.Highspeed,  NumberOfSeats = 16 },
                    new Train {TrainID = Train3,TrainName ="Model Z",TrainType = TrainCategories.Highspeed, NumberOfSeats = 8}
                };


                modelBuilder.Entity<Train>().HasData(trains);

                Guid CarrigeID11 = Guid.Parse("525CE5A0-644E-49CB-BC08-E12C5266B8A7");
                Guid CarrigeID12 = Guid.Parse("6AA81F80-1A04-47AB-AC46-150B893526A8");
                Guid CarrigeID13 = Guid.Parse("0BFDF344-31FF-4E75-A389-70315C001833");

                Guid CarrigeID21 = Guid.Parse("150F25F7-6E91-4880-B6DB-C7B60FF6A801");
                Guid CarrigeID22 = Guid.Parse("FED20EAC-3AA0-4A9F-A9B7-B5AF494471D7");
                Guid CarrigeID23 = Guid.Parse("7BF45095-FBA6-47B7-B380-996233626448");
                Guid CarrigeID24 = Guid.Parse("389E75CE-284B-49BB-B093-688FB1983465");

                Guid CarrigeID31 = Guid.Parse("E61C724E-942A-4B85-8E74-D165D64F01EE");
                Guid CarrigeID32 = Guid.Parse("993A0E29-9326-402F-9134-CD153E3DF275");
                Guid CarrigeID33 = Guid.Parse("33A987E8-5767-486A-92BA-D0269009763E");


                Carrige[] carriges = new Carrige[10]
                {
                    new Carrige { CarrigeID = CarrigeID11, Name = "AA1", TrainId = Train1, AvailableSeats = 3 },
                    new Carrige { CarrigeID = CarrigeID12, Name = "AA2", TrainId = Train1, AvailableSeats = 3 },
                    new Carrige { CarrigeID = CarrigeID13, Name = "AA3", TrainId = Train1, AvailableSeats = 3 },

                    new Carrige { CarrigeID = CarrigeID21, Name = "BB1", TrainId = Train2, AvailableSeats = 4 },
                    new Carrige { CarrigeID = CarrigeID22, Name = "BB2", TrainId = Train2, AvailableSeats = 4 },
                    new Carrige { CarrigeID = CarrigeID23, Name = "BB3", TrainId = Train2, AvailableSeats = 4 },
                    new Carrige { CarrigeID = CarrigeID24, Name = "BB4", TrainId = Train2, AvailableSeats = 4 },

                    new Carrige { CarrigeID = CarrigeID31, Name = "CC1", TrainId = Train3, AvailableSeats = 3 },
                    new Carrige { CarrigeID = CarrigeID32, Name = "CC2", TrainId = Train3, AvailableSeats = 3 },
                    new Carrige { CarrigeID = CarrigeID33, Name = "CC3", TrainId = Train3, AvailableSeats = 2 },
                };

                modelBuilder.Entity<Carrige>().HasData(carriges);

                //Train 1
                //Guid SeatIDA1 = Guid.Parse("525CF6A0-644E-33CB-BC08-E12C5266B8A7");
                //Guid SeatIDA2 = Guid.Parse("813A3DB7-F01A-4482-914A-BCE5A4D638BB");
                //Guid SeatIDA3 = Guid.Parse("002BE73C-0C94-4F61-9776-3350E27453C8");

                //Guid SeatIDA4 = Guid.Parse("43165ED7-4812-4659-8901-0F6F70CD5856");
                //Guid SeatIDA5 = Guid.Parse("17D3DD2E-63F1-47DD-9E59-F3E489894954");
                //Guid SeatIDA6 = Guid.Parse("88FB29E9-53AD-490F-BF06-66BF0E7E9A19");

                //Guid SeatIDA7 = Guid.Parse("6DBE5A17-DD43-4299-BD09-0F89B40326D0");
                //Guid SeatIDA8 = Guid.Parse("AD9AA746-05DF-40D4-8880-677D4F026B81");
                //Guid SeatIDA9 = Guid.Parse("9D0F9F2F-3840-4329-93CE-693329BB0BC1");


                ////Train 2
                //Guid SeatIDB1 = Guid.Parse("EA803373-4BD7-4F6D-9511-0C2CA0E2239F");
                //Guid SeatIDB2 = Guid.Parse("0B882CD9-C7F6-4E46-853F-05E966D644BA");
                //Guid SeatIDB3 = Guid.Parse("554321FC-9D5C-47F6-9F79-B3FA70CF08EA");
                //Guid SeatIDB4 = Guid.Parse("DAA7EB6D-6E8E-4AE7-A342-2884861275D0");

                //Guid SeatIDB5 = Guid.Parse("CDB585B4-55BA-4AEA-B5A5-9A47D8EF68F7");
                //Guid SeatIDB6 = Guid.Parse("B51224FF-B75C-4E04-9A12-0E8BF96A43D5");
                //Guid SeatIDB7 = Guid.Parse("B2E10C30-8E6C-40FD-89A7-9627BF5FE541");
                //Guid SeatIDB8 = Guid.Parse("7BEE3EF2-6033-4E25-89BF-FDC8E9494E2C");

                //Guid SeatIDB9 = Guid.Parse("EED81CD4-5958-4872-8E0A-DA1CA0AC368A");
                //Guid SeatIDB10 = Guid.Parse("D9EBADDE-29E9-4121-AA55-D22817C601E9");
                //Guid SeatIDB11 = Guid.Parse("A9D3B0D4-2594-4949-ACAE-B542413600AA");
                //Guid SeatIDB12 = Guid.Parse("4BC6FA95-7B90-44FB-A758-696176DB4109");

                //Guid SeatIDB13 = Guid.Parse("24CAF5D7-E2DB-44B1-B145-E2EAB29A22A3");
                //Guid SeatIDB14 = Guid.Parse("E71F128B-5AA1-49B3-AF04-618808D0A6AF");
                //Guid SeatIDB15 = Guid.Parse("B53A0C7D-1405-4A68-A6A6-A9CF7AF6A3A7");
                //Guid SeatIDB16 = Guid.Parse("C5A40B9A-5D93-4223-95CF-0090BD3BD0FB");

                ////Train 3
                //Guid SeatIDC1 = Guid.Parse("FF6370B6-C194-4ACC-8EF9-70339FB5FA13");
                //Guid SeatIDC2 = Guid.Parse("7915717F-20A2-4F03-AC6C-21D3CD326A04");
                //Guid SeatIDC3 = Guid.Parse("454333DD-D175-47DC-ACB1-9312F6E7376A");

                //Guid SeatIDC4 = Guid.Parse("520DE61F-DC9E-4747-8B1C-42AA70979BFF");
                //Guid SeatIDC5 = Guid.Parse("9A4B7F11-6E29-4ED2-939C-B5C44C47CE33");
                //Guid SeatIDC6 = Guid.Parse("2C922EC6-C82A-4FD5-AFD1-E379E7B63B80");

                //Guid SeatIDC7 = Guid.Parse("AFC39E45-E4D6-4666-9159-1494C1A18A39");
                //Guid SeatIDC8 = Guid.Parse("1B155670-A5AB-44CD-A2A0-BF265453E663");

                //Seat[] seats = new Seat[33]
                //{
                //    //Train 1
                //    new Seat { SeatId = SeatIDA1, SeatName = "A1",  CarrigeId = CarrigeID11,Booked = false, TrainID = Train1 },
                //    new Seat { SeatId = SeatIDA2, SeatName = "A2" , CarrigeId = CarrigeID11,Booked = false, TrainID = Train1 },
                //    new Seat { SeatId = SeatIDA3, SeatName = "A3",  CarrigeId = CarrigeID11,Booked = false, TrainID = Train1 },

                //    new Seat { SeatId = SeatIDA4, SeatName = "A4" , CarrigeId = CarrigeID12 ,Booked = false, TrainID = Train1},
                //    new Seat { SeatId = SeatIDA5, SeatName = "A5",  CarrigeId = CarrigeID12 ,Booked = false, TrainID = Train1},
                //    new Seat { SeatId = SeatIDA6, SeatName = "A6" , CarrigeId = CarrigeID12 ,Booked = false, TrainID = Train1},

                //    new Seat { SeatId = SeatIDA7, SeatName = "A7" , CarrigeId = CarrigeID13 ,Booked = false, TrainID = Train1},
                //    new Seat { SeatId = SeatIDA8, SeatName = "A8" , CarrigeId = CarrigeID13 ,Booked = false, TrainID = Train1},
                //    new Seat { SeatId = SeatIDA9, SeatName = "A9" , CarrigeId = CarrigeID13 ,Booked = false, TrainID = Train1},

                //    //Train 2
                //    new Seat { SeatId = SeatIDB1, SeatName = "B1" , CarrigeId = CarrigeID21 ,Booked = false, TrainID = Train2},
                //    new Seat { SeatId = SeatIDB2, SeatName = "B2" , CarrigeId = CarrigeID21 ,Booked = false, TrainID = Train2},
                //    new Seat { SeatId = SeatIDB3, SeatName = "B3" , CarrigeId = CarrigeID21 ,Booked = false, TrainID = Train2},
                //    new Seat { SeatId = SeatIDB4, SeatName = "B4" , CarrigeId = CarrigeID21 ,Booked = false, TrainID = Train2},

                //    new Seat { SeatId = SeatIDB5, SeatName = "B5" , CarrigeId = CarrigeID22 ,Booked = false, TrainID = Train2},
                //    new Seat { SeatId = SeatIDB6, SeatName = "B6" , CarrigeId = CarrigeID22 ,Booked = false, TrainID = Train2},
                //    new Seat { SeatId = SeatIDB7, SeatName = "B7" , CarrigeId = CarrigeID22 ,Booked = false, TrainID = Train2},
                //    new Seat { SeatId = SeatIDB8, SeatName = "B8" , CarrigeId = CarrigeID22 ,Booked = false, TrainID = Train2},

                //    new Seat { SeatId = SeatIDB9, SeatName = "B9" , CarrigeId = CarrigeID23 ,Booked = false, TrainID = Train2},
                //    new Seat { SeatId = SeatIDB10, SeatName = "B10", CarrigeId = CarrigeID23 ,Booked = false, TrainID = Train2},
                //    new Seat { SeatId = SeatIDB11, SeatName = "B11" , CarrigeId = CarrigeID23 ,Booked = false, TrainID = Train2},
                //    new Seat { SeatId = SeatIDB12, SeatName = "B12" , CarrigeId = CarrigeID23 ,Booked = false, TrainID = Train2},

                //    new Seat { SeatId = SeatIDB13, SeatName = "B13" , CarrigeId = CarrigeID24 ,Booked = false, TrainID = Train2},
                //    new Seat { SeatId = SeatIDB14, SeatName = "B14", CarrigeId = CarrigeID24 ,Booked = false, TrainID = Train2},
                //    new Seat { SeatId = SeatIDB15, SeatName = "B15" , CarrigeId = CarrigeID24 ,Booked = false, TrainID = Train2},
                //    new Seat { SeatId = SeatIDB16, SeatName = "B16" , CarrigeId = CarrigeID24 ,Booked = false, TrainID = Train2},

                //    //Train 3
                //    new Seat { SeatId = SeatIDC1, SeatName = "C1" , CarrigeId = CarrigeID31 ,Booked = false, TrainID = Train3},
                //    new Seat { SeatId = SeatIDC2, SeatName = "C2" , CarrigeId = CarrigeID31 ,Booked = false, TrainID = Train3},
                //    new Seat { SeatId = SeatIDC3, SeatName = "C3" , CarrigeId = CarrigeID31 ,Booked = false, TrainID = Train3},

                //    new Seat { SeatId = SeatIDC4, SeatName = "C4" , CarrigeId = CarrigeID32 ,Booked = false, TrainID = Train3},
                //    new Seat { SeatId = SeatIDC5, SeatName = "C5" , CarrigeId = CarrigeID32 ,Booked = false, TrainID = Train3},
                //    new Seat { SeatId = SeatIDC6, SeatName = "C6" , CarrigeId = CarrigeID32 ,Booked = false, TrainID = Train3},

                //    new Seat { SeatId = SeatIDC7, SeatName = "C7" , CarrigeId = CarrigeID33 ,Booked = false, TrainID = Train3},
                //    new Seat { SeatId = SeatIDC8, SeatName = "C8" , CarrigeId = CarrigeID33 ,Booked = false, TrainID = Train3},
                //};
                //
               // modelBuilder.Entity<Seat>().HasData(seats);
            }
        }
    }
}
