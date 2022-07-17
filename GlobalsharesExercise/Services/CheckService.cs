using GlobalsharesExercise.Models;

namespace GlobalsharesExercise.Services
{
    public class CheckService
    {
        private readonly LandingPlatform _landingPlatForm;

        public CheckService(LandingPlatform landingPlatForm)
        {
            _landingPlatForm = landingPlatForm;
        }

        public IEnumerable<string> CheckLanding(IEnumerable<Point> landingRockets)
        {
            var checkedPositions = new List<Point>();
            foreach (var landingRocket in landingRockets)
            {
                if (landingRocket.X >= _landingPlatForm.UpperLeftCorner.X && landingRocket.X <= _landingPlatForm.LowerRightCorner.X
                    && landingRocket.Y >= _landingPlatForm.UpperLeftCorner.Y && landingRocket.Y <= _landingPlatForm.LowerRightCorner.Y)
                {
                    var allCheck = true;
                    foreach (var checkedPos in checkedPositions)
                    {
                        if (Math.Abs(landingRocket.X - checkedPos.X) <= 1
                            && Math.Abs(landingRocket.Y - checkedPos.Y) <= 1)
                        {
                            allCheck &= false;
                            yield return "clash";
                        }
                    }
                    if (allCheck)
                    {
                        checkedPositions.Add(landingRocket);
                        yield return "ok for landing";
                    }
                }
                else
                {
                    yield return "out of platform";
                }
            }
        }
    }
}