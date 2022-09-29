using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220929
{
    internal class Mission
    {
        public string Code { get; set; }
        public DateTime LaunchDate { get; set; }
        public string ShuttleName { get; set; }
        private int SpaceTimeDays { get; set; }
        private int SpaceTimeHours { get; set; }
        public int TotalSpaceHours => SpaceTimeDays * 24 + SpaceTimeHours;
        public string LandingAirbase { get; set; }
        public int NOCrew { get; set; }

        public Mission(string row)
        {
            var pieces = row.Split(';');
            Code = pieces[0];
            LaunchDate = DateTime.Parse(pieces[1]);
            ShuttleName = pieces[2];
            SpaceTimeDays = int.Parse(pieces[3]);
            SpaceTimeHours = int.Parse(pieces[4]);
            LandingAirbase = pieces[5];
            NOCrew = int.Parse(pieces[6]);
        }
    }
}
