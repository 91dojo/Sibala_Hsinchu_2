﻿using System.Collections.Generic;
using System.Linq;

namespace Sibala_Hsinchu_2
{
    public class NormalPointsHandler
    {
        private Sibara _sibara;

        public NormalPointsHandler(Sibara sibara)
        {
            _sibara = sibara;
        }

        public void SetResult()
        {
            if (_sibara._nums.Distinct().Count() == 2)
            {
                _sibara.Points = _sibara._nums.Take(2).Sum();
                _sibara.MaxPoint = _sibara._nums.Max();
            }
            else
            {
                _sibara.Points = _sibara._nums.GroupBy(x => x).Where(x => x.Count() == 1).Sum(x => x.Key);
                _sibara.MaxPoint = _sibara._nums.GroupBy(x => x).Where(x => x.Count() == 1).Max(x => x.Key);
            }

            _sibara.Status = SibaraStatus.StatusEnum.Point;
            SetOutput();
        }

        private Dictionary<int, string> specialOutput = new Dictionary<int, string>
            {
                {12, "sibala"},
                {3, "BG"},
            };

        private void SetOutput()
        {
            _sibara.Output = IsSpecialOutput(specialOutput) ? specialOutput[_sibara.Points] : $"{_sibara.Points} point";
        }

        private bool IsSpecialOutput(Dictionary<int, string> specialOutput)
        {
            return specialOutput.ContainsKey(_sibara.Points);
        }
    }
}