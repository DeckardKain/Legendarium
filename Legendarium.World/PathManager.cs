namespace LegendariumWorld
{
    public class PathManager
    {
        public static string GetRandomTerrain()
        {
            var random = new Random();

            Type terrainType = typeof(Path.TerrainType);

            Array terrainValues = terrainType.GetEnumValues();

            var terrain = (Path.TerrainType)random.Next(terrainValues.Length);            

            return terrain.ToString();
        }

        //public static string GetRandomEntrance()
        //{
        //    var random = new Random();

        //    //Type entranceType = typeof(GateWay.EntranceType);

        //    Array entranceValues = entranceType.GetEnumValues();

        //    var entrance = (Path.TerrainType)random.Next(entranceValues.Length);

        //    return entrance.ToString();
        //}

        public static List<Path> CreatePaths(int amount)
        {
            List<Path> paths = new List<Path>();

            for(int i = 0; i < amount; i++)
            {
                var path = new Path()
                {
                    Id = i,
                    Terrain = GetRandomTerrain(),
                    Length = 10,
                    Width = 100
                };

                paths.Add(path);
            }
            return paths; 
        }

        //public static GateWay CreateGateWay(int startLocation)
        //{

        //    var gateway = new GateWay()
        //    {
        //        Id = startLocation,
        //        Entrance = GetRandomEntrance(),
        //        MileNumber = startLocation,
        //        Name = ""
        //    };

        //    return gateway;

        //}

        //public static List<Path> CreateDungeonPaths(int amount)
        //{
        //    List<Path> paths = new List<Path>();
        //    var ran = new Random();

        //    for (int i = 0; i < amount; i++)
        //    {
        //        var path = new Path()
        //        {
        //            Id = i,
        //            Terrain = GetRandomTerrain(),
        //            Length = ran.Next(1,5),
        //            Width = ran.Next(1,10)                   
        //        };
        //        paths.Add(path);
        //    }

        //    while(paths.Where(x => x.IsConnected == false).Any())
        //    {
        //        int index = ran.Next(paths.Count);

        //        var path = paths[index];

        //        if(path.IsConnected == false)
        //        {

        //            var selectPathToConnect = paths[ran.Next(paths.Count)];

        //            var connection = new ConnectedPath()
        //            {
        //                PathId = selectPathToConnect.Id,
        //                MileMarker = ran.Next(path.Length)
        //            };
        //            var connectedPathList = new List<ConnectedPath>();
        //            connectedPathList.Add(connection);
        //            path.ConnectedPaths = connectedPathList;
        //            path.IsConnected = true;                  

        //        }
        //    }
        //    return paths;
        //}
    }
}
