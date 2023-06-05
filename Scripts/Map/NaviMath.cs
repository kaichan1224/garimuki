/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 緯度経度の２地点からkmへ変換
 **************************************/
using System;

public static class NaviMath
{
    private const double EARTH_RADIUS = 6378.137d; //km

    public static double Deg2Rad { get { return Math.PI / 180.0d; } }

    //kmで計算する
    public static double LatlngDistance(Location a, Location b)
    {
        double dlat1 = a.Latitude * Deg2Rad;
        double dlng1 = a.Longitude * Deg2Rad;
        double dlat2 = b.Latitude * Deg2Rad;
        double dlng2 = b.Longitude * Deg2Rad;

        double d1 = Math.Sin(dlat1) * Math.Sin(dlat2);
        double d2 = Math.Cos(dlat1) * Math.Cos(dlat2) * Math.Cos(dlng2 - dlng1);
        double distance = EARTH_RADIUS * Math.Acos(d1 + d2);
        return distance;
    }
}
