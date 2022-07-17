using GlobalsharesExercise.Models;
using GlobalsharesExercise.Services;

namespace LandingUnitTest
{
    public class CheckServiceTest
    {
        private readonly CheckService _checkService;

        public CheckServiceTest()
        {
            var landingPlatForm = new LandingPlatform()
            {
                UpperLeftCorner = new Point(5, 5),
                LowerRightCorner = new Point(14, 14)
            };
            _checkService = new CheckService(landingPlatForm);
        }

        [Fact]
        public void Test1()
        {
            IEnumerable<Point> rockets = new List<Point>()
            {
                new Point(4,4),new Point(5,5),new Point(14,14)
            };
            var response = _checkService.CheckLanding(rockets).ToArray();
            Assert.True(response[0] == "out of platform");          //out of platform
            Assert.True(response[1] == "ok for landing");           //ok for landing 
            Assert.True(response[2] == "ok for landing");           //ok for landing
        }

        [Fact]
        public void Test2()
        {
            IEnumerable<Point> rockets = new List<Point>()
            {
                new Point(5,5),new Point(6,6),new Point(7,7),new Point(5,6)
            };
            var response = _checkService.CheckLanding(rockets).ToArray();
            Assert.True(response[0] == "ok for landing");           //ok for landing 
            Assert.True(response[1] == "clash");                    //clash - another rocket landed near site
            Assert.True(response[2] == "ok for landing");           //ok for landing - previous rocket didn't land
            Assert.True(response[3] == "clash");                    //clash - another rocket landed near site
        }

        [Fact]
        public void Test3()
        {
            IEnumerable<Point> rockets = new List<Point>()
            {
                new Point(5,5),new Point(5,7),new Point(5,9),new Point(5,11),new Point(5,5), new Point(14,15),new Point(14,14)
            };
            var response = _checkService.CheckLanding(rockets).ToArray();
            Assert.True(response[0] == "ok for landing");           //ok for landing
            Assert.True(response[1] == "ok for landing");           //ok for landing
            Assert.True(response[2] == "ok for landing");           //ok for landing
            Assert.True(response[3] == "ok for landing");           //ok for landing
            Assert.True(response[4] == "clash");                    //clash - another rocket landed near site
            Assert.True(response[5] == "out of platform");          //out of platform - no landing
            Assert.True(response[6] == "ok for landing");           //ok for landing - no rocket land near
        }
    }
}