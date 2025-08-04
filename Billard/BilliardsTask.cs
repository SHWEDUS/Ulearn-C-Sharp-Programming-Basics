using System;

namespace Billiards;

public static class BilliardsTask
{
    /// <summary>
    /// Расчёт угла отражения от стены 
    /// </summary>
    /// <param name="directionRadians">Угол направления движения шара</param>
    /// <param name="wallInclinationRadians">Угол наклона стены</param>
    /// <returns></returns>
    public static double BounceWall(double directionRadians, double wallInclinationRadians)
    {
        return wallInclinationRadians * 2.0 - directionRadians;
    }
}