using SacramentMeetingPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Data
{
	public class DbInitializer
	{
		public static void Initialize(MeetingContext context)
		{
			// context.Database.EnsureCreated();

			// Look for any students.
			if (context.Planner.Any())
			{
				return;   // DB has been seeded
			}

			var bishopricMembers = new Bishopric[]
			{
				new Bishopric{BishopricName="Bishop Coates",Active=true},
				new Bishopric{BishopricName="Brother McInnes",Active=true},
				new Bishopric{BishopricName="Brother Tucker",Active=true}
			};
			foreach (Bishopric b in bishopricMembers)
			{
				context.Bishopric.Add(b);
			}
			context.SaveChanges();

			var planners = new Planner[]
			{
			//new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
			//new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
			//new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
			//new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
			//new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
			//new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
			//new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
			//new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
			new Planner{MeetingDate=DateTime.Parse("2018-12-09"),BishopricId=1,OpenPrayer="Kayla Roberts",ClosePrayer="Cory Hellbusch"},
			new Planner{MeetingDate=DateTime.Parse("2018-12-16"),BishopricId=2,OpenPrayer="Dana Roberts",ClosePrayer="Jordan Fielding"}
			};
			foreach (Planner p in planners)
			{
				context.Planner.Add(p);
			}
			context.SaveChanges();

			var speakers = new Speaker[]
			{
			//new Course{CourseID=1050,Title="Chemistry",Credits=3},
			//new Course{CourseID=4022,Title="Microeconomics",Credits=3},
			//new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
			//new Course{CourseID=1045,Title="Calculus",Credits=4},
			//new Course{CourseID=3141,Title="Trigonometry",Credits=4},
			//new Course{CourseID=2021,Title="Composition",Credits=3},
			//new Course{CourseID=2042,Title="Literature",Credits=4}
			new Speaker{PlannerId=1,SpeakerName="Alexa Morris",SpeakerTopic="Charity"},
			new Speaker{PlannerId=1,SpeakerName="Rachel Johnson",SpeakerTopic="Charity and Service"},
			new Speaker{PlannerId=1,SpeakerName="Raquel Gray",SpeakerTopic="Service"},
			new Speaker{PlannerId=2,SpeakerName="Bekah Russell",SpeakerTopic="Love"},
			new Speaker{PlannerId=2,SpeakerName="Kelly",SpeakerTopic="Obedience"}
			};
			foreach (Speaker s in speakers)
			{
				context.Speakers.Add(s);
			}
			context.SaveChanges();

			var songs = new Song[]
			{
			//new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
			//new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
			//new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
			//new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
			//new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
			//new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
			//new Enrollment{StudentID=3,CourseID=1050},
			//new Enrollment{StudentID=4,CourseID=1050},
			//new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
			//new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
			//new Enrollment{StudentID=6,CourseID=1045},
			//new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
			new Song{PlannerId=1,OpenSongNum=6,OpenSongTitle="Redeemer",SacramentSongNum=196,SacramentSongTitle="Jesus",CloseSongNum=2,CloseSongTitle="Spirit"},
			new Song{PlannerId=2,OpenSongNum=239,OpenSongTitle="Choose",SacramentSongNum=196,SacramentSongTitle="Jesus",CloseSongNum=240,CloseSongTitle="Know"}
			};
			foreach (Song s in songs)
			{
				context.Songs.Add(s);
			}
			context.SaveChanges();
		}
	}
}
